namespace  webapp.Models;

using System.ComponentModel.DataAnnotations;
using System.IO;


public class Invoice
{
 [Key]
    public Guid Id { get; set; }
    public string InvoiceNumber { get; set; } = string.Empty;
    public string ContactName { get; set; } = string.Empty;
    public string? Description { get; set; }
    public double  Amount { get; set; }
    public DateTimeOffset InvoiceDate { get; set; }
    public DateTimeOffset DueDate { get; set; }
    public InvoiceStatus Status { get; set; }
}

    public enum InvoiceStatus{
        Draft,
        AwaitPayment,
        Paid,
    Overdue,
    Cancelled

};