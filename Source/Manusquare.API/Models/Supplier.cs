using System;
using System.Text;

namespace Manusquare.API.Models
{
    public class Supplier
    {
        public int Id { get; set; }
        public  int ProfileRanking { get; set; }
        public  int SustainabilityRanking { get; set; }
        public  int DistanceFromBuyerInKm { get; set; } //TODO: FIXME: I am just mocking this for now as I dont bother setting up random areas in some GEO area and converting coords to km etc etc

        public Supplier()
        {

        }

        public Supplier(int id, int profileRanking, int sustainabilityRanking, int distanceFromBuyerInKm) {
            this.Id = id;
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
            return Id;
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