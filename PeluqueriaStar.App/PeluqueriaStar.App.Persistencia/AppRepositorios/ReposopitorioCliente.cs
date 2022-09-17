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
                clienteEncontrado.CitaAsignada = cliente.CitaAsignada;
                

                _appContext.SaveChanges();
                }
                return clienteEncontrado;
        }
        /*
        Medico IRepositorioPaciente.AsignarMedico(int idPaciente, int idMedico)
        {
            var pacienteEncontrado = _appContext.Pacientes.FirstOrDefault(p => p.Id == idPaciente );
            if(pacienteEncontrado != null)
            {
               var medicoEncontrado = _appContext.Medicos.FirstOrDefault(m => m.Id == idMedico);
               if(medicoEncontrado != null)
               { 
                 pacienteEncontrado.Medico = medicoEncontrado;
                 _appContext.SaveChanges();
               }
               return medicoEncontrado;
            }
            return null;
        }*/

    }
}