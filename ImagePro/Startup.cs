using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using Swashbuckle.AspNetCore.Swagger;

namespace ImagePro
{

    public class Startup
    {
        private readonly ILoggerFactory loggerFactory;
        public Startup(IConfiguration configuration, ILoggerFactory loggerFactory)
        {
            this.loggerFactory = loggerFactory;
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var logger = loggerFactory.CreateLogger<RawRequestBodyFormatter>();
            services
                .AddMvc(o => o.InputFormatters.Insert(0, new RawRequestBodyFormatter()))
                .AddJsonOptions(o =>
                {
                    o.SerializerSettings.Converters = new List<JsonConverter>()
                    {
                        new StringEnumConverter(new CamelCaseNamingStrategy(), true)
                    };
                    o.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                    o.SerializerSettings.Formatting = Formatting.Indented;
                    o.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                    o.SerializerSettings.PreserveReferencesHandling = PreserveReferencesHandling.None;
                    o.SerializerSettings.DateFormatHandling = DateFormatHandling.IsoDateFormat;
                    o.SerializerSettings.DateFormatString = "u";
                    o.SerializerSettings.DateParseHandling = DateParseHandling.DateTime;
                    o.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Utc;
                });

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Info
                {
                    Title = "CPSC 5200 ImageProcessor",
                    Version = "v1",
                    Contact = new Contact()
                    {
                        Name = "Nishigandha Mhatre",
                        Email = "mhatrenishig@seattleu.edu"
                    },
                    Description = "CPSC Image Processor"
                });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            // order is important here
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "CPSC 5200 REST Example");
            });

            app.UseMvc();
        }
    }
}
