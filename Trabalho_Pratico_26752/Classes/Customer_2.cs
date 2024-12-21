using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Trabalho_Pratico_26752.Classes;
using Trabalho_Pratico_26752;

namespace Trabalho_Pratico_26752.Classes
{
    /// <summary>
    /// Representa um cliente no sistema de helpdesk.
    /// </summary>
    public class Customer : Person
    {
        #region Fields

        /// Lista de pedidos de assistência associados ao cliente.
        private readonly List<Assistance> _assistances = new List<Assistance>();
        #endregion

        #region Properties
        /// Lista de pedidos de assistência associados ao cliente.
        public IReadOnlyList<Assistance> Assistances => _assistances.AsReadOnly();
        #endregion

        #region Constructor
        /// Inicializa um novo cliente.
        public Customer(int id, string name, string email) : base(id, name, email) { }
        #endregion

        #region Methods
        /// <summary>
        /// Adiciona um novo pedido de assistência para o cliente.
        /// </summary>
        /// <param name="assistance">A assistência a adicionar.</param>
        public void AddAssistance(Assistance assistance)
        {
            if (assistance == null)
                throw new ArgumentNullException(nameof(assistance));

            _assistances.Add(assistance); // Adiciona a assistência à lista
        }

        /// <summary>
        /// Remove um pedido de assistência do cliente.
        /// </summary>
        /// <param name="assistance">A assistência a remover.</param>
        public void RemoveAssistance(Assistance assistance)
        {
            if (assistance == null)
                throw new ArgumentNullException(nameof(assistance));

            _assistances.Remove(assistance); // Remove a assistência da lista
        }

        /// <summary>
        /// Apresenta as informações do cliente.
        /// </summary>
        public override void DisplayInfo()
        {
            Console.WriteLine($"Cliente: {Name}, Email: {Email}");
        }
        #endregion
    }
}
