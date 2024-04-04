using LogicaNegocio.Entidades;
using LogicaNegocio.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Reflection.Emit;

namespace Infraestructura.LogicaAccesoDatos.EF
{
    public class LibreriaContext : DbContext
    {


        // fluenapi para personalizar

        public DbSet<Tema> Temas { get; set; }
        public DbSet<Autor> Autores { get; set; }
        public DbSet<Pais> Paises { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = libreria; Integrated Security = True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Autor>().HasOne(aut => aut.MiPais).WithMany(p => p.MisAutores).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Autor>().OwnsOne(a => a.MiDireccion, dir =>
            {
                dir.Property(d => d.Calle).HasColumnName("direccion_calle");
                dir.Property(d => d.Nro).HasColumnName("direccion_nro");
            }
            );
           

        }

    }
}















//var nombreConvert = new ValueConverter<Nombre, string>(
//    v => v.Value,
//v => new Nombre(v)
//    );
//modelBuilder.Entity<Autor>().Property(a => a.Nombre).HasConversion(nombreConvert);
//modelBuilder.Entity<Autor>().HasIndex(a => a.Nombre).IsUnique();

//modelBuilder.Entity<Tema>().Property(a => a.Nombre).HasConversion(nombreConvert);
//modelBuilder.Entity<Tema>().HasIndex(a => a.Nombre).IsUnique();

//modelBuilder.En //   modelBuilder.ApplyConfiguration(new AutorConfiguration());
//tity<Autor>().OwnsOne(a => a.MiDireccion, dir =>
//{
//    dir.Property(d => d.Calle).HasColumnName("MiDireccion_Calle");
//    dir.Property(d => d.DistanciaReparto).HasColumnName("MiDireccion_NumeroPuerta");
//});



// modelBuilder.HasOne(aut => aut.MiPais).WithMany(p => p.MisAutores).OnDelete(DeleteBehavior.NoAction);
// builder.OwnsOne(aut => aut.MiDireccion);

//builder.OwnsOne(a => a.MiDireccion, dir =>
//{
//    dir.Property(d => d.Calle).HasColumnName("MiDireccion_Calle");
//    dir.Property(d => d.NumeroPuerta).HasColumnName("MiDireccion_NumeroPuerta");
//});


//   builder.Property(x => x.Nombre).HasMaxLength(50).IsRequired();
//   builder.HasIndex(x => x.Nombre).IsUnique();


//modelBuilder.Entity<Publicacion>().OwnsOne(pub => pub.MiNombre);


//        modelBuilder.Entity<Compra>().Property(c => c.PrecioTotal).HasPrecision(18, 2);
//        modelBuilder.Entity<Publicacion>().OwnsOne(p => p.MiResena);
//        modelBuilder.Entity<Biografia>().HasKey(b => b.AutorId);

//        modelBuilder.Entity<Publicacion>()
//           .HasMany(pub => pub.MisAutores)
//           .WithMany(aut => aut.MisPublicaciones)
//           .UsingEntity<Dictionary<string, object>>(

//            //nombre de la tabla asociativa
//            "Publicacion_Autor",

//             //setear la FK de autor primero, porque se arrancó por la Entity Publicacion
//             izq => izq.HasOne<Autor>().WithMany().OnDelete(DeleteBehavior.Restrict),

//             //setear la FK de publicación
//             der => der.HasOne<Publicacion>().WithMany().OnDelete(DeleteBehavior.Restrict));


//        modelBuilder.Entity<Publicacion>()

//           .HasMany(pub => pub.MisFans)
//           .WithMany(aut => aut.MisPublicacionesFavoritas)
//           .UsingEntity<Dictionary<string, object>>(


//            //nombre de la tabla asociativa
//            "Publicacion_Favoritas",

//             //setear la FK de autor primero, porque se arrancó por la Entity Publicacion
//             izq => izq.HasOne<Autor>().WithMany().OnDelete(DeleteBehavior.Restrict),

//             //setear la FK de publicación
//             der => der.HasOne<Publicacion>().WithMany().OnDelete(DeleteBehavior.Restrict));

//var nombreConvert = new ValueConverter<Nombre, string>(
//    v => v.Value,
//    v => new Nombre(v)
//    );

//        modelBuilder.Entity<Order>()
//.Property(e => e.Price)
//.HasConversion(
//    v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null),
//    v => JsonSerializer.Deserialize<Money>(v, (JsonSerializerOptions)null));


// modelBuilder.Entity<Autor>().Property(a => a.Nombre).HasConversion(nombreConvert);
//        modelBuilder.Entity<Autor>().HasIndex(a  => a.Nombre).IsUnique();
//       // modelBuilder.Entity<Autor>().Property(a => a.Segundo).HasConversion(nombreConvert);
