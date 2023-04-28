namespace DSRCourseProject.Services.Tags;

using AutoMapper;
using DSRCourseProject.Common.Exceptions;
using DSRCourseProject.Common.Validator;
using DSRCourseProject.Context;
using DSRCourseProject.Context.Entities;
using Microsoft.EntityFrameworkCore;

public class TagService : ITagService
{    

    private readonly IDbContextFactory<MainDbContext> contextFactory;
    private readonly IMapper mapper;    
    private readonly IModelValidator<AddTagModel> addTagModelValidator;
//    private readonly IModelValidator<UpdateTagModel> updateTagModelValidator;

    public TagService(
        IDbContextFactory<MainDbContext> contextFactory,
        IMapper mapper,
        IModelValidator<AddTagModel> addTagModelValidator
        //IModelValidator<UpdateTagModel> updateTagModelValidator
        )
    {
        this.contextFactory = contextFactory;
        this.mapper = mapper;
        this.addTagModelValidator = addTagModelValidator;
        //this.updateTagModelValidator = updateTagModelValidator;
    }

    public async Task<IEnumerable<TagModel>> GetTags(int offset = 0, int limit = 10)
    {

        using var context = await contextFactory.CreateDbContextAsync();

        var tags = context
            .Tags            
            .AsQueryable();

        tags = tags
            .Skip(Math.Max(offset, 0))
            .Take(Math.Max(0, Math.Min(limit, 1000)));

        var data = (await tags.ToListAsync()).Select(tag => mapper.Map<TagModel>(tag));        

        return data;
    }

    public async Task<TagModel> GetTag(int id)
    {
        using var context = await contextFactory.CreateDbContextAsync();

        var tag = await context.Tags.FirstOrDefaultAsync(x => x.Id.Equals(id));

        var data = mapper.Map<TagModel>(tag);

        return data;
    }
    public async Task<TagModel> AddTag(AddTagModel model)
    {
//        addTagModelValidator.Check(model);

        using var context = await contextFactory.CreateDbContextAsync();

        var tag = mapper.Map<Tag>(model);
        await context.Tags.AddAsync(tag);
        context.SaveChanges();
        

        return mapper.Map<TagModel>(tag);
    }

    public async Task UpdateTag(int tagId, UpdateTagModel model)
    {
//        updateTagModelValidator.Check(model);

        using var context = await contextFactory.CreateDbContextAsync();

        var tag = await context.Tags.FirstOrDefaultAsync(x => x.Id.Equals(tagId));

        ProcessException.ThrowIf(() => tag is null, $"The tag (id: {tagId}) was not found");

        tag = mapper.Map(model, tag);

        context.Tags.Update(tag);
        context.SaveChanges();
    }

    public async Task DeleteTag(int tagId)
    {
        using var context = await contextFactory.CreateDbContextAsync();

        var tag = await context.Tags.FirstOrDefaultAsync(x => x.Id.Equals(tagId))
            ?? throw new ProcessException($"The tag (id: {tagId}) was not found");

        context.Remove(tag);
        context.SaveChanges();
    }
}
