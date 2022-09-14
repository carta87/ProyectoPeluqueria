namespace PeluqueriaStar.App.Dominio
{
    public class Estelista : Persona
    {
         
        public string TarjetaProfesional { get; set;}

        public HorarioEstelista HorarioEstelista { get; set; }

        public ServiciosOfrecer ServiciosOfrecer { get; set; }

    }
}