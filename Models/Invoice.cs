namespace  webapp.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using Microsoft.EntityFrameworkCore;

//rather than using data annotattion using fluentAPI to check  the types in the LINQ  Methods is 
//better; Even though you use both the flent api  overrides

//  modelBuilder.Entity<Invoice>(b =>
//  {
//  b.ToTable("Invoices");
//  b.HasKey(i => i.Id);
//  b.Property(p => p.Id).HasColumnName("Id");
// b.Property(p => p.InvoiceNumber).
// HasColumnName("InvoiceNumber").HasColumnType("varchar(32)").
// IsRequired();
//  }
[Table("Invoices")]
public class Invoice
{

    [Column("Id")]
 [Key]
    public Guid Id { get; set; }

    [Column(name: "InvoiceNumber", TypeName = "varchar(32)")]
    [Required]
    public string InvoiceNumber { get; set; } = string.Empty;


    [Column(name: "ContactName")]
    [Required]
    [MaxLength(32)]
    public string ContactName { get; set; } = string.Empty;
    [Column(name: "Description")]
 [MaxLength(256)]
    public string? Description { get; set; }

    [Column("Amount")]
    [Precision(18, 2)]
    [Range(0, 9999999999999999.99)]
    public double  Amount { get; set; }
    [Column(name: "InvoiceDate", TypeName = "datetimeoffset")]
    public DateTimeOffset InvoiceDate { get; set; }
    [Column(name: "Status", TypeName = "varchar(16)")]
    public DateTimeOffset DueDate { get; set; }
    [Column(name: "Status", TypeName = "varchar(16)")]
    public InvoiceStatus Status { get; set; }
}

    public enum InvoiceStatus{
        Draft,
        AwaitPayment,
        Paid,
    Overdue,
    Cancelled

};