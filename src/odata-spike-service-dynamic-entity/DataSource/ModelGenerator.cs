using Microsoft.OData.Edm;
using Microsoft.OData.Edm.Library;

namespace odata_spike_service_dynamic_entity.DataSource
{
    public class ModelGenerator
    {
        public EdmModel Model { get; private set; }

        public ModelGenerator()
        {
            Model = new EdmModel();
            
            // Create and add product entity type.
            var product = new EdmEntityType("NS", "Product");
            product.AddKeys(product.AddStructuralProperty("ID", EdmPrimitiveTypeKind.Int32));
            product.AddStructuralProperty("Name", EdmPrimitiveTypeKind.String);
            product.AddStructuralProperty("Price", EdmPrimitiveTypeKind.Double);
            Model.AddElement(product);

          

            // Create and add category entity type.
            var category = new EdmEntityType("NS", "Category");
            category.AddKeys(category.AddStructuralProperty("ID", EdmPrimitiveTypeKind.Int32));
            category.AddStructuralProperty("Name", EdmPrimitiveTypeKind.String);
            Model.AddElement(category);

            // Set navigation from product to category.
            var propertyInfo = new EdmNavigationPropertyInfo();
            propertyInfo.Name = "Category";
            propertyInfo.TargetMultiplicity = EdmMultiplicity.One;
            propertyInfo.Target = category;
            EdmNavigationProperty productCategory = product.AddUnidirectionalNavigation(propertyInfo);

            // Create and add entity container.
            var container = new EdmEntityContainer("NS", "DefaultContainer");
            Model.AddElement(container);

            // Create and add entity set for product and category.
            EdmEntitySet products = container.AddEntitySet("Products", product);
            EdmEntitySet categories = container.AddEntitySet("Categories", category);
            products.AddNavigationTarget(productCategory, categories);

        }
    }
}