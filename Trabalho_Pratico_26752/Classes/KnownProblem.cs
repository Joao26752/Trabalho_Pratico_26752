using System.Collections.Generic;
using Trabalho_Pratico_26752.Classes;
using Trabalho_Pratico_26752;

namespace Trabalho_Pratico_26752.Classes
{
    public class KnownProblem
    {
        public int ProblemID { get; set; }
        public string Description { get; set; }
        public string Solution { get; set; }
        public List<Product> AffectedProducts { get; set; } = new List<Product>();

        public bool IsProductAffected(Product product)
        {
            return AffectedProducts.Contains(product);
        }
    }
}
