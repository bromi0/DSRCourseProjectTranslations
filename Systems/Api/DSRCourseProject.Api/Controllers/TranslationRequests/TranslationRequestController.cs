namespace DSRCourseProject.API.Controllers;

using AutoMapper;
using DSRCourseProject.API.Controllers.Models;
using DSRCourseProject.Common.Responses;
using DSRCourseProject.Common.Security;
using DSRCourseProject.Services.Languages;
using DSRCourseProject.Services.TranslationRequests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


/// <summary>
/// Translation requests controller
/// </summary>
/// <response code="400">Bad Request</response>
/// <response code="401">Unauthorized</response>
/// <response code="403">Forbidden</response>
/// <response code="404">Not Found</response>
[ProducesResponseType(typeof(ErrorResponse), 400)]
[Produces("application/json")]
[Route("api/v{version:apiVersion}/translationrequests")]
[ApiController]
[ApiVersion("1.0")]
public class TranslationRequestsController : ControllerBase
{
    private readonly IMapper mapper;
    private readonly ILogger<TranslationRequestsController> logger;
    private readonly ITranslationRequestService translationsService;

    public TranslationRequestsController(IMapper mapper, ILogger<TranslationRequestsController> logger, ITranslationRequestService translationsService)
    {
        this.mapper = mapper;
        this.logger = logger;
        this.translationsService = translationsService;
    }


    /// <summary>
    /// Get Translation Requests
    /// </summary>
    /// <param name="offset">Offset to the first element</param>
    /// <param name="limit">Count elements on the page</param>
    /// <response code="200">List of TranslationRequestResponse</response>
    [ProducesResponseType(typeof(IEnumerable<TranslationRequestResponse>), 200)]    
    [HttpGet("")]
    public async Task<IEnumerable<TranslationRequestResponse>> GetTranslationRequests([FromQuery] int offset = 0, [FromQuery] int limit = 10)
    {
        var trs = await translationsService.GetTranslationRequests(offset, limit);
        var response = mapper.Map<IEnumerable<TranslationRequestResponse>>(trs);

        return response;
    }

    /// <summary>
    /// Get languages by Id
    /// </summary>
    /// <response code="200">TranslationRequestResponse></response>
    [ProducesResponseType(typeof(TranslationRequestResponse), 200)]    
    [HttpGet("{id}")]
    public async Task<TranslationRequestResponse> GetTranslationRequestById([FromRoute] int id)
    {
        var tr = await translationsService.GetTranslationRequest(id);
        var response = mapper.Map<TranslationRequestResponse>(tr);

        return response;
    }

    [HttpPost("")]    
    public async Task<TranslationRequestResponse> AddTranslationRequest([FromBody] AddTranslationRequestRequest request)
    {
        var model = mapper.Map<AddTranslationRequestModel>(request);
        var tr = await translationsService.AddTranslationRequest(model);
        var response = mapper.Map<TranslationRequestResponse>(tr);

        return response;
    }

    [HttpPut("{id}")]    
    public async Task<IActionResult> UpdateTranslationRequest([FromRoute] int id, [FromBody] UpdateTranslationRequestRequest request)
    {
        var model = mapper.Map<UpdateTranslationRequestModel>(request);
        await translationsService.UpdateTranslationRequest(id, model);

        return Ok();
    }

    [HttpDelete("{id}")]    
    public async Task<IActionResult> DeleteTranslationRequest([FromRoute] int id)
    {
        await translationsService.DeleteTranslationRequest(id);

        return Ok();
    }
}
