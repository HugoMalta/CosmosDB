using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace CosmosDB.API
{
    /// <summary>
    /// Inicia Swagger. Adicionado neste classe para não poluir o Startup.cs
    /// </summary>
    public static class StartupSwagger
    {
        /// <summary>
        /// ConfigureServices swagger
        /// </summary>
        /// <param name="services"></param>
        public static void ConfigureServices(IServiceCollection services)
        {
            //ativa o serviço de documentação do swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new Info
                    {
                        Title = "Projeto criado para testar funcionalidades do CosmosDB",
                        Version = "v1",
                        Description = @" 
<b>O que você precisa para executar este projeto?</b>
Alterar parâmetros do 'appsettings.json. São eles: 
     - ToDoList_CosmosDB:EndpointUri --> Obtido no seu emulador de CosmosDB - https://docs.microsoft.com/pt-br/azure/cosmos-db/local-emulator
     - ToDoList_CosmosDB:PrimaryKey --> Obtido no seu emulador de CosmosDB
     - ToDoList_CosmosDB:DataBase --> Obtido no seu emulador de CosmosDB
     - ToDoList_CosmosDB:CollectionItens --> Obtido no seu emulador de CosmosDB 

*Feito em VS2017.",
                        Contact = new Contact
                        {
                            Name = "Hugo Malta",
                            Email = "hugomalta@gmail.com"
                        }
                    });

                //Obtem o xml da documentação adicionada no código e vincula ao swagger.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
                c.DescribeAllEnumsAsStrings();
            });
        }

        /// <summary>
        /// Configure swagger
        /// </summary>
        /// <param name="app"></param>
        public static void Configure(IApplicationBuilder app)
        {
            //permite que o swagger seja utilizado na api.
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("v1/swagger.json", "v1");
            });
        }
    }
}
