using System;
using Trabalho_Pratico_26752.Classes;

namespace Trabalho_Pratico_26752.Classes
{
    public class Assistance : Entity
    {
        #region Properties
        public DateTime RequestDate { get; private set; }
        public AssistanceType Type { get; private set; }
        public AssistanceRequestStatus Status { get; private set; }
        public string Description { get; private set; }
        public Customer Customer { get; private set; }
        public Operator Operator { get; private set; }
        public Operator AssignedTechnician { get; private set; } // Técnico atribuído
        public int Rating { get; internal set; }
        public bool ProblemResolved { get; internal set; }
        #endregion

        #region Constructor
        public Assistance(int id, Customer customer, AssistanceType type, string description) : base(id)
        {
            Customer = customer;
            Type = type;
            Description = description;
            RequestDate = DateTime.Now;
            Status = AssistanceRequestStatus.Open;
        }
        #endregion

        #region Methods
        public void AssignToOperator(Operator op)
        {
            Operator = op;
            Status = AssistanceRequestStatus.InProgress;
            Console.WriteLine($"Assistance {Description} assigned to operator {op.Name}.");
        }

        public void AssignTechnician(Operator technician)
        {
            if (technician == null)
                throw new ArgumentNullException(nameof(technician), "O técnico não pode ser nulo.");

            AssignedTechnician = technician;
            Status = AssistanceRequestStatus.InProgress;
            Console.WriteLine($"Técnico {technician.Name} atribuído à assistência {Description}.");
        }

        public void CompleteTicket()
        {
            if (Status != AssistanceRequestStatus.InProgress)
            {
                throw new InvalidOperationException("O ticket só pode ser concluído se estiver em progresso.");
            }

            Status = AssistanceRequestStatus.Closed;
            ProblemResolved = true;

            Console.WriteLine($"Ticket ID {ID} concluído com sucesso.");
        }

        public void CloseAssistance(bool resolved)
        {
            Status = AssistanceRequestStatus.Closed;
            ProblemResolved = resolved;
            Console.WriteLine($"Assistance {Description} closed with status: {Status}.");
        }

        public void SetStatus(AssistanceRequestStatus status)
        {
            if (status == AssistanceRequestStatus.Closed && Status != AssistanceRequestStatus.InProgress)
            {
                throw new InvalidOperationException("Assistance can only be closed if it's in progress.");
            }
            Status = status;
        }
        public void ResolveAssistance(bool resolved, int rating)
        {
            Status = resolved ? AssistanceRequestStatus.Closed : AssistanceRequestStatus.InProgress;
            ProblemResolved = resolved;
            Rating = rating;
            Console.WriteLine($"Assistance {Description} resolved with status: {Status} and rating: {Rating}.");
        }
        public void RejectAssistance() {  
            Status = AssistanceRequestStatus.Closed;
            Console.WriteLine($"Assistance {Description} rejected.");
        }

        #endregion
    }

    public enum AssistanceType
    {
        TechnicalSupport,
        ProductExchange,
        Installation
    }

    public enum AssistanceRequestStatus
    {
        Open,
        InProgress,
        Closed
    }
}

