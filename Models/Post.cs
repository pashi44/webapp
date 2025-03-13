using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using System.ComponentModel.DataAnnotations;


namespace webapp.Models;


  public class Post



  {
  
  public int Id { get; set; }
    public String? Name { get; set; } = string.Empty;
    public string? Email { get; set; } =  string.Empty;

    public string? Phone { get; set; }  =  string.Empty;
    public bool? WillAttend { get; set; }

public DateOnly Date {get;set;}                                                                                           



  }

