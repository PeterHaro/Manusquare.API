namespace Manusquare.API.Models
{
    public class SearchInterfaceData
    {
        private int QualityOfProjectResultsImportance;
        private int OnTimeDeliveryImportance;
        private int CommunicationAndCollaberationEffectivenessImportance;
        private int SearchRadius;
        private int ProfileRankingImportance;
        private int SustainabilityRanking;
        private int PriceRange;

        public SearchInterfaceData(int qualityOfProjectResultsImportance, int onTimeDeliveryImportance, int communicationAndCollaberationEffectivenessImportance, int searchRadius, int profileRankingImportance, int sustainabilityRanking, int priceRange) {
            this.QualityOfProjectResultsImportance = qualityOfProjectResultsImportance;
            this.OnTimeDeliveryImportance = onTimeDeliveryImportance;
            this.CommunicationAndCollaberationEffectivenessImportance = communicationAndCollaberationEffectivenessImportance;
            this.SearchRadius = searchRadius;
            this.ProfileRankingImportance = profileRankingImportance;
            this.SustainabilityRanking = sustainabilityRanking;
            this.PriceRange = priceRange;
        }
    }
}