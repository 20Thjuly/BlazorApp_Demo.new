using eShop.DataStore.HardCoded;
using eShop.UseCases.PluginInterfaces.DataStore;
using eShop.UseCases.SearchProductScreen;
using eShop.UseCases.PluginInterfaces.UI;
using eShop.ShoppingCart.LocalStorage;
using eShop.UseCases.ViewProductScreen;
using eShop.UseCases.ShoppingCartScreen;
using eShop.UseCases.ShoppingCartScreen.interfaces;
using eShop.UseCases.PluginInterfaces.StateStore;
using eShop.StateStore.DI;
using eShop.CoreBusiness.Services;
using eShop.UseCases.OrderConfirmationScreen;
using eShop.UseCases.AdminPortal.OutstandingOrdersScreen;
using eShop.UseCases.AdminPortal.OrderDetailScreen;
using eShop.UseCases.AdminPortal.OrderDetailScreen.Interfaces;
using eShop.UseCases.AdminPortal.ProcessedOrdersScreen;
using eShop.Web.Components;

namespace eShop.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add Razor Components with InteractiveServer
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();

            // Dependency Injection for eShop services & use cases
            builder.Services.AddSingleton<IProductRepository, ProductRepository>();
            builder.Services.AddSingleton<IOrderRepository, OrderRepository>();
            builder.Services.AddTransient<IOrderService, OrderService>();
            builder.Services.AddTransient<ISearchProductUseCase, SearchProductUseCase>();
            builder.Services.AddTransient<IViewProductUseCase, ViewProductUseCase>();
            builder.Services.AddTransient<IAddProductToCartUseCase, AddProductToCartUseCase>();
            builder.Services.AddTransient<IViewShoppingCartUseCase, ViewShoppingCartUseCase>();
            builder.Services.AddTransient<IDeleteProductUseCase, DeleteProductUseCase>();
            builder.Services.AddTransient<IUpdateQuantityUseCase, UpdateQuantityUseCase>();
            builder.Services.AddTransient<IPlaceOrderUseCase, PlaceOrderUseCase>();
            builder.Services.AddTransient<IViewOrderConfirmationUseCase, ViewOrderConfirmationUseCase>();

            builder.Services.AddTransient<IViewOutstandingOrdersUseCase, ViewOutstandingOrdersUseCase>();
            builder.Services.AddTransient<IViewOrderDetailUseCase, ViewOrderDetailUseCase>();
            builder.Services.AddTransient<IProcessOrderUseCase, ProcessOrderUseCase>();
            builder.Services.AddTransient<IViewProcessedOrdersUseCase, ViewProcessedOrdersUseCase>();

            builder.Services.AddScoped<IShoppingCart, eShop.ShoppingCart.LocalStorage.ShoppingCart>();
            builder.Services.AddScoped<IShoppingCartStateStore, ShoppingCartStateStore>();

            // Authentication & Cookie Auth
            builder.Services.AddControllers();
            builder.Services.AddAuthentication("eShop.CookieAuth")
                .AddCookie("eShop.CookieAuth", config => {
                    config.Cookie.Name = "eShop.CookieAuth";
                    config.LoginPath = "/authenticate";
                });
            builder.Services.AddCascadingAuthenticationState();

            var app = builder.Build();

            // Configure HTTP pipeline
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseAntiforgery();

            app.MapControllers();

            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode()
                .AddAdditionalAssemblies(
                    typeof(eShop.Web.CustomerPortal.Pages.SearchProductComponent).Assembly,
                    typeof(eShop.Web.AdminPortal.Pages.OutstandingOrdersComponent).Assembly
                )
                .AllowAnonymous();

            app.Run();
        }
    }
}
