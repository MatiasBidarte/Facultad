using Infraestructura.  LogicaAccesoDatos.EF;
using LogicaAplicacion.Temas;
using LogicaNegocio.Entidades;
using LogicaNegocio.IntefazServicios;
using LogicaNegocio.InterfazRepositorio;

namespace WebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // inteyeccion de dependcia. hace el new del objeto y lo pasa con su interfaz

            // repositorios
            builder.Services.AddScoped<IRepositorioTema, RepositorioTema>();

            // caso de uso
            builder.Services.AddScoped<IAlta<Tema>, AltaTema>();
            builder.Services.AddScoped<IEditar<Tema>, EditarTema>();
            builder.Services.AddScoped<IEliminar<Tema>, EliminarTema>();      
            builder.Services.AddScoped<IObtener<Tema>, ObtenerTema>();
            builder.Services.AddScoped<IObtenerTodos<Tema>, ObtenerTemas>();

            // inyecta el contexto 
            builder.Services.AddDbContext<LibreriaContext>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Tema}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
