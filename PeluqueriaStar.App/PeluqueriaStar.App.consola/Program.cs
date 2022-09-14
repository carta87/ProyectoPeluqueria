using System;
using PeluqueriaStar.App.Dominio;
using PeluqueriaStar.App.Persistencia;

namespace PeluqueriaStar.App.consola
{
    class Program
    {
        //creamos un campo o atributo de clase llamado _repocliente
        private static IRepositorioCliente _repocliente = new ReposopitorioCliente(new Persistencia.AppContext());

        static void Main(string[] args)
        {
            bool control = true;
            while (true)
            {
                System.Console.WriteLine("### Bienvenido al programa probar peluqueria###");
                System.Console.WriteLine("         ### CRUD  Clientes  ####                   ");
                System.Console.WriteLine();
                System.Console.WriteLine("1. Adicionar Cliente ");
                System.Console.WriteLine("2. Borrar Cliente ");
                System.Console.WriteLine("3. buscar  Cliente ");
                int opcion = Convert.ToInt32(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        AddCliente();
                        break;
                    case 2:
                        System.Console.WriteLine("metodo para borrar Cliente");
                        BorrarCliente(2);
                        break;
                    case 3:
                        System.Console.WriteLine("medtodo buscar  Cliente ");
                        buscarCliente(1);  
                        break;

                    case 4:
                        
                        System.Console.WriteLine("gracias por usar la aplicacion peluqueria");
                        control = false;
                        break;
                    default:
                        System.Console.WriteLine("opcion Incorecta, digite nuevamente");
                        break;
                }


            }


        }

        private static void AddCliente()
        {
            var cliente = new Cliente
            {
                Nombre = "Pepito",
                Apellidos = "Perez",
                Genero = Genero.Masculino,
                EstadoSalud = true,
                Celular = "321555544",
                Dirrecion = "calle 70 45s sur",
                Edad = 45,
                
                
            };
            _repocliente.AddCliente(cliente);
            System.Console.WriteLine($"El Cleinte {cliente.Nombre} {cliente.Apellidos} ha sido Agregado con exito");

        }

        private static void BorrarCliente(int idCliente)
        {
            _repocliente.DeleteCliente(idCliente);
            System.Console.WriteLine("Cliente elininado con exito");

        }


        private static void buscarCliente(int idCliente){
            _repocliente.GetCliente(idCliente);
            System.Console.WriteLine("Cliente encontrado con exito");

        }


    }
}