using System.Collections;
using System.Collections.Generic;
using System.Linq;
using PeluqueriaStar.App.Dominio;


namespace PeluqueriaStar.App.Persistencia
{
    public class ReposopitorioCliente : IRepositorioCliente
    {
        private readonly AppContext _appContext;

        public ReposopitorioCliente(AppContext appContext)
        {
            _appContext = appContext;
        }

        Cliente IRepositorioCliente.AddCliente(Cliente cliente)
        {
            var clienteAdicionado = _appContext.Clientes.Add(cliente);
            _appContext.SaveChanges();
            return clienteAdicionado.Entity;
        }

        //este metodo permitira eliminar cliente
        void IRepositorioCliente.DeleteCliente(int idCliente)
        {
            var clienteEncontrado = _appContext.Clientes.FirstOrDefault(c => c.Id == idCliente);
            if (clienteEncontrado == null)
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
            if (clienteEncontrado != null)
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
            var clienteEncontrado = _appContext.Clientes.FirstOrDefault(c => c.Id == idCliente);
            if (clienteEncontrado != null)
            {
                var estelistaEncontrado = _appContext.Estelista.FirstOrDefault(e => e.Id == idEstelista);
                if (estelistaEncontrado != null)
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
            var clienteEncontrado = _appContext.Clientes.FirstOrDefault(c => c.Id == idCliente);
            if (clienteEncontrado != null)
            {
                var horarioEstelista = _appContext.HorarioEstelista.FirstOrDefault(Horario => Horario.Id == idHorarioEstelista);
                if (horarioEstelista != null)
                {
                    var cantidadCitas = _appContext.Clientes.FirstOrDefault(c => c.CantidadCitas == idCliente);
                    clienteEncontrado.HorarioEstelista = horarioEstelista;
                    clienteEncontrado.CantidadCitas = clienteEncontrado.CantidadCitas + 1;
                    horarioEstelista.Disponibilidad = true;

                    var aprobarMembresia = 5;
                    if (clienteEncontrado.CantidadCitas >= aprobarMembresia)
                    {
                        clienteEncontrado.Membresia = true;//true es 1 
                        if(clienteEncontrado.CantidadCitas == 6){
                            clienteEncontrado.CantidadCitas = 0;
                        }   
                    }
                    _appContext.SaveChanges();
                }
                return horarioEstelista;
            }
            return null;
        }

        IEnumerable<Cliente> IRepositorioCliente.GetClientesMenbresia(bool estadoMembrescia)
        {
            return _appContext.Clientes.Where(c => c.Membresia == estadoMembrescia).ToList();
        }

        ServiciosOfrecer IRepositorioCliente.SeleccionarServicio(int idCliente, int idServico)
        {
            var clienteEncontrado = _appContext.Clientes.FirstOrDefault(c => c.Id == idCliente);
            if (clienteEncontrado != null)
            {
                var servicioEscogido = _appContext.ServiciosOfrecer.FirstOrDefault(servicio => servicio.Id == idServico);
                if (servicioEscogido != null)
                {
                    clienteEncontrado.ServiciosOfrecer = servicioEscogido;
                    _appContext.SaveChanges();
                }
                return servicioEscogido;
            }
            return null;

        }
         ServiciosOfrecer IRepositorioCliente.AplicarDescuentocliente(int idCliente, int idServico)
         { 
            var clienteEncontrado = _appContext.Clientes.FirstOrDefault(c => c.Id == idCliente );
            if (clienteEncontrado != null)
            {
                var servicioEscogido = _appContext.ServiciosOfrecer.FirstOrDefault(servicio=>  servicio.Id == idServico );
                if(servicioEscogido != null){
                    if ( clienteEncontrado.Membresia)
                    {
                        servicioEscogido.ValorAplicarDescuento = (servicioEscogido.ValorServicio * 10)/100;
                        System.Console.WriteLine("el valor aplicado es " +servicioEscogido.ValorAplicarDescuento + " por menbrecia activada");
                        clienteEncontrado.Membresia = false;
                        clienteEncontrado.CantidadCitas = 0;
                        _appContext.SaveChanges();

                        return servicioEscogido;

                    }

                    if (clienteEncontrado.CantidadCitas == 5)
                    {
                        servicioEscogido.ValorAplicarDescuento = (servicioEscogido.ValorServicio * 10)/100;
                        System.Console.WriteLine("el valor aplicado es " +servicioEscogido.ValorAplicarDescuento + " por menbrecia activada o 5 servicio");
                        clienteEncontrado.Membresia = false;
                         _appContext.SaveChanges();
                    }       
                }
                return servicioEscogido;
            }
            return null;
         }

        IEnumerable<HorarioEstelista> IRepositorioCliente.GetListaHorarioDisponible(){
            
            return _appContext.HorarioEstelista.Where(hor => hor.Disponibilidad == false) ;
        }

        bool IRepositorioCliente.ValidarContrasenaPersona(string email, string contasena)
        {
            var clienteEncontradoEmail = _appContext.Persona.FirstOrDefault(p => p.Email == email );
            if(clienteEncontradoEmail != null)
            {
                var clienteEncontradoContrasena = _appContext.Persona.FirstOrDefault(p => p.Contrasena == contasena );
                
                return clienteEncontradoContrasena != null? true: false;
                
            }
            return false;
        }
    }
}