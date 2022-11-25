using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Pro.Listas;
using Project.Byte.Bank.Infra.Context;

namespace Project.Byte;
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
        builder.Services.AddDbContext<DataContext>(
            opt => opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
            );
        builder.Services.AddMvc();
        builder.Services.AddAuthorization();
        builder.Services.AddSwaggerGen(c =>
        {
            c.DescribeAllParametersInCamelCase();
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "VAPT Uniformes Api", Version = "v1" });
            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Description = "Authorization header usando o Bearer scheme. Example: \"bearer {token}\"",
                In = ParameterLocation.Header,
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey
            });

            //c.DescribeAllEnumsAsStrings();
            c.AddSecurityRequirement(new OpenApiSecurityRequirement
                        {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header

                        },
                        new List<string>()
                    }
                        });
        }
        );

        var app = builder.Build();

        // Configure the HTTP request pipeline. 
        {
            app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");
            app.Run();

            var CadastroDeUsuáriosETransações = new List<ListaDeUsuáriosETransaçõesCadastradas>()
    {
              new ListaDeUsuáriosETransaçõesCadastradas { Id = 1, NomeCompleto = "Brayan", Idade = 27, Cpf = 123456789 },
              new ListaDeUsuáriosETransaçõesCadastradas { Id = 2, NomeCompleto = "Larissa", Idade = 28, Cpf = 789456123 },
              new ListaDeUsuáriosETransaçõesCadastradas { Id = 3, NomeCompleto = "Clara", Idade = 32, Cpf = 321654987 },
              new ListaDeUsuáriosETransaçõesCadastradas { Id = 4, NomeCompleto = "Roberto", Idade = 35, Cpf = 654987321 },
              new ListaDeUsuáriosETransaçõesCadastradas { Id = 5, NomeCompleto = "Roberta", Idade = 35, Cpf = 654987321 },

              new ListaDeUsuáriosETransaçõesCadastradas { Id = 6, Valor = 1000,Tipo= "TED",  DataDaTransação = 14 / 11 / 2022, Devedor = "Larissa", Credor = "Brayan" },
              new ListaDeUsuáriosETransaçõesCadastradas { Id = 7, Valor = 200, Tipo = "DOC", DataDaTransação = 15 / 11 / 2022, Devedor = "Clara", Credor = "Larissa" },
              new ListaDeUsuáriosETransaçõesCadastradas { Id = 8, Valor = 300, Tipo = "DOC", DataDaTransação = 15 / 11 / 2022, Devedor = "Roberto", Credor = "Clara" },
              new ListaDeUsuáriosETransaçõesCadastradas { Id = 9, Valor = 400, Tipo = "TED", DataDaTransação = 15 / 11 / 2022, Devedor = "Roberta", Credor = "Roberto" },
              new ListaDeUsuáriosETransaçõesCadastradas { Id = 10,Valor = 500, Tipo = "DOC", DataDaTransação = 15 / 11 / 2022, Devedor = "Brayan", Credor = "Roberta" }
    };
            var queryAllCustomers = from cust in CadastroDeUsuáriosETransações
                                    select cust;
            CadastroDeUsuáriosETransações.AddRange(queryAllCustomers);


        }
    }
}