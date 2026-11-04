using DemoFullstack.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoFullstack.Domain.Entities
{
    public class Ticket
    {
        public const int MaxTitleLength = 150;
        public const int MaxDescriptionLength = 4000;
        public const int MaxResolutionLength = 4000;

        public Guid Id { get; private set; }
        public string Title { get; private set; } = string.Empty;
        public string Description { get; private set; } = string.Empty;
        public TicketPriority Priority { get; private set; }
        public TicketStatus Status { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }
        public DateTime ResolvedAt { get; private set; }
        public string? Resolution { get; private set; }

        private Ticket()
        {
        }

        public Ticket(
            string title,
            string description,
            TicketPriority priority)
        {
            Title = ValidateText(title, nameof(title), MaxTitleLength);

            Description = ValidateText(
                description, nameof(description), MaxDescriptionLength);

            if (!Enum.IsDefined(priority))
            {
                throw new ArgumentOutOfRangeException(
                    nameof(priority), "Invalid ticket priority.");
            }

            var now = DateTime.UtcNow;

            Id = Guid.NewGuid();
            Priority = priority;
            Status = TicketStatus.Open;
            CreatedAt = now;
            UpdatedAt = now;
        }

        public void StartProgress()
        {
            if (Status != TicketStatus.Open)
            {
                throw new InvalidOperationException(
                    "Only open tickets can be moved to in progress.");
            }

            Status = TicketStatus.InProgress;
            UpdatedAt = DateTime.UtcNow;
        }

        public void Resolve(string resolution)
        {
            if (Status != TicketStatus.InProgress)
            {
                throw new InvalidOperationException(
                    "Only tickets in progress can be resolved.");
            }

            Resolution = ValidateText(
                resolution, nameof(resolution), MaxResolutionLength);

            var now = DateTime.UtcNow;

            Status = TicketStatus.Resolved;
            ResolvedAt = now;
            UpdatedAt = now;
        }

        private static string ValidateText(
            string value,
            string parameterName,
            int maxLength)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(
                    "The text is required.", parameterName);
            }

            var text = value.Trim();

            if (text.Length > maxLength)
            {
                throw new ArgumentException(
                    $"The text must not exceed {maxLength} characters.",
                    parameterName);
            }

            return text;
        }
    }
}
