using System;
using System.Text;

namespace Manusquare.API.Models
{
    public class Supplier
    {
        public int SupplierId;
        public  int ProfileRanking;
        public  int SustainabilityRanking;
        public  int DistanceFromBuyerInKm; //TODO: FIXME: I am just mocking this for now as I dont bother setting up random areas in some GEO area and converting coords to km etc etc

        public Supplier(int supplierId, int profileRanking, int sustainabilityRanking, int distanceFromBuyerInKm) {
            SupplierId = supplierId;
            ProfileRanking = profileRanking;
            SustainabilityRanking = sustainabilityRanking;
            DistanceFromBuyerInKm = distanceFromBuyerInKm;
        }

        public string getSupplierInfo() {
            StringBuilder sb = new StringBuilder();
            sb.Append("Dumping information for supplier: ").Append(getSupplierId()).Append(Environment.NewLine);
            sb.Append("\t Profile ranking: ").Append(ProfileRanking).Append(Environment.NewLine);
            sb.Append("\t SustainabilityRanking: ").Append(SustainabilityRanking).Append(Environment.NewLine);
            sb.Append("\t Distance from buyer in km: ").Append(DistanceFromBuyerInKm);
            return sb.ToString();
        }

        public int getSupplierId() {
            return SupplierId;
        }

        public int getProfileRanking() {
            return ProfileRanking;
        }

        public int getSustainabilityRanking() {
            return SustainabilityRanking;
        }

        public int getDistanceFromBuyerInKm() {
            return DistanceFromBuyerInKm;
        }
    }
}