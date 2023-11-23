using System.ComponentModel.DataAnnotations;

namespace exeInventario.Models
{
    public class Inventario
    {
        [Key]
        public int ID_Inv {  get; set; }
        public int ID_Cli {  get; set; }
        public string Nome_Cli { get; set; }
        public int ID_Maq { get; set; }
        public string Modelo_Maq { get; set; }
        public int Quantidade { get; set; }
        public float Valor { get; set; }

    }
}
