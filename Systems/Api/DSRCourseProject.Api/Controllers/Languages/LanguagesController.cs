namespace DSRCourseProject.API.Controllers;

using AutoMapper;
using DSRCourseProject.API.Controllers.Models;
using DSRCourseProject.Common.Responses;
using DSRCourseProject.Services.Languages;
using Microsoft.AspNetCore.Mvc;


/// <summary>
/// Languages controller
/// </summary>
/// <response code="400">Bad Request</response>
/// <response code="401">Unauthorized</response>
/// <response code="403">Forbidden</response>
/// <response code="404">Not Found</response>
[ProducesResponseType(typeof(ErrorResponse), 400)]
[Produces("application/json")]
[Route("api/v{version:apiVersion}/languages")]
[ApiController]
[ApiVersion("1.0")]
public class LanguagesController : ControllerBase
{
    private readonly IMapper mapper;
    private readonly ILogger<LanguagesController> logger;
    private readonly ILanguageService languageService;

    public LanguagesController(IMapper mapper, ILogger<LanguagesController> logger, ILanguageService languageService)
    {
        this.mapper = mapper;
        this.logger = logger;
        this.languageService = languageService;
    }


    /// <summary>
    /// Get languages
    /// </summary>
    /// <param name="offset">Offset to the first element</param>
    /// <param name="limit">Count elements on the page</param>
    /// <response code="200">List of LanguageResponses</response>
    [ProducesResponseType(typeof(IEnumerable<LanguageResponse>), 200)]
    [HttpGet("")]
    public async Task<IEnumerable<LanguageResponse>> GetLanguages([FromQuery] int offset = 0, [FromQuery] int limit = 10)
    {
        var languages = await languageService.GetLanguages(offset, limit);
        var response = mapper.Map<IEnumerable<LanguageResponse>>(languages);

        return response;
    }

    /// <summary>
    /// Get languages by Id
    /// </summary>
    /// <response code="200">LanguageResponse></response>
    [ProducesResponseType(typeof(LanguageResponse), 200)]
    [HttpGet("{id}")]
    public async Task<LanguageResponse> GetLanguageById([FromRoute] int id)
    {
        var language = await languageService.GetLanguage(id);
        var response = mapper.Map<LanguageResponse>(language);

        return response;
    }

    [HttpPost("")]
    public async Task<LanguageResponse> AddLanguage([FromBody] AddLanguageRequest request)
    {
        var model = mapper.Map<AddLanguageModel>(request);
        var language = await languageService.AddLanguage(model);
        var response = mapper.Map<LanguageResponse>(language);

        return response;
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateLanguage([FromRoute] int id, [FromBody] UpdateLanguageRequest request)
    {
        var model = mapper.Map<UpdateLanguageModel>(request);
        await languageService.UpdateLanguage(id, model);

        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteLanguage([FromRoute] int id)
    {
        await languageService.DeleteLanguage(id);

        return Ok();
    }
}
