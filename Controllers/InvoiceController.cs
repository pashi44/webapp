using webapp.Models;
using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using webapp.dbdata;
using Microsoft.AspNetCore.Mvc;

namespace webapp.Controllers;


//kind of serice api for the ORM mapping ; well, the DBConteolle
// /maps the dbcontext to the controller

[Route("[Controller]")]
[ApiController]
public   class InvoiceController : Controller{

    private readonly  InvoiceDbContext _context;

    public InvoiceController(InvoiceDbContext context)
    {
        _context = context;
    }

[HttpGet]


public async Task<ActionResult<IEnumerable<Invoice>?>> GetInvoices()
{
    
    if(_context.Invoices == null)return NotFound();//name of the refernce 
    var voices = await _context.Invoices.ToListAsync(); 
    return  voices.Any() ? Ok(voices) : NotFound();
    }


    [HttpGet("{id}")]
    public async Task<ActionResult<Invoice>> GetInvoice([FromRoute] Guid id)
    {
        if (_context.Invoices == null)
        {
            return NotFound();
        }
        // var invoice = await _context.Invoices.FindAsync(id);
        //or         //mapped  the predicate of primary  key id 

        var invoice = await _context.Invoices.SingleAsync(obje =>  obje.Id == id        
         );

         //singleasync maps the predicate of the primary key id and return 
         //that  whoe entity 
        return Ok(invoice);
    }



//singleorDefaultAyync maps the entites with te give predicate
// throws exceptio if multiple entiotes found


    [HttpPut("{id}")]
    public async Task<IActionResult> PutInvoice(Guid id, [FromBody] Invoice
invoice)
    {
        if (id != invoice.Id)
        {
            return BadRequest();
        
        
              }
_context.Entry(invoice).State = EntityState.Modified;
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!InvoiceExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }
        return NoContent();


    }


 [HttpPost]
    public async Task<ActionResult<Invoice>> PostInvoice(Invoice
invoice)
    {
        if (_context.Invoices == null)
        {
            return Problem("Entity set 'InvoiceDbContext.Invoices' is null.");
        }
        _context.Invoices.Add(invoice);
        await _context.SaveChangesAsync();
        return CreatedAtAction("GetInvoice", new
        {
            id = invoice.Id
        }, invoice);
    }


//when we use AsQuerable LINQ method, it returns an IQueryable<T> object,
//



    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteInvoice(Guid id)
    {
        if (_context.Invoices == null)
        {
            return NotFound();
        }
        var invoice = await _context.Invoices.FindAsync(id);

        if (invoice == null)
        {
            return NotFound();
        }
        _context.Invoices.Remove(invoice);
        await _context.SaveChangesAsync();
        return NoContent();
    }



    bool InvoiceExists(Guid id)
    {        return _context.Invoices?.Any(e => e.Id == id) ?? false;

    }





}