using Microsoft.AspNetCore.Mvc;
using Advice.Contracts.AdviceSolo;
namespace Advice.Controllers;
using Advice.Services.Advices;
using Advice.Models;
using ErrorOr;
using Advice.ServiceErrors;



[ApiController]
[Route("advice")]
public class AdvicesController : ControllerBase
{
    // dependency injection
    private readonly IAdviceService _adviceService;
    public AdvicesController(IAdviceService adviceService)
    {
        _adviceService = adviceService;
    }

    [HttpPost()]
    public IActionResult CreateAdvice(CreateAdviceRequest request)
    {
        var advice = new EachAdvice(
            Guid.NewGuid(),
            request.Name,
            request.Place,
            request.Description,
            request.tags
        );
        //ToDo: save breakfast to database 

        _adviceService.CreateAdvice(advice);
        var response = new AdviceResponse(
             advice.Id,
             advice.Name,
             advice.Place,
             advice.Description,
             advice.Tags
        );
        return CreatedAtAction(
            nameof(GetAdvice),
            new { id = advice.Id },
            response
        );
    }

    [HttpGet()]
    public List<EachAdvice> GetAll()
    {
        List<EachAdvice> advices = _adviceService.GetAllAdvices();
        return advices;
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetAdvice(Guid id)
    {
        ErrorOr<EachAdvice> getAdviceResult = _adviceService.GetAdvice(id);
        if (getAdviceResult.IsError && getAdviceResult.FirstError == Errors.Advice.NotFound)
        {
            return NotFound();
        }
        var advice = getAdviceResult.Value;
        var response = new AdviceResponse(
            advice.Id,
            advice.Name,
            advice.Place,
            advice.Description,
            advice.Tags
       );
        return Ok(response);
    }

    [HttpPut("{id:guid}")]
    public EachAdvice UpsertAdvice(Guid id, UpsertAdviceRequest request)
    {
        var advice = new EachAdvice(
            id,
            request.Name,
            request.Place,
            request.Description,
            request.tags
        );
        _adviceService.UpsertAdvice(advice);
        return advice;
    }

    [HttpDelete("{id:guid}")]
    public IActionResult DeleteAdvice(Guid id)
    {
        _adviceService.DeleteAdvice(id);
        return NoContent();
    }


}