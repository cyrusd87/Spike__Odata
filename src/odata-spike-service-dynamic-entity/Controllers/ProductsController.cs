using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.OData;
using Microsoft.OData.Edm;
using odata_spike_service_dynamic_entity.DataSource;

namespace odata_spike_service_dynamic_entity.Controllers
{

    [EnableQuery]
    public class ProductsController : ODataController
    {
        public IHttpActionResult Get()
        {
            var products = new List<object>();
            foreach (var edmEntityObject in Products)
            {
                object id = null;
                edmEntityObject.TryGetPropertyValue("Id", out id);

                object name = null;
                edmEntityObject.TryGetPropertyValue("Name", out name);

                object price = null;
                edmEntityObject.TryGetPropertyValue("Price", out price);

                products.Add(new {Id = id, Name=name, Price = price});
            }


            return Ok(products.ToArray().AsQueryable());
        }

        private static readonly IQueryable<IEdmEntityObject> Products = Enumerable.Range(0, 10).Select(i =>
        {
            IEdmEntityType productType = (IEdmEntityType)new ModelGenerator().Model.FindType("NS.Product");
            IEdmEntityTypeReference categoryType = (IEdmEntityTypeReference)productType.FindProperty("Category").Type;

            EdmEntityObject product = new EdmEntityObject(productType);
            product.TrySetPropertyValue("ID", i);
            product.TrySetPropertyValue("Name", "Product " + i);
            product.TrySetPropertyValue("Price", i + 0.01);

            EdmEntityObject category = new EdmEntityObject(categoryType);
            category.TrySetPropertyValue("Id", i % 5);
            category.TrySetPropertyValue("Name", "Category " + (i % 5));
            product.TrySetPropertyValue("Category", category);

            return product;

        }).AsQueryable();
    }

}