using DemoFullstack.Domain.Entities;
using DemoFullstack.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace DemoFullstack.Infrastructure.Persistence;

public static class DbSeeder
{
    public static async Task SeedAsync(
        AppDbContext context,
        CancellationToken cancellationToken = default)
    {
        if (await context.Tickets.AnyAsync(cancellationToken))
        {
            return;
        }

        var tickets = new[]
        {
            new Ticket(
                "Não consigo acessar o sistema",
                "Ao tentar entrar, a aplicação retorna uma mensagem de erro.",
                TicketPriority.critical),

            new Ticket(
                "Erro ao gerar relatório",
                "O relatório não é gerado ao selecionar o período desejado.",
                TicketPriority.high),

            new Ticket(
                "Solicitação de melhoria",
                "Adicionar um filtro por status na listagem de chamados.",
                TicketPriority.low)
        };

        await context.Tickets.AddRangeAsync(tickets, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
    }
}