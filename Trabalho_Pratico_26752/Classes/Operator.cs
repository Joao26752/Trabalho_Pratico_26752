using System.Collections.Generic;
using Trabalho_Pratico_26752;
using Trabalho_Pratico_26752.Classes;

namespace Trabalho_Pratico_26752.Classes
{
    public class Operator
    {
        public int OperatorID { get; set; }
        public string Name { get; set; }
        public string Shift { get; set; }
        public List<Assistance> Assistances { get; set; } = new List<Assistance>();

        public void AssignAssistance(Assistance assistance)
        {
            assistance.Operator = this;
            assistance.Status = AssistanceStatus.InProgress;
            Assistances.Add(assistance);
        }

        public void ResolveAssistance(Assistance assistance, bool problemResolved, int rating)
        {
            assistance.ProblemResolved = problemResolved;
            assistance.Status = AssistanceStatus.Closed;
            assistance.Rating = rating;
        }
    }
}
