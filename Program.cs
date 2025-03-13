using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(); // Add Swagger


// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddRouting(options => options.LowercaseUrls = true);

builder.Services.AddMvc(options => options.EnableEndpointRouting = true




);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{


    app.UseSwagger(); // Enable Swagger
    app.UseSwaggerUI(); // Enable Swagger UI
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
// 
app.UseAuthorization();
// 
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
// 
// app.UseMvc(routes => routes.MapRoute(
// 
// 
// 
    // name: "default",
    // template: "{Controller=Home}/{Action=Index}/{Id?}"
// ));


app.Run();
