namespace PeluqueriaStar.App.Dominio
{
    public class Administrador: Persona
    {
       public CitaAsignada CitaAsignada { get; set; }
       public Membresia Membresia { get; set; } 
       public ServiciosOfrecer ServiciosOfrecer { get; set; }
       public HorarioEstelista HorarioEstelista { get; set; }
    }
}