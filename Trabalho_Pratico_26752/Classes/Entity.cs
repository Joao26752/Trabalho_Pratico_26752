using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabalho_Pratico_26752.Classes;
using Trabalho_Pratico_26752;

namespace Trabalho_Pratico_26752.Classes
{
    
    public abstract class Entity
    {
        #region Properties

        /// Identificador único da entidade.
        private int _id;

        public int Id
        {
            get => _id;
            protected set => _id = value;
        }
        #endregion

        #region Constructor
       
        /// Inicializa uma nova instância de Entity.
        protected Entity(int id)
        {
            _id = id;
        }
        #endregion
    }
}
