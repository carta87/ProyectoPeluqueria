using System.Collections;
using System.Collections.Generic;
using System.Linq;
using PeluqueriaStar.App.Dominio;


namespace PeluqueriaStar.App.Persistencia
{
    public class ReposopitorioCliente : IRepositorioCliente
    {
        private readonly AppContext _appContext;

        public ReposopitorioCliente(AppContext appContext){
            _appContext = appContext;
        }

        Cliente IRepositorioCliente.AddCliente(Cliente cliente ){
            var clienteAdicionado = _appContext.Clientes.Add(cliente);
            _appContext.SaveChanges();
            return clienteAdicionado.Entity;
        }

        //este metodo permitira eliminar cliente
        void IRepositorioCliente.DeleteCliente(int idCliente)
        {
            var clienteEncontrado = _appContext.Clientes.FirstOrDefault(c => c.Id == idCliente);
            if(clienteEncontrado == null) 
            return;
              _appContext.Clientes.Remove(clienteEncontrado);
              _appContext.SaveChanges();           
        }

        IEnumerable<Cliente> IRepositorioCliente.GetAllClientes()
        {
            return _appContext.Clientes;//aqui
        }

        Cliente IRepositorioCliente.GetCliente(int idCliente) 
        { 
            Cliente cliente = new Cliente();
            cliente = _appContext.Clientes.FirstOrDefault(c => c.Id == idCliente);
            return cliente;
        }

        Cliente IRepositorioCliente.UpdateCliente(Cliente cliente)
        {
            var clienteEncontrado =
                _appContext.Clientes.FirstOrDefault(c => c.Id == cliente.Id);
                if(clienteEncontrado != null)
                {
                clienteEncontrado.Nombre = cliente.Nombre;
                clienteEncontrado.Apellidos = cliente.Apellidos;
                clienteEncontrado.EstadoSalud = cliente.EstadoSalud;
                clienteEncontrado.Celular = cliente.Celular;
                clienteEncontrado.Dirrecion = cliente.Dirrecion;
                clienteEncontrado.Edad = cliente.Edad;
                clienteEncontrado.Genero = cliente.Genero;
                clienteEncontrado.Estelista = cliente.Estelista;
                
                

                _appContext.SaveChanges();
                }
                return clienteEncontrado;
        }
        
        Estelista IRepositorioCliente.AsignarEstelista(int idCliente, int idEstelista)
        {
            var clienteEncontrado = _appContext.Clientes.FirstOrDefault(c => c.Id == idCliente );
            if(clienteEncontrado != null)
            {
               var estelistaEncontrado = _appContext.Estelista.FirstOrDefault(e => e.Id == idEstelista);
               if(estelistaEncontrado != null)
               { 
                 clienteEncontrado.Estelista = estelistaEncontrado;
                 _appContext.SaveChanges();
               }
               return estelistaEncontrado;
            }
            return null;
        }

        HorarioEstelista IRepositorioCliente.AsignarHorarioEstelista(int idCliente, int idHorarioEstelista)
        {   
            var cantidadCitas =  _appContext.Clientes.FirstOrDefault(c => c.CantidadCitas == idCliente );
            var clienteEncontrado = _appContext.Clientes.FirstOrDefault(c => c.Id == idCliente );

            if (clienteEncontrado != null)
            {
                
                var  horarioEstelista = _appContext.HorarioEstelista.FirstOrDefault(Horario => Horario.Id == idHorarioEstelista);
                if(horarioEstelista != null)
                {
                 clienteEncontrado.HorarioEstelista = horarioEstelista;
                 clienteEncontrado.CantidadCitas = clienteEncontrado.CantidadCitas+1;

                 var aprobarMembresia = 5;
                 if ( clienteEncontrado.CantidadCitas >= aprobarMembresia) 
                 {
                    System.Console.WriteLine("se aplicara descuento");
                    //aprobarMembresia=+5;
                    clienteEncontrado.Membresia = true;
                 }
              
                 _appContext.SaveChanges();
                }
                return horarioEstelista;
            }
            return null;
        }
        /*
        IEnumerable<HorarioEstelista> IRepositorioCliente.AsignarHorarioEstelista(int idCliente, int idHorarioEstelista){
            var clienteEncontrado = _appContext.Clientes.FirstOrDefault(c => c.Id == idCliente);
            if(clienteEncontrado != null)
            {
                var escogerhorario = _appContext.HorarioEstelista.FirstOrDefault( horario => horario.Id == idHorarioEstelista);
                if(escogerhorario != null)
                {
                    clienteEncontrado.HorarioEstelista =escogerhorario;
                    _appContext.SaveChanges();
                }
                return escogerhorario;
            }
            return null;
        }*/



    }
}