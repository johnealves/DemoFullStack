using DemoFullstack.Application.Interface;
using DemoFullstack.Domain.Entities;
using DemoFullstack.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoFullstack.Infrastructure.Repository
{
    public class TicketRepository : ITicketRepository
    {
        private readonly AppDbContext _context;

        public TicketRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Ticket?> GetByIdAsync(
            Guid id,
            CancellationToken cancellationToken = default)
        {
            return await _context.Tickets
                .SingleOrDefaultAsync(
                    ticket => ticket.Id == id,
                    cancellationToken);
        }

        public async Task<IReadOnlyList<Ticket>> GetAllAsync(
            CancellationToken cancellationToken = default)
        {
            return await _context.Tickets
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }

        public async Task AddAsync(
            Ticket ticket,
            CancellationToken cancellationToken = default)
        {
            await _context.Tickets.AddAsync(ticket, cancellationToken);
        }

        public async Task SaveChangesAsync(
            CancellationToken cancellationToken = default)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
