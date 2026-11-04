using DemoFullstack.Application.Interface;
using DemoFullstack.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoFullstack.Application.Features.Tickets.CreateTicket
{
    public class CreateTicketUseCase
    {
        private readonly ITicketRepository _ticketRepository;

        public CreateTicketUseCase(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        public async Task<Guid> ExecuteAsync(
            CreateTicketRequest request,
            CancellationToken cancellationToken = default)
        {
            var ticket = new Ticket(
                request.Title,
                request.Description,
                request.Priority);

            await _ticketRepository.AddAsync(ticket, cancellationToken);
            await _ticketRepository.SaveChangesAsync(cancellationToken);

            return ticket.Id;
        }
    }
}
