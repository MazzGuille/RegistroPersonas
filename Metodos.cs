﻿//LOS "Console.WriteLine();" SON PARA DEJAR ESPACIOS EN BLANCO, SON EQUIVALENTES A UN SALTO DE LINEA 
namespace RegistroPersonas
{
    public class Metodos
    {
        public List<PersonasModel> Lista = new(); //CREAMOS UN OBJETO QUE REPRESENTE LAS PROPIEDADES DE NUESTRO MODELO CON LA FINALIDAD DE USAR LOS METODOS DE LISTA EN LA EJECUCION DEL PROGRAMA
        public List<PersonasModel> CrearPersona(string nombre, string apellido, int dni) //METODO PARA CREAR UN NUEVO REGISTRO, SE TOMA POR PARAMETRO LAS PROPIEDADES QUE CONTIENE EL REGISTRO (ESTAS PROPIEDADES SON LAS MISMAS QUE LAS QUE ESTAN EN NUESTRO MODELO, NO ES NECESARIO QUE LOS NOMBRES SEAN IGUALES, LO HICE POR SIMPLICIDAD)
        {
            Lista.Add(new PersonasModel { Nombre = nombre, Apellido = apellido, DNI = dni }); //USAMOS EL METODO DE "List" LLAMADO "Add" PARA CREAR UN NUEVO REGISTRO, TOMANDO EN CUENTA LOS PRAMETROS DEL NUESTRO METODO "CrearPersona" PARA LLENAR LA LISTA, NOTAR QUE LOS TITULOS EN BALNCO SON PROPIOS DEL MODELO MIENTRAS LOS TITULOS EN AZUL SON PROPIOS DE LOS PARAMETROS DE NUESTRO METODO "CrearPersona"
            return Lista; //DEVOLVEMOS LA LISTA CON EL NUEVO OBJETO
        }

        public void ListarPersonas() //METODO PARA MOSTRAR NUESTRA LISTA
        {
            foreach (var per in Lista) //USAMOS UN CICLO FOREACH PARA MOSTRAR TODOS LOS ELEMENTOS DENTRO DE NUESTRA LISTA
            {
                //ES NEECSARIO ACCEDER A CADA PROPIEDAD DE NUESTRA LISTA
                Console.WriteLine($"Nombre: {per.Nombre}"); 
                Console.WriteLine($"Apellido: {per.Apellido}");
                Console.WriteLine($"DNI: {per.DNI}");
                Console.WriteLine();
            }
        }

        public void EditarPersona(int dni, string nombre, string apellido) // CON ESTE METODO EDITAREMOS LOS REGISTROS DE NUESTRA LISTA, TOMAREMOS EL DNI COMO REFERENCIA PARA ELEGIR QUE REGISTRO EDITAREMOS Y SOLO CAMBIAREMOS EL NOMBRE Y APELLIDO
        {
            PersonasModel persona = Lista.Find(x => x.DNI == dni);//CON EL METODO PROPIO "Find" PERTENECIENTE A "List" FILTRAMOS USANDO UNA EXPRECION LAMBDA DONDE USAREMOS EL PARAMETRO "dni" DE NUESTRO METODO "EditarPersona" PARA UBICAR EL REGISTRO QUE TENGA ESE DNI COMO PROPIEDAD
            persona.Nombre = nombre; //EDITAMOS EL NOMBRE DE LA PERSONA DONDE EL DNI SEA EL QUE LE PASAMOS POR PARAMETRO
            persona.Apellido = apellido; //EDITAMOS EL APELLIDO DE LA PERSONA DONDE EL DNI SEA EL QUE LE PASAMOS POR PARAMETRO

        }

        public void EliminarPersona(int dni) //METODO QUE RECIBE UN NUMERO POR PARAMETRO QUE USAREMOS PARA UBICAR UN REGISTRO EN BASE AL DNI Y ELIMINAR DICHOI REGISTRO
        {
            Lista.RemoveAll(x => x.DNI == dni); // CON EL METODO PROPIO "RemoveAll" DE "LiST" PROCEDEMOS A FILTRAR NUESTRA LISTA USANDO UNA EXPRESION LAMBDA DONDE UBICAREMOS EL DNI PROPORCIONADO EN EL PARAMETRO DE NUESTRO METODO "EliminarPersona" Y PROCEDEMOS A ELIMINAR ESE REGISTRO
        }
    }
}