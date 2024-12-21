using System;
using Trabalho_Pratico_26752.Classes;

namespace Trabalho_Pratico_26752.Classes
{
    public class Assistance : Entity
    {
        #region Properties
        public DateTime RequestDate { get; private set; }
        public AssistanceType Type { get; private set; }
        private AssistanceRequestStatus _status;
        public AssistanceRequestStatus Status
        {
            get => _status;
            private set => _status = value;
        }
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
        /// <summary>
        /// Atribui a assistência a um operador.
        /// </summary>
        /// <param name="op">O operador a quem a assistência será atribuída.</param>
        public void AssignToOperator(Operator op)
        {
            if (op == null)
                throw new ArgumentNullException(nameof(op));

            Operator = op; // Atribui o operador
            Status = AssistanceRequestStatus.InProgress; // Atualiza o estado para em progresso
            Console.WriteLine($"Assistência {Description} atribuída ao operador {op.Name}.");
        }

        /// <summary>
        /// Atribui um técnico à assistência.
        /// </summary>
        /// <param name="technician">O técnico a ser atribuído.</param>
        public void AssignTechnician(Operator technician)
        {
            if (technician == null)
                throw new ArgumentNullException(nameof(technician), "O técnico não pode ser nulo.");

            AssignedTechnician = technician;
            Status = AssistanceRequestStatus.InProgress;
            Console.WriteLine($"Técnico {technician.Name} atribuído à assistência {Description}.");
        }

        /// <summary>
        /// Conclui o ticket de assistência.
        /// </summary>
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

        /// <summary>
        /// Fecha a assistência.
        /// </summary>
        /// <param name="resolved">Indica se o problema foi resolvido.</param>
        public void CloseAssistance(bool resolved)
        {
            Status = AssistanceRequestStatus.Closed;
            ProblemResolved = resolved;
            Console.WriteLine($"Assistência {Description} fechada com status: {Status}.");
        }

        /// <summary>
        /// Define o estado da assistência.
        /// </summary>
        /// <param name="status">O novo estado a ser definido.</param>
        public void SetStatus(AssistanceRequestStatus status)
        {
            if (status == AssistanceRequestStatus.Closed && Status != AssistanceRequestStatus.InProgress)
            {
                throw new InvalidOperationException("Assistência pode ser fechada apenas se estiver em progresso.");
            }
            Status = status;
        }

        /// <summary>
        /// Resolve a assistência.
        /// </summary>
        /// <param name="resolved">Indica se o problema foi resolvido.</param>
        /// <param name="rating">A avaliação da assistência.</param>
        public void ResolveAssistance(bool resolved, int rating)
        {
            Status = resolved ? AssistanceRequestStatus.Closed : AssistanceRequestStatus.InProgress;
            ProblemResolved = resolved;
            Rating = rating;
            Console.WriteLine($"Assistência {Description} resolvida com status: {Status} e avaliação: {Rating}.");
        }

        /// <summary>
        /// Rejeita a assistência.
        /// </summary>
        public void RejectAssistance()
        {
            Status = AssistanceRequestStatus.Closed;
            Console.WriteLine($"Assistência {Description} rejeitada.");
        }
        #endregion
    }

    #region Enums
    public enum AssistanceType
    {
        SuporteTecnico,
        TrocaDeProduto,
        Instalação
    }

    public enum AssistanceRequestStatus
    {
        Aberto,
        EmProgresso,
        Fechado
    }
    #endregion
}
