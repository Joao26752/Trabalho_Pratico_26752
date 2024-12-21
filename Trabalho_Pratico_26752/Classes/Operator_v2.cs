using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabalho_Pratico_26752.Classes;
using Trabalho_Pratico_26752;

namespace Trabalho_Pratico_26752.Classes
{
    /// Representa um operador que gerencia assistências.

    // The Operator class represents an operator managing assistances.
    // It includes properties for the operator's shift and a list of assigned assistances.
    // The constructor initializes the operator with an ID, name, email, and shift.
    // The AssignAssistance method assigns an assistance to the operator.
    // The GetAssignedAssistances method returns all assistances assigned to the operator.
    // The DisplayInfo method outputs the operator's information to the console.
    public class Operator : Person
    {
        #region Properties

        /// Turno de trabalho do operador.
        public string Shift { get; private set; } 
        #endregion

        #region Fields
        /// Lista de assistências atribuídas ao operador.
        private readonly List<Assistance> _assignedAssistances = new List<Assistance>();
        #endregion

        #region Properties
        public IReadOnlyList<Assistance> AssignedAssistances => _assignedAssistances.AsReadOnly();
        #endregion

        #region Constructor
        /// Inicializa um novo operador.

        public Operator(int id, string name, string email, string shift) : base(id, name, email)
        {
            Shift = shift;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Assigns an assistance to the operator.
        /// </summary>
        /// <param name="assistance">The assistance to assign.</param>
        public void AssignAssistance(Assistance assistance)
        {
            if (assistance == null)
                throw new ArgumentNullException(nameof(assistance));

            assistance.AssignToOperator(this);
            _assignedAssistances.Add(assistance);
        }

        /// <summary>
        /// Unassigns an assistance from the operator.
        /// </summary>
        /// <param name="assistance">The assistance to unassign.</param>
        public void UnassignAssistance(Assistance assistance)
        {
            if (assistance == null)
                throw new ArgumentNullException(nameof(assistance));

            _assignedAssistances.Remove(assistance);
        }

        /// <summary>
        /// Returns all assistances assigned to the operator.
        /// </summary>
        public IEnumerable<Assistance> GetAssignedAssistances() => _assignedAssistances.AsReadOnly();

        /// <summary>
        /// Displays the operator's information.
        /// </summary>
        public override void DisplayInfo()
        {
            Console.WriteLine($"Operator: {Name}, Email: {Email}, Shift: {Shift}");
        }

        /// <summary>
        /// Resolves an assistance and updates its status and rating.
        /// </summary>
        /// <param name="assistance">The assistance to resolve.</param>
        /// <param name="resolved">Whether the assistance is resolved.</param>
        /// <param name="rating">The rating of the assistance.</param>
        internal void ResolveAssistance(Assistance assistance, bool resolved, int rating)
        {
            try
            {
                assistance.SetStatus(resolved ? AssistanceRequestStatus.Closed : AssistanceRequestStatus.InProgress);
                assistance.Rating = rating;
                Console.WriteLine($"Assistance {assistance.Description} resolved with status: {assistance.Status} and rating: {rating}.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error resolving assistance: {ex.Message}");
            }
        }
        #endregion
    }
}
