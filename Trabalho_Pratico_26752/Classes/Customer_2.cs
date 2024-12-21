using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Trabalho_Pratico_26752.Classes;
using Trabalho_Pratico_26752;

namespace Trabalho_Pratico_26752.Classes
{
    /// Representa um cliente no sistema.
    // The Customer class represents a client in the system.
    // It contains a list of Assistance objects associated with the customer.
    // The constructor initializes the customer with an ID, name, and email.
    // The RequestAssistance method adds an assistance request to the customer's list.
    // The GetAssistances method returns all assistances associated with the customer.
    // The DisplayInfo method outputs the customer's information to the console.
    public class Customer : Person
    {
        #region Fields

        /// Lista de assistências associadas ao cliente.

        private readonly List<Assistance> _assistances = new List<Assistance>();
        #endregion

        #region Constructor
        /// Inicializa um novo cliente.

        public Customer(int id, string name, string email) : base(id, name, email) { }
        #endregion

        #region Methods

        /// Solicita uma nova assistência para o cliente.
        public void RequestAssistance(Assistance assistance)
        {
            _assistances.Add(assistance);
        }

  
        /// Retorna todas as assistências do cliente.
  
        public IEnumerable<Assistance> GetAssistances() => _assistances.AsReadOnly();

        /// Exibe as informações do cliente.
  
        public override void DisplayInfo()
        {
            Console.WriteLine($"Cliente: {Name} (ID: {ID}) - {Email}");
        }
        #endregion
    }
}
