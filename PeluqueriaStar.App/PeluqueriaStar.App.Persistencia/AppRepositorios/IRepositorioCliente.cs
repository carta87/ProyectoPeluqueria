using System;
using System.Collections.Generic;
using System.Linq;
using PeluqueriaStar.App.Dominio;

namespace PeluqueriaStar.App.Persistencia
{

    public interface IRepositorioCliente
    {
      IEnumerable<Cliente>  GetAllClientes();
      Cliente AddCliente(Cliente cliente);
      Cliente UpdateCliente (Cliente cliente);

      void DeleteCliente (int idCliente);
      Cliente  GetCliente (int idCliente);
      
      Estelista AsignarEstelista (int idCliente, int idEstelista);

      HorarioEstelista AsignarHorarioEstelista(int idCliente, int idHorarioEstelista);

      IEnumerable<Cliente> GetClientesMenbresia(bool estadoMembrescia);

      ServiciosOfrecer SeleccionarServicio(int idCliente, int idServico);

      ServiciosOfrecer AplicarDescuentocliente(int idCliente, int idServico);

      //HorarioEstelista AsignarHorarioEstelista(int idCliente, int idHorarioEstelista);


      //IEnumerable<HorarioEstelista> AsignarHorarioEstelista (int idCliente, int idHorarioEstelista);

      
    }
}
