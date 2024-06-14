using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using ampare.api.Models;
using Newtonsoft.Json;

namespace ampare.api.Models
{

[ Table("ProjetoVoluntario")]
public class ProjetoVoluntario{

    public int ProjetoId {get; set;}
    public Projeto Projeto { get; set; }

    public int VoluntarioId { get; set; }
    public Voluntario Voluntario { get; set; }
   
    

}}