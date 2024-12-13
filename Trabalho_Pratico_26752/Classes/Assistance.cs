using System;
using Trabalho_Pratico_26752;
using Trabalho_Pratico_26752.Classes;

namespace Trabalho_Pratico_26752
{
    public class Assistance
    {
        public int AssistanceID { get; set; }
        public DateTime RequestDate { get; set; }
        public AssistanceType Type { get; set; }
        public AssistanceStatus Status { get; set; }
        public Customer Customer { get; set; }
        public Operator Operator { get; set; }
        public Product Product { get; set; }
        public string ProblemDescription { get; set; }
        public KnownProblem RelatedProblem { get; set; }
        public bool ProblemResolved { get; set; }
        public int Rating { get; set; }

        public void LinkKnownProblem(KnownProblem knownProblem)
        {
            if (knownProblem.IsProductAffected(Product))
            {
                RelatedProblem = knownProblem;
            }
        }
    }
}
