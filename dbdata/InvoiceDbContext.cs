
using  Microsoft.EntityFrameworkCore;

using  webapp.Models;
namespace  webapp.dbdata;


public class InvoiceDbContext : DbContext
{

    private readonly DbContextOptions<InvoiceDbContext> _options;
    public InvoiceDbContext(DbContextOptions<InvoiceDbContext> options) : base(options)
    {

        _options = options;
    }

    public DbSet<Invoice>? Invoices { get; set; } = null!;

    public DbSet<Post> Posts { get; set; } = null!;


    // public DbSet<Invoice> Invoicesset => Set<Invoice>();// to handle with hull  refernces types
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {



        modelBuilder.Entity<Invoice>().HasData(
        new Invoice
        {
            Id = Guid.NewGuid(),
            InvoiceNumber = "INV-003",
            ContactName = "Mouni",
            Description = "Invoice for the     mouni month",
            Amount = 100000,
            InvoiceDate = new DateTimeOffset(2023, 1, 1, 0, 0, 0,
       TimeSpan.Zero),
            DueDate = new DateTimeOffset(2023, 1, 15, 0, 0, 0,
       TimeSpan.Zero),
            Status = InvoiceStatus.AwaitPayment
        },
        
        new Invoice
        {
            Id= Guid.NewGuid(), 
            InvoiceNumber =  "INV-002",

            Description = "Invoice for the     pashi month",
            Amount = 100000,
            InvoiceDate = new DateTimeOffset(2023, 1, 1, 0, 0, 0,
       TimeSpan.Zero),
            DueDate = new DateTimeOffset(2023, 1, 15, 0, 0, 0,
       TimeSpan.Zero),
            Status = InvoiceStatus.AwaitPayment



        }

        );
    }




}
