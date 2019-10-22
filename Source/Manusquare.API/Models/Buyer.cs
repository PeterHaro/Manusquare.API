using System.Collections.Generic;
using Manusquare.API.Infrastructure;

namespace Manusquare.API.Models
{
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