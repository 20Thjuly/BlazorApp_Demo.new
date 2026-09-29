namespace eShop.UseCases.ViewProductScreen
{
    public interface IAddProductToCartUseCase
    {
        Task Execute(int productId);
    }
}
