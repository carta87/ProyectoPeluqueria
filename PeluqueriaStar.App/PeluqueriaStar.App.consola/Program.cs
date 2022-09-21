﻿using System;
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
                System.Console.WriteLine("5. asignar servicio al cliente ");
                System.Console.WriteLine("6. lista de Clientes");
                System.Console.WriteLine("7. asignar horario cita");
                System.Console.WriteLine("8  lista de cleintes estado menbresia ");
                System.Console.WriteLine("9  aplicar descuento si aplica");
                System.Console.WriteLine("10. salir de APP peluqueria Star\n\n");
                System.Console.WriteLine("    *** Digite una opcion ***\n\n");
                
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
                         System.Console.WriteLine("metodo para asignar servico");
                         SeleccionarServicio();
                         break;
                    case 6: 
                        System.Console.WriteLine("metodo para lista de usuarios");
                        Listaclientes();
                        break;
                    case 7:
                        System.Console.WriteLine("metodo para asignar cita");
                        AsignarHorarioEstelista();
                        break;
                    case 8:
                        System.Console.WriteLine("metodo para selecionar los clientes con menbrecia");
                        ListaclientesMembresia();
                        break;
                    case 9: 
                        System.Console.WriteLine("metodo para aplicar descuento");
                        AplicarDescuentocliente();
                        break;
                    case 10:
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
                Nombre = "Rodolfo ",
                Apellidos = "Hernandez",
                Genero = Genero.Masculino,
                EstadoSalud = true,
                Celular = "34400",
                Dirrecion = "Cucuta",
                Edad = 45,
                Membresia = false,

                /*HorarioEstelista = new List<HorarioEstelista>{
                    new HorarioEstelista{Disponibilidad= true, Fecha= "2 agosto", Horario = "12pm" },
                    //new HorarioEstelista{Disponibilidad= true, Fecha= "2 agosto", Horario = "1pm" },
                    //new HorarioEstelista{Disponibilidad= true, Fecha= "2 agosto", Horario = "2pm" }
 
                },
                ServiciosOfrecer = new List<ServiciosOfrecer> {
                    new ServiciosOfrecer{Categoria= "Mujer", Descripcion= "Peluquiar", ValorServicio= 50000 },
                    //new ServiciosOfrecer{Categoria= "Mujer", Descripcion= "Maniqur", ValorServicio= 60000 },
                   // new ServiciosOfrecer{Categoria= "Mujer", Descripcion= "Cepillado", ValorServicio= 70000 }
                },
                Estelista = new Estelista{ Nombre= "Karina", TarjetaProfesional =" 2222"}
                */
                
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
            var estelista = _repocliente.AsignarEstelista(4,2);
            System.Console.WriteLine(estelista.Nombre + " "+ estelista.Apellidos);

        }

        public static void Listaclientes()
        {
            var listacleintes = _repocliente.GetAllClientes();
            var i = 1;
            foreach(Cliente c in listacleintes)
            {
                System.Console.WriteLine( i+ $". {c.Nombre} {c.Apellidos}"  );
                i++;

            }
        }

        public static void AsignarHorarioEstelista(){
            var horarioEstelista = _repocliente.AsignarHorarioEstelista(4, 1);
            var clienteEscogioHorario = _repocliente.GetCliente(1);
            System.Console.WriteLine(horarioEstelista.Fecha + " "+ horarioEstelista.Horario + " este es el cliente " +
                                      clienteEscogioHorario.Nombre);
            //System.Console.WriteLine(estelista.Nombre + " "+ estelista.Apellidos);


        }
        public static void SeleccionarServicio()
        {
            var seleccionarServicio = _repocliente.SeleccionarServicio(4,1);
            var clienteEscogioHorario = _repocliente.GetCliente(1);
            System.Console.WriteLine(seleccionarServicio.Descripcion +  " este es el cliente " +  clienteEscogioHorario.Nombre);

        }

        public static void ListaclientesMembresia()
        {
            bool estado = false;
            var listaMembrecia = _repocliente.GetClientesMenbresia(estado);
            foreach (Cliente c in listaMembrecia)
            {
                System.Console.WriteLine($"El estado selecionado es {estado}  de menbresia del cliente {c.Nombre} ");
            }

        }

        public static void  AplicarDescuentocliente()
        {
            var aplicarDescuento = _repocliente.AplicarDescuentocliente(4,1);
            

        }


    }
}