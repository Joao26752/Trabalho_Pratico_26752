using System.Collections.Generic;

namespace HelpdeskSystem.Models
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
