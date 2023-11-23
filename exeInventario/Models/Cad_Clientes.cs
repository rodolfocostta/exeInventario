using System.ComponentModel.DataAnnotations;

namespace exeInventario.Models
{
    public class Cad_Clientes
    {
        [Key]
        public int ID_Cli {  get; set; }  
        public string Nome_Cli {  get; set; } 
        public string Telelfone_Cli {  get; set; } 
        public string Email_Cli { get; set; }
    }
}
