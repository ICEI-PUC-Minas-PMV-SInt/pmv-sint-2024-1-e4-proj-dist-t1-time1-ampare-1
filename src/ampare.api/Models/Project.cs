using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using ampare.api.Models;
using Newtonsoft.Json;


[ Table("Projetos")]
public class Project {

    [Key]
    public int Id {get; set;}

    [Required]
    public int OngId {get; set;}

        [Required]
    public string ProjectName {get; set;}
    
    [Required]
    public Ong Ong {get;set;}
    // navegação virtual para carregar e trazer informações da classe Ong relacionada ao projeto


    [Required]
    public DateTime CreatedAt {get;set;}

    [Required]
    public string Description {get;set;}

    
    public enum HelpNeeded {
        Doação,
        Transporte, 
        AjudaNoLocal,
        Limpeza,
        Outro
    }


}