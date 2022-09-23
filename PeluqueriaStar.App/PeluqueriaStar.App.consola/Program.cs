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
                System.Console.WriteLine("         ### CRUD  Clientes  ####/n                   ");
                System.Console.WriteLine("1. Adicionar Cliente ");
                System.Console.WriteLine("2. buscar  Cliente ");
                System.Console.WriteLine("3. Borrar Cliente ");
                System.Console.WriteLine("4. lista de Clientes");         
                System.Console.WriteLine("5. lista de horarios Disponibles");
                System.Console.WriteLine("6. asignar horario cita");
                System.Console.WriteLine("7. asignar Estelsita");
                System.Console.WriteLine("8. asignar servicio al cliente ");
                System.Console.WriteLine("9  lista de cleintes estado menbresia ");
                System.Console.WriteLine("10  aplicar descuento si aplica");
                System.Console.WriteLine("11. salir de APP peluqueria Star\n\n");
                System.Console.WriteLine("    *** Digite una opcion ***\n\n");
                
                int opcion = Convert.ToInt32(Console.ReadLine());
                int numeroEscogido = 0;
                int numClienteId = 0;
                int numEstelistaId = 0;

                switch (opcion)
                {
                    case 1:
                        System.Console.WriteLine("medtodo crear cliente ");
                        AddCliente();//metodo se solicitan los datos para crear objecto Cleiente
                        break;
                    case 2:
                        System.Console.WriteLine("medtodo buscar  Cliente ");
                        System.Console.WriteLine("indique el numero ID de  cliente a buscar");
                        numeroEscogido = Convert.ToInt32(Console.ReadLine());
                        buscarCliente(numeroEscogido);  
                        break;
                    case 3:
                        System.Console.WriteLine("metodo para borrar Cliente");
                        System.Console.WriteLine("indique el numero ID de  cliente a borrar");
                        numeroEscogido = Convert.ToInt32(Console.ReadLine());
                        BorrarCliente(numeroEscogido);  
                        break;
                    case 4:
                        System.Console.WriteLine("metodo para lista de usuarios");
                        Listaclientes();
                        break;
                    case 5:
                        System.Console.WriteLine("metodo para mostar lista horarios disponibles");
                         listaHorariosDisponibles();
                         break;
                    case 6: 
                        System.Console.WriteLine("metodo para asignar cita");
                        System.Console.WriteLine("indique el numero ID de  cliente a buscar");
                        numClienteId = Convert.ToInt32(Console.ReadLine());
                        System.Console.WriteLine("indique el numero ID de  Estelista a buscar");
                        numEstelistaId = Convert.ToInt32(Console.ReadLine());
                        AsignarHorarioEstelista( numClienteId, numEstelistaId );  
                        break;
                    case 7:
                        System.Console.WriteLine("metodo para asignar estelsita");
                        System.Console.WriteLine("indique el numero ID de  cliente a buscar");
                        numClienteId = Convert.ToInt32(Console.ReadLine());
                        System.Console.WriteLine("indique el numero ID de  Estelista a buscar");
                        numEstelistaId = Convert.ToInt32(Console.ReadLine());
                        AsignarEstelista(numClienteId, numEstelistaId);
                        break;
                    case 8:
                         System.Console.WriteLine("metodo para asignar servico");
                         System.Console.WriteLine("indique el numero ID de  cliente a buscar");
                         numClienteId = Convert.ToInt32(Console.ReadLine());
                         System.Console.WriteLine("indique el numero ID del servicio");
                         int numeroServicioId = Convert.ToInt32(Console.ReadLine());
                        SeleccionarServicio(numClienteId, numeroServicioId);
                        break;
                    case 9: 
                        System.Console.WriteLine("metodo para selecionar los clientes con menbrecia");
                        System.Console.WriteLine("Desea conocer los usuarios por membresia activada/n1. No /n2. Si" );
                        string menbrecia = Convert.ToString(Console.ReadLine());
                        bool estadoMembresia = false;
                        bool menbrecia2 = menbrecia == "1" ? estadoMembresia == true: estadoMembresia == false;
                        ListaclientesMembresia(menbrecia2);
                        break;
                    case 10:
                        System.Console.WriteLine("metodo para aplicar descuento");
                        System.Console.WriteLine("ingrese el numero de Id Cliente");
                        numClienteId = Convert.ToInt32(Console.ReadLine());
                        System.Console.WriteLine("Ingrese El Id Servico");
                        int numeroIdServicio = Convert.ToInt32(Console.ReadLine());
                        AplicarDescuentocliente(numClienteId, numeroIdServicio);
                        break;
                    case 11:
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
            System.Console.WriteLine("Se solicitaran datos necesarios para crear cliente");
            System.Console.WriteLine("Indique el nombre");
            string nombre = Console.ReadLine();
            System.Console.WriteLine("Indique el Apellido");
            string apellido = Console.ReadLine();
            System.Console.WriteLine("Numero Celular");
            string celular = Console.ReadLine();
            System.Console.WriteLine("Ingrese Dirreccion");
            string dirreccion = Console.ReadLine();
            System.Console.WriteLine("Ingrese Edad ");
            int edad = Convert.ToInt32(Console.ReadLine()); 
    
            //se crea objecto para asignar los datos que corresponden   
            var cliente = new Cliente
            {
                Nombre = nombre,
                Apellidos = apellido,
                Genero = Genero.Masculino,
                EstadoSalud = true,
                Celular = celular,
                Dirrecion = dirreccion,
                Edad = edad,
                Membresia = false,
                /*   //prueba para asignarle horario y servicio 
                HorarioEstelista = new List<HorarioEstelista>{
                    new HorarioEstelista{Disponibilidad= true, Fecha= "2 agosto", Horario = "12pm" },
                },
                ServiciosOfrecer = new List<ServiciosOfrecer> {
                    new ServiciosOfrecer{Categoria= "Mujer", Descripcion= "Peluquiar", ValorServicio= 50000 },    
                },
                */
            };

            System.Console.WriteLine("Indique el Genero /n1. Femenino/n2. Masculino");
            int numAsignarGenero = Convert.ToInt32(Console.ReadLine());
            if(numAsignarGenero ==1 )  cliente.Genero = Genero.Femeninio;
            else cliente.Genero = Genero.Masculino;

            System.Console.WriteLine("Desea asignar membresia /n 1. Si /n2. no");
            string menbrecia = Convert.ToString(Console.ReadLine());
            bool menbrecia2 = menbrecia == "1" ? cliente.Membresia == true: cliente.Membresia== false;

            _repocliente.AddCliente(cliente);
            System.Console.WriteLine($"El Cleinte {cliente.Nombre} {cliente.Apellidos} ha sido Agregado con exito");

        }

        private static void buscarCliente(int idCliente){
            var cliente =  _repocliente.GetCliente(idCliente);
            System.Console.WriteLine("Cliente encontrado con exito con el nombre" + cliente.Nombre);
        }

        private static void BorrarCliente(int idCliente)
        {
            _repocliente.DeleteCliente(idCliente);
            System.Console.WriteLine("Cliente eliminado con exito");

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

        public static void listaHorariosDisponibles()
        {
            var listaHorariosDisponibles = _repocliente.GetListaHorarioDisponible();
            foreach (HorarioEstelista horario in listaHorariosDisponibles)
            {
                string estado= "Activa" ;
                if (horario.Disponibilidad == true){
                    estado = Convert.ToString(horario.Disponibilidad) ;
                    System.Console.WriteLine($" horario esta {estado} con Fecha {horario.Fecha} y hora {horario.Horario}");
                }    
            }
        }

        public static void AsignarEstelista(int idCliente, int idEstelista)
        { 
            var estelista = _repocliente.AsignarEstelista(idCliente, idEstelista);
            System.Console.WriteLine(estelista.Nombre + " "+ estelista.Apellidos);

        }



        public static void AsignarHorarioEstelista(int idCliente, int idEstelista){
            var horarioEstelista = _repocliente.AsignarHorarioEstelista(idCliente, idEstelista);
            var clienteEscogioHorario = _repocliente.GetCliente(idCliente);
            System.Console.WriteLine(horarioEstelista.Fecha + " "+ horarioEstelista.Horario + " este es el cliente " +
                                      clienteEscogioHorario.Nombre);
            //System.Console.WriteLine(estelista.Nombre + " "+ estelista.Apellidos);


        }
        public static void SeleccionarServicio(int idCliente, int idServico)
        {
            var seleccionarServicio = _repocliente.SeleccionarServicio(idCliente, idServico);
            var clienteEscogioHorario = _repocliente.GetCliente(idCliente);
            System.Console.WriteLine(seleccionarServicio.Descripcion +  " este es el cliente " +  clienteEscogioHorario.Nombre);

        }

        public static void ListaclientesMembresia(bool estado)
        {
            
            var listaMembrecia = _repocliente.GetClientesMenbresia(estado);
            foreach (Cliente c in listaMembrecia)
            {
                System.Console.WriteLine($"El estado selecionado es {estado}  de menbresia del cliente {c.Nombre} ");
            }

        }

        public static void  AplicarDescuentocliente(int idCliente, int idServicio)
        {
            var aplicarDescuento = _repocliente.AplicarDescuentocliente(idCliente, idServicio);
            

        }
        

    }
}