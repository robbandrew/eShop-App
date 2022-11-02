namespace eShopApp.Web.Api.Products
{
    public static class ProductEndpoints
    {
        private static List<ProductModel> _productModels = new List<ProductModel>
        {
            new ProductModel("itm-001", "Product-001", 10.00m, "This is the product 001"),
            new ProductModel("itm-002", "Product-002", 5.00m, "This is the product 004"),
            new ProductModel("itm-003", "Product-003", 4.00m, "This is the product 003"),
            new ProductModel("itm-004", "Product-004", 3.00m, "This is the product 004"),
            new ProductModel("itm-005", "Product-005", 5.00m, "This is the product 005"),
            new ProductModel("itm-006", "Product-006", 7.00m, "This is the product 006"),
            new ProductModel("itm-007", "Product-007", 12.00m, "This is the product 007")
        };

        public static WebApplication RegisterProductEndpoints(this WebApplication app)
        {
            app.MapGet("/products", async () =>
            {
                return await ListProducts();
            });

            app.MapGet("/product", async (string itemCode) =>

                await GetProduct(itemCode: itemCode) is ProductModel model
                ? Results.Ok(model)
                : Results.NotFound()

            ).Produces<ProductModel>(StatusCodes.Status200OK)
             .Produces(StatusCodes.Status404NotFound);

            return app;
        }

        private static async Task<List<ProductModel>> ListProducts()
        {
            await Task.Delay(0);
            return _productModels;
        }

        private static async Task<ProductModel?> GetProduct(string itemCode)
        {
            await Task.Delay(0);
            var productModel = _productModels.SingleOrDefault(i => i.ItemCode == itemCode);
            return productModel;
        }
    }
}

