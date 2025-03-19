using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webapp.Services;
using Serilog;
using Pomelo.EntityFrameworkCore.MySql;

using Microsoft.Extensions.Logging;
using Serilog.Formatting.Json;
using System.IO;
using webapp.dbdata;

var builder = WebApplication.CreateBuilder(args);


// Clear default logging providers and add console logging

builder.Logging.ClearProviders();

builder.Logging.AddConsole();


// Configure Serilog to write logs to a file and console
var log = new LoggerConfiguration()
    .WriteTo.File(new JsonFormatter(),
        Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs/log.txt"),
        rollingInterval: RollingInterval.Day,
        retainedFileCountLimit: 3)
    .WriteTo.Console(new JsonFormatter())
    // .WriteTo.Seq("http://localhost:5341") // Send logs to Seq
    .CreateLogger();

// Add Serilog to the logging pipeline
builder.Logging.AddSerilog(log);
builder.Services.AddDbContext<InvoiceDbContext>(options =>
 options.UseMySql(builder.Configuration.
GetConnectionString("DefaultConnection"), 
serverVersion: ServerVersion.AutoDetect(
    builder.Configuration.GetConnectionString("DefaultConnection"))));

// Register the PostService as a scoped service
builder.Services.AddScoped<IPostService, PostService>();



// var logDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs");


// Additional logging providers (commented out for reference)
// Exceptionless(https://exceptionless.com/)
// ELK Stack(https://www.elastic.co/elastic-stack/)
// Sumo Logic(https://www.sumologic.com/)
// Seq(https://datalust.co/seq)
// Sentry(https://sentry.io)




// builder.Logging.AddDebug();

// builder.Logging.AddEventSourceLogger();



// Add controllers and API explorer for Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(); // Add Swagger

// Add services to the container.
builder.Services.AddControllersWithViews();

// Configure routing to use lowercase URLs
builder.Services.AddRouting(options => options.LowercaseUrls = true);

// Enable endpoint routing
builder.Services.AddMvc(options => options.EnableEndpointRouting = true);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // Enable Swagger and Swagger UI in non-development environments
    app.UseSwagger();
    app.UseSwaggerUI();

    // Use custom error handling
    app.UseExceptionHandler("/Home/Error");

    // Enable HTTP Strict Transport Security (HSTS)
    app.UseHsts();
}

// Redirect HTTP requests to HTTPS
app.UseHttpsRedirection();

// Serve static files
app.UseStaticFiles();

// Enable routing
app.UseRouting();

// Enable authorization
app.UseAuthorization();

// Map default controller route
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Alternative way to map routes (commented out)
// app.UseMvc(routes => routes.MapRoute(
//     name: "default",
//     template: "{Controller=Home}/{Action=Index}/{Id?}"
// ));

// Run the application
app.Run();