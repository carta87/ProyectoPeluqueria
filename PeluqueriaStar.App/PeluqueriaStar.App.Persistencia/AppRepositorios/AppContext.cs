using Microsoft.EntityFrameworkCore;
using PeluqueriaStar.App.Dominio;


namespace PeluqueriaStar.App.Persistencia
{
    public class AppContext : DbContext
    {
       public DbSet<Persona> Persona { get; set; }
       public DbSet<Administrador> Administrador { get; set; }

       public DbSet<Cliente> Clientes { get; set; }

       public DbSet<Estelista> Estelista { get; set; }

       public DbSet<HorarioEstelista> HorarioEstelista { get; set; }

       public DbSet<Membresia> Membresia { get; set; }

       public DbSet<ServiciosOfrecer> ServiciosOfrecer { get; set; }

       public DbSet<CitaAsignada> CitaAsignada { get; set; }
        

        
    //metodo para la conexion
    protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder)
    {

        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder
            .UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = PeluqueriaStar01");
        }

    }

    }

}