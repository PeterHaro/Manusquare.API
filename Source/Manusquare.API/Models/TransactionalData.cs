namespace Manusquare.API.Models
{
    public class TransactionalData
    {
        public int TransactionId;
        public int SupplierId;
        public int BuyerId;
        //private int PriceInEuros;
        public PriceClassification PriceClassification;
        public int QualityLikert;
        public int DeliveryTimeLikert;
        public int PackagingLikert;
        public int ResponseRateLikert;
        public int OverallSatesfactionLikert;

        public TransactionalData() {

        }


    }
}