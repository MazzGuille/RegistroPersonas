using RegistroPersonas;
using System.Linq;
using System.Net;
//LOS "Console.WriteLine();" SON PARA DEJAR ESPACIOS EN BLANCO, SON EQUIVALENTES A UN SALTO DE LINEA 

PersonasModel persona = new();
Metodos obj = new(); //CREAMOS UN OBJETO DE NUESTRA CLASE "Metodos" PARA PODER ACCERDER A LOS METODOS QUE CREAMOS AHI(CREAR, LISTAR, EDITAR Y ELIMINAR RESGISTROS)

bool main = true; //VARIABLE CONDICIONAL PARA EL METODO WHILE GLOBAL

bool programa = true; //VARIABLE CONDICIONAL PARA EL METODO WHILE INTERNO

while (main)
{
    try
    {
        while (programa) // MIETRAS LA VARIABLE SEA "true" NUESTRO PROGRAMA SEGUIRA CORRIENDO (SE DEBE CREAR ALGUNA CONDICION EN EL PROGRAMA DONDE LA VARIBLE CAMBIE A "false" DE LO CONTRARIO SE CREAR UN BUCLE INIFNITO Y NUNCA FINALIZARA EL PROGRAMA
        {
            //CON ESTE PRIMER BLOQUE LE INDICAMOS AL USUARIO QUE INGRESE QUE DESEA HACER USANDO ALGUN NUMERO DEL 1-5
            Console.WriteLine("Elige una de las siguientes opciones:");
            Console.WriteLine("1. Registrar persona nueva");
            Console.WriteLine("2. Listar personas");
            Console.WriteLine("3. Editar persona por DNI");
            Console.WriteLine("4. Eliminar persona por DNI");
            Console.WriteLine("5. Salir");
            int res = int.Parse(Console.ReadLine()); //ACA LEEMOS LA RESPUESTA DEL USUARIO Y LA ALMACENAMOS EN UNA VARIABLE DE NOMBRE "res" Y COMO VIENE EN UN FORMATO string DEBEMOS USAR EL Int.Parse PARA CONVERTIRLA EN ENTERO Y QUE PODAMOS INDICARLE AL PROGRAMA QUE HACER EN BASE A ESA RESPUESTA
            Console.WriteLine();

            if (res == 1)
            {
                try
                {
                    // SI LA RESPUESTA ES "1" PROCEDEMOS A PEDIRLE LOS DATOS NECESARIOS AL USUARIO PARA LLENAR LOS PARAMETROS DE NUESTRO METODO "CrearPersona"
                    bool per = true; //ESTA VARIABLE JUNTO AL CICLO WHILE QUE COMIENZA EN LA SIGUIENTE LINEA, LO USARERMOS PARA QUE EL USUARIO CONTINUE AGRGANDO REGISTROS CUANTAS VECES DESEE
                    while (per)
                    {
                        //ALMACENAMOS LAS RESPUESTAS DEL USUARIO EN DISTINTAS VARIABLES PARA LUEGO USAR ESAS VARIABLES EN CONJUNTO CON NUESTRO METODO "CrearPersona"
                        Console.WriteLine("Ingrese el nombre de la persona a registrar");
                        string nombre = Console.ReadLine();
                        Console.WriteLine();

                        Console.WriteLine("Ingrese el apellido de la persona a registrar");
                        string apellido = Console.ReadLine();
                        Console.WriteLine();

                        Console.WriteLine("Ingrese el DNI de la persona a registrar");
                        int dni = int.Parse(Console.ReadLine());
                        Console.WriteLine();

                        obj.CrearPersona(nombre, apellido, dni); //LLAMAMOS A NUESTRO METODO "CrearPersona" JUNTO CON LAS VARIBLES INTRODUCIDAS POR EL USUARIO PARA CREAR UN NUEVO REGISTRO
                        if (nombre == string.Empty || apellido == string.Empty)
                        {
                            Console.WriteLine("Datos incompletos, no se agregara el registro a la lista");
                            obj.EliminarPersona(dni);
                        }
                        else
                        {
                            Console.WriteLine("Se registro a la persona con exito");
                        }
                        Console.WriteLine();

                        bool reg = true;
                        while (reg)
                        {
                            //MIENTRAS EL USUARIO QUIERA SEGUIR AGREGANDO REGISTROS, EL WHILE CREADO EN LA LINEA 22 SE SEGUIRA REPITIENDO, SOLO CUANDO EL USUARIO INDIQUE CON UNA "n" O "N" CESARA EL BUCLE DE CREAR USAURIOS
                            Console.WriteLine("Desea agregar otro registro? (S/N)");
                            string respuesta = Console.ReadLine().ToLower();//USAMOS EL METODO "ToLower" PARA ASEGURAR QUE LA VARIABLE "respuesta" SIEMPRE ALMACENE EN MINUSCULA
                            Console.WriteLine();
                            if (respuesta == "n")//ACA CREAMOS LA CONDICION PARA TERMINAR EL CICLO WHILE DE CREACION DE REGISTRO, POR ESO ES NECESARIO USAR EL METODO "ToLower" EN LA SECCION ANTERIOR
                            {
                                per = false;
                                reg = false;
                            }
                            else if (respuesta == "s") //SI EL USUARIO INTRODUCE "S", CAEMOS EN ESTA CONDICION Y SE REINICIA EL CICLO WHILE DE LA VARIABLE "per"
                            {
                                per = true;
                                reg = false;
                            }
                            else //SI EL USUARIO INTRODUCE ALGUN VALOR QUE NO SEA "s" O "n", CAEMOS EN ESTA CONDICION Y SE REINICIA EL CICLO WHILE DE LA VARIABLE "reg"
                            {
                                Console.WriteLine("Has introducido una opcion incorrecta, por favor, intenta nuevamente");
                                reg = true;
                            }
                            Console.WriteLine();
                        }
                    }
                    //CUANDO EL USUARIO DECIDA QUE TERMINO DE CREAR REGISTROS, VOLVEMOS AL CICLO WHILE DE LA VARIABLE "programa" Y SE VUELVEN A MOSTRAR LAS 5 OPCIONES PRINCIPALES DEL PROGRAMA
                }
                catch (Exception)
                {
                    Console.WriteLine("El campo \"DNI\" no puede estar vacio, no se agregara el registro a la lista");
                    Console.WriteLine();
                }

            }

            else if (res == 2)
            {
                try
                {
                    obj.ListarPersonas(); //LLAMAMOS A NUESTRO METODO "ListarPersonas"
                    if (obj.Lista.Count == 0)
                    {
                        Console.WriteLine("La lista se encuentra vacia");
                        Console.WriteLine();
                    }
                }
                catch (Exception e)
                {
                    string error = e.ToString();
                    Console.WriteLine(error);
                    Console.WriteLine();
                }

            }

            else if (res == 3)
            {
                //CON ESTE BLOQUE DE CODIGO LE PEDIMOS LOS DATOS NECESARIOS AL USUARIO PARA TOMARLOS COMO PARAMTROS EN NUETRO METODO "EditarPersona"
                try
                {
                    int dni = 0;
                    bool x = true;
                    while (x)
                    {
                        Console.WriteLine("Indique el DNI del registro a editar");
                        dni = int.Parse(Console.ReadLine());
                        PersonasModel per = obj.Lista.Where(p => p.DNI == dni).FirstOrDefault();
                        if (per == null)
                        {
                            Console.WriteLine("El DNI introducido no existe, introduce un DNI correcto por favor");
                        }
                        else
                        {
                            x = false;
                        }
                        Console.WriteLine();
                    }


                    Console.WriteLine("Indique el nuevo nombre. Si no desea alteral el nombre, dejar el campo vacio");
                    string nombre = Console.ReadLine();
                    string nombre2 = obj.Lista.Where(p => p.DNI == dni).Select(p => p.Nombre).FirstOrDefault();
                    if (nombre == string.Empty)
                    {
                        nombre = nombre2;
                    }
                    Console.WriteLine();

                    Console.WriteLine("Indique el nuevo apellido. Si no desea alteral el apellido, dejar el campo vacio");
                    string apellido = Console.ReadLine();
                    string apellido2 = obj.Lista.Where(p => p.DNI == dni).Select(p => p.Apellido).FirstOrDefault();
                    if (apellido == string.Empty)
                    {
                        apellido = apellido2;
                    }
                    Console.WriteLine();

                    obj.EditarPersona(dni, nombre, apellido); //LLAMAMOS A NUESTRO METODO "EditarPersona" USANDO COMO PARAMETRO LA RESPUESTA DEL USAURIO

                    Console.WriteLine("Se ha editado el registro con exito");
                    Console.WriteLine();

                }
                catch (Exception)
                {
                    Console.WriteLine("El campo \"DNI\" no puede estar vacio");
                    Console.WriteLine();
                }
            }

            else if (res == 4)
            {
                try
                {
                    int dni = 0;
                    bool x = true;
                    while (x)
                    {
                        Console.WriteLine("Indique el DNI del registro a eliminar");
                        dni = int.Parse(Console.ReadLine()); //ACA LEEMOS LA RESPUESTA DEL USUARIO Y LA ALMACENAMOS EN UNA VARIABLE DE NOMBRE "res" Y COMO VIENE EN UN FORMATO string DEBEMOS USAR EL Int.Parse PARA CONVERTIRLA EN ENTERO Y ASI PODER USAR ESA VARIABLE EN NUESTRO METODO "EliminarPersona"
                        PersonasModel per = obj.Lista.Where(p => p.DNI == dni).FirstOrDefault();
                        if (per == null)
                        {
                            Console.WriteLine("El DNI introducido no existe, introduce un DNI correcto por favor");
                        }
                        else
                        {
                            x = false;
                        }
                        Console.WriteLine();
                    }

                    obj.EliminarPersona(dni); //LLAMAMOS A NUESTRO METODO "EliminarPersona" USANDO COMO PARAMETRO LA RESPUESTA DEL USAURIO
                    Console.WriteLine("Se ha eliminado el registro con exito");
                    Console.WriteLine();
                }
                catch (Exception)
                {
                    Console.WriteLine("El campo \"DNI\" no puede estar vacio");
                }

            }

            else if (res == 5)
            {
                Console.WriteLine("El programa se ha finalizado");
                programa = false; //ACA CAMBIAMOS EL VALOR DE LA VARIBLE PARA PODER TERMINAR EL CICLO WHILE Y QUE FINALICE LA EJECUCION DE NUESTRO PROGRAMA. DE NO EXISTIR ESTA CONDICION SE CREARIA EL BUCLE INFINITO MENCIONADO AL INICIO
                main = false;
            }

            else //SI EL USUARIO INTRODUCE ALGUN NUMERO QUE NO SEA 1-5, CAEMOS EN ESTA CONDICION Y SE REINICIA EL CICLO WHILE DE LA VARIABLE "programa"
            {
                Console.WriteLine("Has introducido una opcion incorrecta, por favor, intenta nuevamente usando un numero de 1-5");
                Console.WriteLine();
            }
        }
    }
    catch (Exception)
    {
        Console.WriteLine();
        Console.WriteLine($"Solo se aceptan valores numericos entre 1-5");
        Console.WriteLine();
    }
}

// ESTE BLOQUE DE CODIGO SOLO SE MOSTRARA AL SALIR DE AMBOS CICLOS WHILE (INTERNO Y GLOBAL)
Console.WriteLine();
Console.WriteLine("CRUD Sencillo usando una aplicacion de consola con C# en visual studio 2022");