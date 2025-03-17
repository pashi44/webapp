using Microsoft.AspNetCore.Mvc;
using webapp.Services;


using Serilog;
using Microsoft.Extensions.Logging;
using Serilog.Formatting.Json;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IPostService, PostService>();

builder.Logging.ClearProviders();
builder.Logging.AddConsole();
// builder.Logging.AddDebug();
// builder.Logging.AddEventSourceLogger();

//sinking log  events to the log dir with  serilog: ISerilog 

// and also  we define sinks with nlog and log4net nugets log providers
var log = new LoggerConfiguration().WriteTo.File(
    Path.Combine(path1: AppDomain.CurrentDomain.BaseDirectory, path2: "logs/log.txt"),
    rollingInterval: RollingInterval.Day, retainedFileCountLimit: 3).
    WriteTo.Console(new JsonFormatter())
    .CreateLogger();
builder.Logging.AddSerilog(log);

// Exceptionless(https://exceptionless.com/)
// •
// ELK Stack(https://www.elastic.co/elastic-stack/)
// •
// Sumo Logic(https://www.sumologic.com/)
// •
// Seq(https://datalust.co/seq)
// •
// Sentry(https://sentry.io)
//the  above log provides   also provides dash boards for the  event logs 


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
