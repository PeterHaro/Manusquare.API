using System.Collections.Generic;
using Manusquare.API.Models;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Manusquare.API.ViewModelSchemaFilters
{
    public class BuyerSchemaFilter : ISchemaFilter
    {
        public void Apply(Schema model, SchemaFilterContext context)
        {
            List<Buyer> buyers = new List<Buyer>();
            buyers.Add(new Buyer(5));
            model.Default = buyers;
            model.Example = buyers;
        }
    }
}