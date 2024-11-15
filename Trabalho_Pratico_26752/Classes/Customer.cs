using System.Collections.Generic;
using Trabalho_Pratico_26752;

namespace HelpdeskSystem.Models
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public List<Assistance> Assistances { get; set; } = new List<Assistance>();

        public void RequestAssistance(Assistance assistance)
        {
            Assistances.Add(assistance);
        }
    }
}