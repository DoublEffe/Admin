using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace Admin.Models{

  public class AllEmployeeModel
  {
    [BsonRepresentation(BsonType.ObjectId)]
    public required string Id { get; set; }
    
    public required string Nome { get; set; }
    
    public required  string Cognome { get; set; }
    
    public required  string Ruolo { get; set; }

  }
  
  
}