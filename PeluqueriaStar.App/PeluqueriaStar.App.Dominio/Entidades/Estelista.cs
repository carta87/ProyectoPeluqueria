using System;
using System.Collections.Generic;
namespace PeluqueriaStar.App.Dominio
{
    public class Estelista : Persona
    {
        
        public string TarjetaProfesional { get; set;}

        public List<HorarioEstelista> HorarioEstelista { get; set; }

        public List<ServiciosOfrecer> ServiciosOfrecer { get; set; }

    }
}