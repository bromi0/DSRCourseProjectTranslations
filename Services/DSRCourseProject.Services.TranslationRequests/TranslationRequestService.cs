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
            .FirstOrDefaultAsync(x => x.Id.Equals(id));

        var data = mapper.Map<TranslationRequestModel>(tr);

        return data;
    }
    public async Task<TranslationRequestModel> AddTranslationRequest(AddTranslationRequestModel model)
    {
        addValidator.Check(model);

        using var context = await contextFactory.CreateDbContextAsync();

        var tr = mapper.Map<TranslationRequest>(model);
        await context.Translations.AddAsync(tr);
        context.SaveChanges();
       
        return mapper.Map<TranslationRequestModel>(tr);
    }

    public async Task UpdateTranslationRequest(int id, UpdateTranslationRequestModel model)
    {
        updateValidator.Check(model);

        using var context = await contextFactory.CreateDbContextAsync();

        var tr = await context.Translations
            .Include(x => x.SourceLanguage)
            .Include(x => x.TargetLanguage)
            .FirstOrDefaultAsync(x => x.Id.Equals(id));

        ProcessException.ThrowIf(() => tr is null, $"The translation (id: {id}) was not found");

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
