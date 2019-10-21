namespace Manusquare.API.Models
{
    public class TransactionalData
    {
        public int TransactionId{ get; set; }
        public int SupplierId{ get; set; }
        public int BuyerId{ get; set; }
        //private int PriceInEuros{ get; set; }
        public PriceClassification PriceClassification{ get; set; }
        public int QualityLikert{ get; set; }
        public int DeliveryTimeLikert{ get; set; }
        public int PackagingLikert{ get; set; }
        public int ResponseRateLikert{ get; set; }
        public int OverallSatesfactionLikert{ get; set; }

        public TransactionalData() {

        }


    }
}