using Store;
using Store.Contractors;
using Store.Messages;
using Store.Web.App;
using Store.Web.Contractors;
using Store.YandexKassa;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpContextAccessor();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(20);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});


builder.Services.AddSingleton<BookService>();
builder.Services.AddSingleton<OrderService>();
builder.Services.AddSingleton<INotificationService, DebugNotificationService>();
builder.Services.AddSingleton<IDeliveryService, PostamateDeliveryService>();
builder.Services.AddSingleton<IPaymentService, CashPaymentService>();
builder.Services.AddSingleton<IPaymentService, YandexKassaPaymentService>();
builder.Services.AddSingleton<IWebContractorService, YandexKassaPaymentService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseSession();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "areas",
        pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});

app.Run();
