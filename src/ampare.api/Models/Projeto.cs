using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using ampare.api.Models;
using Newtonsoft.Json;


[ Table("Projetos")]
public class Projeto {

    [Key]
    public int ProjetoId {get; set;}

    
    public int OngId {get; set;}

        [Required]
    public string ProjectName {get; set;}
    
    


  
    public DateTime CreatedAt {get;set;}

   
    public string Description {get;set;}

    public ICollection<ProjetoVoluntario> ProjetoVoluntario { get; set; }

    
    public enum HelpNeeded {
        Doação,
        Transporte, 
        AjudaNoLocal,
        Limpeza,
        Outro
    }


}