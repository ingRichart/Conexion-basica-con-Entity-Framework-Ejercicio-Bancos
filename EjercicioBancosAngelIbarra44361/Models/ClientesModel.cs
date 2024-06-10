namespace EjercicioBancosAngelIbarra44361.Models;
public class ClientesModel
{
     public string Name { get; set; }
     public string apellido { get; set; }
        public Guid Id  { get; set; }
        public string Direccion { get; set; }

        public int telefono { get; set; }

        public string email  { get; set; }
}