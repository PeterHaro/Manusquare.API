using System;
using System.Collections.Generic;
using System.Linq;
using Manusquare.API.Models;
using Microsoft.AspNetCore.Mvc.Formatters.Xml;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Manusquare.API.Database
{
    public class RandomSeed
    {
        private const int NumberOfHistoricalDataEntries = 25000;
        private const int NumberOfBuyers = 10;
        private const int NumberOfSuppliers = 75;
        private static readonly DataGenerationMethodology dataGenerationMethodology = DataGenerationMethodology.Random;
        private static readonly DataGenerationMethodology qualityGenerationMethodology = DataGenerationMethodology.WeightedFirst25Percentile;
        private static readonly DataGenerationMethodology deliveryTimeGenerationMethodology = DataGenerationMethodology.WeightedLast25Percentile;
        private static readonly DataGenerationMethodology packagingGenerationMethodology = DataGenerationMethodology.Random;
        private static readonly DataGenerationMethodology responseRateGenerationMethodology = DataGenerationMethodology.Random;
        private static readonly DataGenerationMethodology overallSatesfactionGenerationMethodology = DataGenerationMethodology.Random;

        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MatchmakingContext(
                serviceProvider.GetRequiredService<DbContextOptions<MatchmakingContext>>()))
            {
                // Look for any board games already in database.
                if (context.TransactionalData.Any())
                {
                    return; // Database has been seeded
                }
                List<Buyer> buyers = Enumerable.Range(0, NumberOfBuyers).Select(i => new Buyer(i)).ToList();
                List<Supplier> suppliers = Enumerable.Range(0, NumberOfSuppliers).Select(i =>
                    new Supplier(i, GenerateRandomNumberInRange(0, 100), GenerateRandomNumberInRange(0, 100), GenerateRandomNumberInRange(2, 500))).ToList();

                List<TransactionalData> transactionalData = new List<TransactionalData>();
                for (int i = 0; i < NumberOfHistoricalDataEntries; i++)
                {
                    TransactionalData datum = new TransactionalData
                    {
                        TransactionId = i,
                        SupplierId = GenerateSupplierId(i),
                        BuyerId = GenerateBuyerId(i),
                        PriceClassification = GetRandomPrice(i),
                        QualityLikert = GenerateQualityLikertValues(i),
                        DeliveryTimeLikert = GenerateDeliveryTimeLikertValue(i),
                        PackagingLikert = GeneratePackagingLikertvalue(i),
                        ResponseRateLikert = GenerateResponseRateLikertValue(i),
                        OverallSatesfactionLikert = GenerateOverallSatesfactionLikertValue(i)
                    };
                    transactionalData.Add(datum);

                    foreach(var buyer in buyers)
                    {
                        if (buyer.Id == datum.BuyerId)
                        {
                            buyer.AddTransactionalData(datum);
                        }
                    }
                }

                context.AddRange(suppliers);
                context.AddRange(transactionalData);
                context.AddRange(buyers);

                context.SaveChanges();
            }
        }

        // TODO: MAKE DIFFERENT WEIGHTED MODES
        private static PriceClassification GetRandomPrice(int seed) {
            int rand = GenerateRandomNumberInRange(0, 2);
            switch (rand) {
                case 1:
                    return PriceClassification.Median;
                case 2:
                    return PriceClassification.High;
                case 0:
                default:
                    return PriceClassification.Low;
            }
        }

        private static int GenerateBuyerId(int seed) {
            return GenerateRandomNumberFromGivenDistribution(seed, NumberOfBuyers);
        }

        private static int GenerateSupplierId(int seed) {
            return GenerateRandomNumberFromGivenDistribution(seed, NumberOfSuppliers);
        }

        private static int GenerateOverallSatesfactionLikertValue(int seed) {
            return GenerateRandomLikertNumberFromMethodology(seed, overallSatesfactionGenerationMethodology);
        }

        private static int GenerateResponseRateLikertValue(int seed) {
            return GenerateRandomLikertNumberFromMethodology(seed, responseRateGenerationMethodology);
        }

        private static int GenerateDeliveryTimeLikertValue(int seed) {
            return GenerateRandomLikertNumberFromMethodology(seed, deliveryTimeGenerationMethodology);
        }

        private static int GeneratePackagingLikertvalue(int seed) {
            return GenerateRandomLikertNumberFromMethodology(seed, packagingGenerationMethodology);
        }

        private static int GenerateQualityLikertValues(int seed) {
            return GenerateRandomLikertNumberFromMethodology(seed, qualityGenerationMethodology);
        }

        private static int GenerateRandomLikertNumberFromMethodology(int seed, DataGenerationMethodology methodology) {
            switch (methodology) {
                case DataGenerationMethodology.Sequential:
                    if (seed == 0) {
                        return 1;
                    }
                    return seed % 5;
                case DataGenerationMethodology.Random:
                    return GenerateRandomNumberInRange(1, 5);
                case DataGenerationMethodology.WeightedFirst25Percentile:
                    int randomNum = GenerateRandomNumberInRange(1, 5);
                    int bottom_weight = 3;
                    if (randomNum <= bottom_weight) {
                        return GenerateRandomNumberInRange(1, 2);
                    }
                    return GenerateRandomNumberInRange(1, 5);
                case DataGenerationMethodology.WeightedLast25Percentile:
                    int randomNumber = GenerateRandomNumberInRange(1, 5);
                    int top_wiegth = 3;
                    if (randomNumber >= top_wiegth) {
                        return GenerateRandomNumberInRange(4, 5);
                    }
                    return GenerateRandomNumberInRange(1, 5);
            }
            return seed;
        }

        private static int GenerateRandomNumberFromGivenDistribution(int seed, int max_range) {
            switch (dataGenerationMethodology) {
                case DataGenerationMethodology.Sequential:
                    return seed;
                case DataGenerationMethodology.Random:
                    return GenerateRandomNumberInRange(0, (max_range - 1));
                case DataGenerationMethodology.WeightedFirst25Percentile:
                    int twentyFifthPercentile = (int)Math.Round((double)max_range / 4);
                    int random_num = GenerateRandomNumberInRange(0, max_range);
                    if (random_num < twentyFifthPercentile) {
                        return GenerateRandomNumberInRange(0, twentyFifthPercentile);
                    }
                    return GenerateRandomNumberInRange(0, (max_range - 1));
                default:
                    throw new ArgumentException("The data generation methodology requires a fixed method");
            }
        }

        public static int GenerateRandomNumberInRange(int minNumber, int maxNumber)
        {
            return new Random().Next() * (maxNumber - minNumber) + minNumber;
        }
    }
}
