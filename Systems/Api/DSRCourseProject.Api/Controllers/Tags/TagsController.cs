namespace DSRCourseProject.API.Controllers;

using AutoMapper;
using DSRCourseProject.API.Controllers.Models;
using DSRCourseProject.Common.Responses;
using DSRCourseProject.Services.Tags;
using Microsoft.AspNetCore.Mvc;


/// <summary>
/// Tags controller
/// </summary>
/// <response code="400">Bad Request</response>
/// <response code="401">Unauthorized</response>
/// <response code="403">Forbidden</response>
/// <response code="404">Not Found</response>
[ProducesResponseType(typeof(ErrorResponse), 400)]
[Produces("application/json")]
[Route("api/v{version:apiVersion}/tags")]
[ApiController]
[ApiVersion("1.0")]
public class TagsController : ControllerBase
{
    private readonly IMapper mapper;
    private readonly ILogger<TagsController> logger;
    private readonly ITagService tagService;

    public TagsController(IMapper mapper, ILogger<TagsController> logger, ITagService tagService)
    {
        this.mapper = mapper;
        this.logger = logger;
        this.tagService = tagService;
    }


    /// <summary>
    /// Get tags
    /// </summary>
    /// <param name="offset">Offset to the first element</param>
    /// <param name="limit">Count elements on the page</param>
    /// <response code="200">List of TagResponses</response>
    [ProducesResponseType(typeof(IEnumerable<TagResponse>), 200)]
    [HttpGet("")]
    public async Task<IEnumerable<TagResponse>> GetTags([FromQuery] int offset = 0, [FromQuery] int limit = 10)
    {
        var tags = await tagService.GetTags(offset, limit);
        var response = mapper.Map<IEnumerable<TagResponse>>(tags);

        return response;
    }

    /// <summary>
    /// Get tags by Id
    /// </summary>
    /// <response code="200">TagResponse></response>
    [ProducesResponseType(typeof(TagResponse), 200)]
    [HttpGet("{id}")]
    public async Task<TagResponse> GetTagById([FromRoute] int id)
    {
        var tag = await tagService.GetTag(id);
        var response = mapper.Map<TagResponse>(tag);

        return response;
    }

    [HttpPost("")]
    public async Task<TagResponse> AddTag([FromBody] AddTagRequest request)
    {
        var model = mapper.Map<AddTagModel>(request);
        var tag = await tagService.AddTag(model);
        var response = mapper.Map<TagResponse>(tag);

        return response;
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateTag([FromRoute] int id, [FromBody] UpdateTagRequest request)
    {
        var model = mapper.Map<UpdateTagModel>(request);
        await tagService.UpdateTag(id, model);

        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTag([FromRoute] int id)
    {
        await tagService.DeleteTag(id);

        return Ok();
    }
}
