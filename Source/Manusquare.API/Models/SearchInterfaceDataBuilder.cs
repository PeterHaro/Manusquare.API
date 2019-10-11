using System;
using Manusquare.API.Utilities;

namespace Manusquare.API.Models
{
    public class SearchInterfaceDataBuilder
    {
        private int qualityOfProjectResultsImportance;
        private int onTimeDeliveryImportance;
        private int communicationAndCollaberationEffectivenessImportance;
        private int searchRadius;
        private int profileRankingImportance; //TODO: CONSIDER CLASSIFYING THIS
        private int sustainabilityRanking; // TODO: CONMSIDERING CLASSYFING THISA
        private int priceRange; // TODO: CONSIDER CLASSIFY YO

        public SearchInterfaceDataBuilder SetQualityOfProjectResultsImportance(int qualityOfProjectResultsImportance)
        {
            if (!ManusquareUtility.InRange(qualityOfProjectResultsImportance, 0, 5))
            {
                throw new ArgumentException("Quality of project result importance must be from 0 to 5");
            }

            this.qualityOfProjectResultsImportance = qualityOfProjectResultsImportance;
            return this;
        }

        public SearchInterfaceDataBuilder SetOnTimeDeliveryImportance(int onTimeDeliveryImportance)
        {
            if (!ManusquareUtility.InRange(onTimeDeliveryImportance, 0, 5))
            {
                throw new ArgumentException("On time delivery importance must be from 0 to 5");
            }

            this.onTimeDeliveryImportance = onTimeDeliveryImportance;
            return this;
        }

        public SearchInterfaceDataBuilder SetCommunicationAndCollaberationEffectivenessImportance(int communicationAndCollaberationEffectivenessImportance)
        {
            if (!ManusquareUtility.InRange(communicationAndCollaberationEffectivenessImportance, 0, 5))
            {
                throw new ArgumentException("Communication and collaboration importance must be from 0 to 5");
            }

            this.communicationAndCollaberationEffectivenessImportance = communicationAndCollaberationEffectivenessImportance;
            return this;
        }

        public SearchInterfaceDataBuilder SetSearchRadius(int searchRadius)
        {
            this.searchRadius = searchRadius;
            return this;
        }

        public SearchInterfaceDataBuilder SetProfileRankingImportance(int profileRankingImportance)
        {
            if (ManusquareUtility.InRange(profileRankingImportance, 0, 100))
            {
                this.profileRankingImportance = profileRankingImportance;
                return this;
            }

            throw new ArgumentException("Profile ranking can only be from 0 to 100");
        }

        public SearchInterfaceDataBuilder SetSustainabilityRanking(int sustainabilityRanking)
        {
            if (ManusquareUtility.InRange(sustainabilityRanking, 0, 100))
            {
                this.sustainabilityRanking = sustainabilityRanking;
                return this;
            }

            throw new ArgumentException("Sustainability ranking can only be from 0 to 100");
        }

        public SearchInterfaceDataBuilder SetPriceRange(int priceRange)
        {
            this.priceRange = priceRange;
            return this;
        }

        public SearchInterfaceData CreateSearchInterfaceData()
        {
            return new SearchInterfaceData(this.qualityOfProjectResultsImportance, this.onTimeDeliveryImportance, this.communicationAndCollaberationEffectivenessImportance, this.searchRadius,
                this.profileRankingImportance, this.sustainabilityRanking, this.priceRange);
        }
    }
}