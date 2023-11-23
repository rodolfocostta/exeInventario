using System.ComponentModel.DataAnnotations;

namespace exeInventario.Models
{
    public class Cad_Maquinas
    {
        [Key]
        public int ID_Maq { get; set; }

        public string Modelo_Maq { get; set; }

        public string Peças_Maq { get; set; }
    }
}
