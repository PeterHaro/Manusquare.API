using System.Collections.Generic;

namespace Manusquare.API.Models
{
    public class Buyer
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