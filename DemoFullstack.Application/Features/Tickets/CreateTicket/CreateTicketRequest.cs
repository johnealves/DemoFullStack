using DemoFullstack.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoFullstack.Application.Features.Tickets.CreateTicket
{
    public record CreateTicketRequest(
        string Title,
        string Description,
        TicketPriority Priority);
}
