using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabalho_Pratico_26752.Classes;
using Trabalho_Pratico_26752;

namespace Trabalho_Pratico_26752.Classes
{
  
    /// Classe abstrata que representa uma pessoa no sistema.
   
    public abstract class Person : Entity
    {
        #region Properties

       
        public string Name { get; private set; }     
        public string Email { get; private set; }   
        #endregion

        #region Constructor
        /// Inicializa uma nova instância de Person.
        protected Person(int id, string name, string email) : base(id)
        {
            Name = name;
            Email = email;
        }
        #endregion

        #region Methods
        /// Exibe as informações da pessoa.
        public abstract void DisplayInfo();
        #endregion
    }
}
