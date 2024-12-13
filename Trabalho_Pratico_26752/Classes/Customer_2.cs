using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Trabalho_Pratico_26752.Classes;
using Trabalho_Pratico_26752;

namespace Trabalho_Pratico_26752.Classes
{
    /// Representa um cliente no sistema.
    public class Customer_2 : Person
    {
        #region Fields

        /// Lista de assistências associadas ao cliente.

        private readonly List<Assistance> _assistances = new();
        #endregion

        #region Constructor
        /// Inicializa um novo cliente.

        public Customer_2(int id, string name, string email) : base(id, name, email) { }
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
