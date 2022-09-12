using Microsoft.EntityFrameworkCore;
using PeluqueriaStar.App.Dominio;


namespace PeluqueriaStar.App.Persistencia
{
    public class AppContext : DbContext
    {
        public DbSet<Persona> Persona { get; set; }
        

        
    //metodo para la conexion
    protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder)
    {

        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder
            .UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = PeluqueriaStar");
        }

    }

    }

}