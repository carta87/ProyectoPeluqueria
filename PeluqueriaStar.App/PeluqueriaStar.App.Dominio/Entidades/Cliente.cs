namespace PeluqueriaStar.App.Dominio
{
    class Cliente : Persona
    {
        public string Dirrecion { get; set; }
        
        public int  Edad { get; set; }

        public Genero Genero { get; set; }

    }
}