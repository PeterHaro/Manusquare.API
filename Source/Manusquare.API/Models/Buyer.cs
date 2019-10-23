using System.Collections.Generic;
using Manusquare.API.Infrastructure;
using Manusquare.API.ViewModelSchemaFilters;
using Swashbuckle.AspNetCore.Annotations;

namespace Manusquare.API.Models
{
    [SwaggerSchemaFilter(typeof(BuyerSchemaFilter))]
    public class Buyer : BaseEntity
    {
        public int Id { get; set; }
        public List<TransactionalData> HistoricalData { get; set; }

        public Buyer(int id)
        {
            Id = id;
        }

        public void AddTransactionalData(TransactionalData datum)
        {
            if (HistoricalData == null)
            {
                HistoricalData = new List<TransactionalData>();
            }
            HistoricalData.Add(datum);
        }
    }
}