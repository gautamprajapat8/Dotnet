var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// New route to handle blog posts with friendly URLs
app.MapControllerRoute(
    name: "blog",
    pattern: "Blog/{id}/{slug}",
    defaults: new { controller = "Blog", action = "Post" }
);

app.MapControllerRoute(
    name: "blogList",
    pattern: "Blog/List",
    defaults: new { controller = "Blog", action = "List" }
);



app.MapControllerRoute(
    name: "error",
    pattern: "{*url}",
    defaults: new { controller = "Home", action = "Error" }
);



app.Run();
