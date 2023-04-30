namespace DSRCourseProject.Services.Answers;

public interface IAnswerService
{
    Task<IEnumerable<AnswerModel>> GetAnswers(int offset = 0, int limit = 10);
    Task<AnswerModel> GetAnswer(int id);
    Task<AnswerModel> AddAnswer(AddAnswerModel model);
    Task UpdateAnswer(int id, UpdateAnswerModel model);
    Task DeleteAnswer(int id);
}