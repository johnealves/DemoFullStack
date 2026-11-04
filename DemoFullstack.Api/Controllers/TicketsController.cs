using DemoFullstack.Application.Features.Tickets.GetTicket;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace DemoFullstack.Api.Controllers
{
    [ApiController]
    [Route("api/tickets")]
    public class TicketsController : ControllerBase
    {
        private readonly GetTicketsUseCase _getTicketsUseCase;

        public TicketsController(GetTicketsUseCase getTicketsUseCase)
        {
            _getTicketsUseCase = getTicketsUseCase;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<GetTicketsUseCase>>> GetAll(
            CancellationToken cancellationToken)
        {
            var tickets = await _getTicketsUseCase.ExecuteAsync(cancellationToken);

            return Ok(tickets);
        }
    }
}
