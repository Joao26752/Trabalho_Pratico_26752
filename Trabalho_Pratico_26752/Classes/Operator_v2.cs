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

        public class Operator_v2 : Person
        {
            #region Properties

            /// Turno de trabalho do operador.
            public string Shift { get; private set; } 
            #endregion

            #region Fields
            /// Lista de assistências atribuídas ao operador.
            private readonly List<Assistance> _assignedAssistances = new();
            #endregion

            #region Constructor
            /// Inicializa um novo operador.

            public Operator_v2(int id, string name, string email, string shift) : base(id, name, email)
            {
                Shift = shift;
            }
            #endregion

            #region Methods
            /// Atribui uma assistência ao operador.
            public void AssignAssistance(Assistance assistance)
            {
                assistance.AssignToOperator(this);
                _assignedAssistances.Add(assistance);
            }

  
            /// Retorna todas as assistências atribuídas ao operador.

            public IEnumerable<Assistance> GetAssignedAssistances() => _assignedAssistances.AsReadOnly();

            /// Exibe as informações do operador.
            public override void DisplayInfo()
            {
                Console.WriteLine($"Operador: {Name} (ID: {ID}) - {Email} | Turno: {Shift}");
            }
            #endregion
        }
    }
