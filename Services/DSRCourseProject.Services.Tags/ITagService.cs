namespace DSRCourseProject.Services.Tags;

public interface ITagService
{
    Task<IEnumerable<TagModel>> GetTags(int offset = 0, int limit = 10);
    Task<TagModel> GetTag(int tagId);
    Task<TagModel> AddTag(AddTagModel model);
    Task UpdateTag(int id, UpdateTagModel model);
    Task DeleteTag(int tagId);
}