using System.ComponentModel.DataAnnotations;

namespace Manusquare.API.Models
{
    public class Offer
    {
        [Key] public int Id { get; set; }
        public int OrderId { get; set; }
        public int SupplierId { get; set; }
        public double SemanticSimilarity { get; set; }
        public int Price { get; set; }
        public int DistanceInKm { get; set; }
    }
}