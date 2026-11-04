using DemoFullstack.Application.Features.Tickets.GetTickets;
using DemoFullstack.Application.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoFullstack.Application.Features.Tickets.GetTicket
{
    public class GetTicketsUseCase
    {
        private readonly ITicketRepository _ticketRepository;

        public GetTicketsUseCase(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        public async Task<IReadOnlyList<GetTicketResponse>> ExecuteAsync(
            CancellationToken cancellationToken = default)
        {
            var tickets = await _ticketRepository.GetAllAsync(cancellationToken);

            return tickets.Select(ticket => new GetTicketResponse(
                ticket.Id,
                ticket.Title,
                ticket.Description,
                ticket.Priority,
                ticket.Status,
                ticket.CreatedAt)).ToList();
        }
    }
}
