using System.ComponentModel.DataAnnotations;


namespace Admin.Models{
  public class EmployeeModel
  {
      [Required]
      public required string Nome { get; set; }
      [Required]
      public required string Cognome { get; set; }
      [Required]
      public required string Ruolo { get; set; }

    
  }
  
}