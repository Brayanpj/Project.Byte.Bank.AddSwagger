using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Project.Byte.Bank.Infra.Context;
using Project.Byte.Bank_.Repository;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace Project.Byte.Bank;
public class Program
{
    private static void Main(string[] args)
    {
        var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        var builder = WebApplication.CreateBuilder(args);
        // Add services to the container. 
        builder.Services.AddControllersWithViews();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddControllers();
        builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        builder.Services.AddAutoMapper(typeof(Action));
        //builder.Services.AddAuthentication(NegotiateDefaults.AuthenticationScheme)
        // .AddNegotiate();
        builder.Services.AddDbContext<DataContext>(
            opt =>
            {
                opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });
        NativeInjector.RegisterServices(builder.Services);
        builder.Services.AddMvc();
        builder.Services.AddAuthorization();
        builder.Services.AddAuthentication();
        builder.Services.AddSwaggerGen(c =>
        {
            c.DescribeAllParametersInCamelCase();
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Sistema de Cadastro ByteBank", Version = "v1" });
        }
        );
        var app = builder.Build();

        using (var serviceScope = app.Services.GetService<IServiceScopeFactory>().CreateScope())
        {
            serviceScope.ServiceProvider.GetRequiredService<DataContext>().Database.Migrate();
        };

        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "API");
            c.RoutePrefix = "";
            c.DocExpansion(DocExpansion.None);
        });

        // Configure the HTTP request pipeline. 
        {
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {

            }
            app.UseSwagger();
            app.UseSwaggerUI();

            app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");
            app.Run();

            var CadastroDeUsu�riosETransa��es = new List<ListaDeUsu�riosETransa��esCadastradas>()
    {
              new ListaDeUsu�riosETransa��esCadastradas { Id = 1, NomeCompleto = "Brayan Prates Jardim",    Idade = 27, Cpf =     "123456789", DataDeNascimento = "20/08/1995" },
              new ListaDeUsu�riosETransa��esCadastradas { Id = 2, NomeCompleto = "Larissa Alves Barbosa",   Idade = 28, Cpf =     "789456123", DataDeNascimento = "15/09/1996" },
              new ListaDeUsu�riosETransa��esCadastradas { Id = 3, NomeCompleto = "Clara martinez alvarenga",Idade = 32, Cpf =     "321654987", DataDeNascimento = "20/08/1997"},
              new ListaDeUsu�riosETransa��esCadastradas { Id = 4, NomeCompleto = "Roberto Carlos andrade",  Idade = 35, Cpf =     "654987321", DataDeNascimento = "10/09/1994" },
              new ListaDeUsu�riosETransa��esCadastradas { Id = 5, NomeCompleto = "Roberta marinho barbosa", Idade = 35, Cpf =     "654987321", DataDeNascimento = "09/07/1980" },

              new ListaDeUsu�riosETransa��esCadastradas { Id = 6, Valor = 1000,Tipo=  "TED", DataDaTransa��o = 14 / 11 / 2022, Devedor = "Larissa", Credor = "Brayan" },
              new ListaDeUsu�riosETransa��esCadastradas { Id = 7, Valor = 200, Tipo = "DOC", DataDaTransa��o = 15 / 11 / 2022, Devedor = "Clara",   Credor = "Larissa" },
              new ListaDeUsu�riosETransa��esCadastradas { Id = 8, Valor = 300, Tipo = "DOC", DataDaTransa��o = 15 / 11 / 2022, Devedor = "Roberto", Credor = "Clara" },
              new ListaDeUsu�riosETransa��esCadastradas { Id = 9, Valor = 400, Tipo = "TED", DataDaTransa��o = 15 / 11 / 2022, Devedor = "Roberta", Credor = "Roberto" },
              new ListaDeUsu�riosETransa��esCadastradas { Id = 10,Valor = 500, Tipo = "DOC", DataDaTransa��o = 15 / 11 / 2022, Devedor = "Brayan",  Credor = "Roberta" }
    };
            var listaDeUsu�riosETransa��esCadastradas = from cust in CadastroDeUsu�riosETransa��es
                                                        where cust.Id == 5
                                                        select cust;
            CadastroDeUsu�riosETransa��es.AddRange(CadastroDeUsu�riosETransa��es);
        }
    }
}