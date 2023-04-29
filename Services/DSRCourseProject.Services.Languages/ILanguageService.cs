namespace DSRCourseProject.Services.Languages;

public interface ILanguageService
{
    Task<IEnumerable<LanguageModel>> GetLanguages(int offset = 0, int limit = 10);
    Task<LanguageModel> GetLanguage(int languageId);
    Task<LanguageModel> AddLanguage(AddLanguageModel model);
    Task UpdateLanguage(int id, UpdateLanguageModel model);
    Task DeleteLanguage(int languageId);
}