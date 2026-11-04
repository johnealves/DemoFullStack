using DemoFullstack.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoFullstack.Application.Interface
{
    public interface ITicketRepository
    {
        Task<Ticket?> GetByIdAsync(
            Guid id,
            CancellationToken cancellationToken = default);

        Task<IReadOnlyList<Ticket>> GetAllAsync(
            CancellationToken cancellationToken = default);

        Task AddAsync(
            Ticket ticket,
            CancellationToken cancellationToken = default);

        Task SaveChangesAsync(
            CancellationToken cancellationToken = default);
    }
}
