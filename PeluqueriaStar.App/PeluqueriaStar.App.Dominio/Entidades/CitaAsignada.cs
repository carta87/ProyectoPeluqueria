namespace PeluqueriaStar.App.Dominio
{
    class CitaAsignada
    {
        public int Id { get; set; }
        public string FechaCita { get; set; }
        public string HorarioCita { get; set; }
        public Membresia Membresia { get; set; }
    }
}