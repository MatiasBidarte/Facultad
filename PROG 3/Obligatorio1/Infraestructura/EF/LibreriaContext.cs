using System;
using Microsoft.EntityFrameworkCore;
namespace Infraestructura.EF
{
	public class LibreriaContext: DbContext
	{
        // Aca poner todos los dbSet de las entidades que seran tablas

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = libreria; Integrated Security = True");

        }
    }
}

