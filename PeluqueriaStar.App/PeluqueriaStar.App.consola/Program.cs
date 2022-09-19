using System;
using PeluqueriaStar.App.Dominio;
using PeluqueriaStar.App.Persistencia;
using System.Collections.Generic;

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
                System.Console.WriteLine("4. asignar Estelsita");
                System.Console.WriteLine("5. asignar uno o varios servicios ");
                System.Console.WriteLine("6. salir de APP peluqueria Star\n\n");
                System.Console.WriteLine("    *** Digite una opcion ***");
                int opcion = Convert.ToInt32(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        AddCliente();
                        break;
                    case 2:
                        System.Console.WriteLine("metodo para borrar Cliente");
                        BorrarCliente(1);
                        break;
                    case 3:
                        System.Console.WriteLine("medtodo buscar  Cliente ");
                        buscarCliente(1);  
                        break;

                    case 4:
                        System.Console.WriteLine("metodo para asignar estelsita");
                        AsignarEstelista();
                        break;
                    case 5:
                         System.Console.WriteLine("metodo para asignar servicos");
                         //falta implemtarlo
                         break;
                    case 6:                        
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
                Nombre = "Gustavo",
                Apellidos = "Petro",
                Genero = Genero.Masculino,
                EstadoSalud = true,
                Celular = "300000",
                Dirrecion = "cali",
                Edad = 45,

                
                
            };
            _repocliente.AddCliente(cliente);
            System.Console.WriteLine($"El Cleinte {cliente.Nombre} {cliente.Apellidos} ha sido Agregado con exito");

        }

        private static void BorrarCliente(int idCliente)
        {
            _repocliente.DeleteCliente(idCliente);
            System.Console.WriteLine("Cliente eliminado con exito");

        }


        private static void buscarCliente(int idCliente){
            var cliente =  _repocliente.GetCliente(idCliente);
            System.Console.WriteLine("Cliente encontrado con exito con el nombre" + cliente.Nombre);

        }


        public static void AsignarEstelista()
        { 
            var estelista = _repocliente.AsignarEstelista(1,1);
            System.Console.WriteLine(estelista.Nombre + " "+ estelista.Apellidos);

        }


    }
}