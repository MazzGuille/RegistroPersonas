namespace RegistroPersonas
{
    public class PersonasModel //CREAMOS EL MODELO BASE CON LAS PROPIEDADES QUE TENDRA CADA REGISTRO/PERSONA
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int DNI { get; set; }
    }
}
