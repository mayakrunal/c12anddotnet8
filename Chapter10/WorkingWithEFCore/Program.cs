ConfigureConsole();
//QueryingCategories();
//FilteredIncludes();
//QueryingProducts();
//GettingOneProduct();
// QueryingWithLike();
//GetRandomProduct();


var (affected, productId) = AddProduct(categoryId: 6, productName: "Bob's Burgers", price: 500M, stock: 72);

if (affected == 1)
{
    WriteLine($"Add product successful with ID: {productId}.");
}

ListProducts([productId]);


/* var (affected, productId) = IncreaseProductPrice(productNameStartsWith: "Bob", amount: 20M);

if (affected == 1)
{
    WriteLine($"Increase price success for ID: {productId}.");
}

ListProducts(productIdsToHighlight: [productId]);
 */

var resultUpdateBetter = IncreaseProductPricesBetter(productNameStartsWith: "Bob", amount: 20M);
if (resultUpdateBetter.affected > 0)
{
    WriteLine("Increase product price successful.");
}
ListProducts(productIdsToHighlight: resultUpdateBetter.productIds);


WriteLine("About to delete all products whose name starts with Bob.");
Write("Press Enter to continue or any other key to exit: ");
if (ReadKey(intercept: true).Key == ConsoleKey.Enter)
{
    int deleted = DeleteProductsBetter(productNameStartsWith: "Bob");

    WriteLine($"{deleted} product(s) were deleted.");
}
else
{
    WriteLine("Delete was canceled.");
}

