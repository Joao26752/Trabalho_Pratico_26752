using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabalho_Pratico_26752.Classes;

namespace Trabalho_Pratico_26752.Classes
{
    /// Representa uma solicitação de assistência.
        public class Assistance : Entity
        {
            #region Properties
            public DateTime RequestDate { get; private set; }
            public AssistanceType Type { get; private set; }
            public AssistanceStatus Status { get; private set; }
            public string Description { get; private set; }
            public Customer Customer { get; private set; }
            public Operator Operator { get; private set; }
            #endregion

            #region Constructor
            public Assistance(int id, Customer customer, AssistanceType type, string description) : base(id)
            {
                Customer = customer;
                Type = type;
                Description = description;
                RequestDate = DateTime.Now;
                Status = AssistanceStatus.Open;
            }
            #endregion

            #region Methods
            public void AssignToOperator(Operator op)
            {
                Operator = op;
                Status = AssistanceStatus.InProgress;
            }

            public void CloseAssistance(bool resolved)
            {
                Status = AssistanceStatus.Closed;
            }
            #endregion
        }

        public enum AssistanceType
        {
            TechnicalSupport,
            ProductExchange,
            Installation
        }

        public enum AssistanceStatus
        {
            Open,
            InProgress,
            Closed
        }
    }
