namespace DSRCourseProject.Services.Languages;

using AutoMapper;
using DSRCourseProject.Common.Exceptions;
using DSRCourseProject.Common.Validator;
using DSRCourseProject.Context;
using DSRCourseProject.Context.Entities;
using DSRCourseProject.Services.TranslationRequests;
using Microsoft.EntityFrameworkCore;

public class TranslationRequestService : ITranslationRequestService
{    

    private readonly IDbContextFactory<MainDbContext> contextFactory;
    private readonly IMapper mapper;    
    private readonly IModelValidator<AddTranslationRequestModel> addValidator;
    private readonly IModelValidator<UpdateTranslationRequestModel> updateValidator;

    public TranslationRequestService(
        IDbContextFactory<MainDbContext> contextFactory,
        IMapper mapper,
        IModelValidator<AddTranslationRequestModel> addValidator,
        IModelValidator<UpdateTranslationRequestModel> updateValidator
        )
    {
        this.contextFactory = contextFactory;
        this.mapper = mapper;
        this.addValidator = addValidator;
        this.updateValidator = updateValidator;
    }

    public async Task<IEnumerable<TranslationRequestModel>> GetTranslationRequests(int offset = 0, int limit = 10)
    {

        using var context = await contextFactory.CreateDbContextAsync();

        var translations = context
            .Translations
            .Include(x => x.SourceLanguage)
            .Include(x=>x.TargetLanguage)
            .Include(x=>x.Tags)
            .AsQueryable();

        translations = translations
            .Skip(Math.Max(offset, 0))
            .Take(Math.Max(0, Math.Min(limit, 1000)));

        var data = (await translations.ToListAsync()).Select(tr => mapper.Map<TranslationRequestModel>(tr));        

        return data;
    }

    public async Task<TranslationRequestModel> GetTranslationRequest(int id)
    {
        using var context = await contextFactory.CreateDbContextAsync();

        var tr = await context.Translations
            .Include(x => x.SourceLanguage)
            .Include(x => x.TargetLanguage)
            .Include(x=>x.Tags)
            .FirstOrDefaultAsync(x => x.Id.Equals(id));

        var data = mapper.Map<TranslationRequestModel>(tr);

        return data;
    }
    
    /// <summary>
    /// Creates a new translation request. If you supply a bunch of tags,
    /// verifies them against the database and creates new ones if they don't exist yet.
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    public async Task<TranslationRequestModel> AddTranslationRequest(AddTranslationRequestModel model)
    {
        addValidator.Check(model);

        using var context = await contextFactory.CreateDbContextAsync();

        var tr = mapper.Map<TranslationRequest>(model);
        var composedTags = new List<Tag>();
        // Iterate over each tag in the request model and check if it already exists in the database
        foreach (var tag in model.Tags)
        {            
            var existingTag = await context.Tags.SingleOrDefaultAsync(t => t.Value == tag.Value);

            if (existingTag == null)
            {
                // If the tag doesn't exist, create a new tag entity and add it to the context
                var newTag = mapper.Map<Tag>(tag);
                await context.Tags.AddAsync(newTag);
                composedTags.Add(newTag);
            }
            else
            {
                // If the tag exists, update the tag in the model to reference the existing tag entity
                composedTags.Add(existingTag);
            }
        }
        tr.Tags = composedTags;

        await context.Translations.AddAsync(tr);
        context.SaveChanges();
       
        return mapper.Map<TranslationRequestModel>(tr);
    }

    /// <summary>
    /// Updates a translation request. If you supply a bunch of tags,
    /// verifies them against the database and creates new ones if they don't exist yet.
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    public async Task UpdateTranslationRequest(int id, UpdateTranslationRequestModel model)
    {
        updateValidator.Check(model);

        using var context = await contextFactory.CreateDbContextAsync();

        var tr = await context.Translations
            .Include(x => x.SourceLanguage)
            .Include(x => x.TargetLanguage)            
            .Include(x => x.Tags)
            .FirstOrDefaultAsync(x => x.Id.Equals(id));

        ProcessException.ThrowIf(() => tr is null, $"The translation (id: {id}) was not found");

        // Clear current tags from an entity
        if (tr!.Tags != null) tr.Tags.Clear();
        if (tr!.Tags == null && model.Tags != null) tr.Tags = new List<Tag>();

        // Iterate over each tag in the request model and check if it already exists in the database
        if (model.Tags != null)
        {
            foreach (var tag in model.Tags)
            {
                var existingTag = await context.Tags.SingleOrDefaultAsync(t => t.Value == tag.Value);

                if (existingTag == null)
                {
                    // If the tag doesn't exist, create a new tag entity and add it to the context
                    var newTag = mapper.Map<Tag>(tag);
                    await context.Tags.AddAsync(newTag);
                    tr.Tags.Add(newTag);
                }
                else
                {
                    // If the tag exists, update the tag in the model to reference the existing tag entity
                    tr.Tags.Add(existingTag);
                }
            }
        }
        
        tr = mapper.Map(model, tr);

        context.Translations.Update(tr);
        context.SaveChanges();
    }

    public async Task DeleteTranslationRequest(int id)
    {
        using var context = await contextFactory.CreateDbContextAsync();

        var tr = await context.Translations.FirstOrDefaultAsync(x => x.Id.Equals(id))
            ?? throw new ProcessException($"The language (id: {id}) was not found");

        context.Remove(tr);
        context.SaveChanges();
    }
}
