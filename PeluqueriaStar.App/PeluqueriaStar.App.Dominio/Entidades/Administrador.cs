namespace PeluqueriaStar.App.Dominio
{
    public class Administrador: Persona
    {  
       public Estelista Estelista { get; set; }
       public Cliente  Cliente { get; set; }
       public ServiciosOfrecer ServiciosOfrecer { get; set; }
       public HorarioEstelista HorarioEstelista { get; set; }
    }
}