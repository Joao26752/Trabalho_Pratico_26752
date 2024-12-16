using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabalho_Pratico_26752.Classes;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Trabalho_Pratico_26752.Classes
{
    // Representa uma solicitação de assistência.
    // The Assistance class represents a request for assistance.
    // It includes properties for the request date, type, status, description, customer, and operator.
    // The constructor initializes the assistance with an ID, customer, type, and description.
    // The AssignToOperator method assigns the assistance to an operator and changes the status to InProgress.
    // The CloseAssistance method closes the assistance and updates the status to Closed.
    public class Assistance : Entity, IAssistanceManager
    {
        #region Properties
        public DateTime RequestDate { get; private set; }
        public AssistanceType Type { get; private set; }
        public AssistanceRequestStatus Status { get; private set; }
        public string Description { get; private set; }
        public Customer Customer { get; private set; }
        public Operator Operator { get; private set; }
        public int Rating { get; internal set; }
        public AssistanceRequestStatus AssistanceStatus { get; internal set; }
        public bool ProblemResolved { get; internal set; }
        #endregion

        #region Constructor
        public Assistance(int id, Customer customer, AssistanceType type, string description) : base(id)
        {
            Customer = customer;
            Type = type;
            Description = description;
            RequestDate = DateTime.Parse("2024-12-13T19:15:37Z");
            Status = AssistanceRequestStatus.Open;
        }
        #endregion

        #region Methods
        // Assigns the assistance to an operator and changes the status to InProgress.
        public void AssignToOperator(Operator op)
        {
            try
            {
                Operator = op;
                Status = AssistanceRequestStatus.InProgress;
                Console.WriteLine($"Assistance {this.Description} assigned to operator {op.Name}.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error assigning assistance: {ex.Message}");
            }
        }

        // Closes the assistance and updates the status to Closed.
        public void CloseAssistance(bool resolved)
        {
            try
            {
                Status = AssistanceRequestStatus.Closed;
                Console.WriteLine($"Assistance {this.Description} closed with status: {Status}.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error closing assistance: {ex.Message}");
            }
        }

        // Sets the status of the assistance.
        public void SetStatus(AssistanceRequestStatus status)
        {
            Status = status;
        }
        #endregion

        #region IAssistanceManager
        public void ManageAssistance()
        {
            // Implement assistance management logic here
        }

        internal void LinkKnownProblem(KnownProblem knownProblem)
        {
            Console.WriteLine($"Problema conhecido '{knownProblem.Description}' vinculado à assistência.");
            ProblemResolved = true;
            AssistanceStatus = AssistanceRequestStatus.Closed;
        }

        public void DisplayDetails()
        {
            Console.WriteLine($"Assistência ID: {ID}");
            Console.WriteLine($"Cliente: {Customer.Name}");
            Console.WriteLine($"Operador: {Operator?.Name ?? "Não atribuído"}");
            Console.WriteLine($"Descrição: {Description}");
            Console.WriteLine($"Status: {Status}");
            Console.WriteLine($"Resolvido: {ProblemResolved}");
            Console.WriteLine($"Avaliação: {Rating}");
        }

        #endregion
    }

    // The AssistanceType enum defines types of assistance requests.
    public enum AssistanceType
    {
        TechnicalSupport,
        ProductExchange,
        Installation
    }

    // The AssistanceStatus enum defines the possible statuses of an assistance request.
    public enum AssistanceRequestStatus
    {
        Open,
        InProgress,
        Closed
    }

    // Define the IAssistanceManager interface
    public interface IAssistanceManager
    {
        void ManageAssistance();
    }
}
