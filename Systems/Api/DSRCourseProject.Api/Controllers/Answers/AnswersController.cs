namespace DSRCourseProject.API.Controllers;

using AutoMapper;
using DSRCourseProject.API.Controllers.Models;
using DSRCourseProject.Common.Responses;
using DSRCourseProject.Services.Answers;
using Microsoft.AspNetCore.Mvc;


/// <summary>
/// Answers controller
/// </summary>
/// <response code="400">Bad Request</response>
/// <response code="401">Unauthorized</response>
/// <response code="403">Forbidden</response>
/// <response code="404">Not Found</response>
[ProducesResponseType(typeof(ErrorResponse), 400)]
[Produces("application/json")]
[Route("api/v{version:apiVersion}/Answers")]
[ApiController]
[ApiVersion("1.0")]
public class AnswersController : ControllerBase
{
    private readonly IMapper mapper;
    private readonly ILogger<AnswersController> logger;
    private readonly IAnswerService AnswerService;

    public AnswersController(IMapper mapper, ILogger<AnswersController> logger, IAnswerService AnswerService)
    {
        this.mapper = mapper;
        this.logger = logger;
        this.AnswerService = AnswerService;
    }


    /// <summary>
    /// Get Answers
    /// </summary>
    /// <param name="offset">Offset to the first element</param>
    /// <param name="limit">Count elements on the page</param>
    /// <response code="200">List of AnswerResponses</response>
    [ProducesResponseType(typeof(IEnumerable<AnswerResponse>), 200)]
    [HttpGet("")]
    public async Task<IEnumerable<AnswerResponse>> GetAnswers([FromQuery] int offset = 0, [FromQuery] int limit = 10)
    {
        var Answers = await AnswerService.GetAnswers(offset, limit);
        var response = mapper.Map<IEnumerable<AnswerResponse>>(Answers);

        return response;
    }

    /// <summary>
    /// Get Answers by Id
    /// </summary>
    /// <response code="200">AnswerResponse></response>
    [ProducesResponseType(typeof(AnswerResponse), 200)]
    [HttpGet("{id}")]
    public async Task<AnswerResponse> GetAnswerById([FromRoute] int id)
    {
        var Answer = await AnswerService.GetAnswer(id);
        var response = mapper.Map<AnswerResponse>(Answer);

        return response;
    }

    [HttpPost("")]
    public async Task<AnswerResponse> AddAnswer([FromBody] AddAnswerRequest request)
    {
        var model = mapper.Map<AddAnswerModel>(request);
        var Answer = await AnswerService.AddAnswer(model);
        var response = mapper.Map<AnswerResponse>(Answer);

        return response;
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAnswer([FromRoute] int id, [FromBody] UpdateAnswerRequest request)
    {
        var model = mapper.Map<UpdateAnswerModel>(request);
        await AnswerService.UpdateAnswer(id, model);

        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAnswer([FromRoute] int id)
    {
        await AnswerService.DeleteAnswer(id);

        return Ok();
    }
}
