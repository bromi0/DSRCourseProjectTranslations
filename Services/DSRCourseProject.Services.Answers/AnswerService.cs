using AutoMapper;
using DSRCourseProject.Common.Exceptions;
using DSRCourseProject.Common.Validator;
using DSRCourseProject.Context;
using DSRCourseProject.Context.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSRCourseProject.Services.Answers
{
    internal class AnswerService : IAnswerService
    {
        private readonly IDbContextFactory<MainDbContext> contextFactory;
        private readonly IMapper mapper;
        private readonly IModelValidator<AddAnswerModel> addValidator;
        private readonly IModelValidator<UpdateAnswerModel> updateValidator;

        public AnswerService(
        IDbContextFactory<MainDbContext> contextFactory,
        IMapper mapper,
        IModelValidator<AddAnswerModel> addValidator,
        IModelValidator<UpdateAnswerModel> updateValidator
        )
        {
            this.contextFactory = contextFactory;
            this.mapper = mapper;
            this.addValidator = addValidator;
            this.updateValidator = updateValidator;
        }

        public async Task<IEnumerable<AnswerModel>> GetAnswers(int offset = 0, int limit = 10)
        {
            using var context = await contextFactory.CreateDbContextAsync();

            var answers = context.Answers.AsQueryable();

            answers = answers
                .Skip(Math.Max(offset, 0))
                .Take(Math.Max(0, Math.Min(limit, 1000)));

            var data = (await answers.ToListAsync()).Select(a => mapper.Map<AnswerModel>(a));

            return data;
        }

        public async Task<AnswerModel> GetAnswer(int id)
        {
            using var context = await contextFactory.CreateDbContextAsync();

            var a = await context.Answers.FirstOrDefaultAsync(x => x.Id.Equals(id));

            var data = mapper.Map<AnswerModel>(a);

            return data;            
        }

        public async Task<AnswerModel> AddAnswer(AddAnswerModel model)
        {
            addValidator.Check(model);

            using var context = await contextFactory.CreateDbContextAsync();

            var answer = mapper.Map<TranslationAnswer>(model);
            await context.Answers.AddAsync(answer);
            context.SaveChanges();

            return mapper.Map<AnswerModel>(answer);            
        }

        public async Task DeleteAnswer(int id)
        {
            using var context = await contextFactory.CreateDbContextAsync();

            var answer = await context.Answers.FirstOrDefaultAsync(x => x.Id.Equals(id))
                ?? throw new ProcessException($"The answer (id: {id}) was not found");

            context.Remove(answer);
            context.SaveChanges();
        }

        public async Task UpdateAnswer(int id, UpdateAnswerModel model)
        {
            updateValidator.Check(model);

            using var context = await contextFactory.CreateDbContextAsync();

            var answer = await context.Answers.FirstOrDefaultAsync(x => x.Id.Equals(id));

            ProcessException.ThrowIf(() => answer is null, $"The answer (id: {id}) was not found");

            answer = mapper.Map(model, answer);

            context.Answers.Update(answer!);
            context.SaveChanges();            
        }
    }
}
