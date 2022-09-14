namespace PeluqueriaStar.App.Dominio
{
    public class Cliente : Persona
    {
        public string Dirrecion { get; set; }
        
        public int  Edad { get; set; }

        public Genero Genero { get; set; }

        public Estelista Estelista { get; set; }
        public CitaAsignada CitaAsignada { get; set; }

    }
}