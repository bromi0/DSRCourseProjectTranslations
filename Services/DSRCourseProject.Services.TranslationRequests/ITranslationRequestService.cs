namespace DSRCourseProject.Services.TranslationRequests;

public interface ITranslationRequestService
{
    Task<IEnumerable<TranslationRequestModel>> GetTranslationRequests(int offset = 0, int limit = 10);
    Task<TranslationRequestModel> GetTranslationRequest(int languageId);
    Task<TranslationRequestModel> AddTranslationRequest(AddTranslationRequestModel model);
    Task UpdateTranslationRequest(int id, UpdateTranslationRequestModel model);
    Task DeleteTranslationRequest(int languageId);
}