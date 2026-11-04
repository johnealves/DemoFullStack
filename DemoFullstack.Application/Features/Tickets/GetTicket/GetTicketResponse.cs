using DemoFullstack.Domain.Enums;

namespace DemoFullstack.Application.Features.Tickets.GetTickets;

public record GetTicketResponse(
    Guid Id,
    string Title,
    string Description,
    TicketPriority Priority,
    TicketStatus Status,
    DateTime CreatedAt);