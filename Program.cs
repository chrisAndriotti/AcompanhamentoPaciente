using System.Reflection;
using AcompanhamentoPaciente.Data;
using AcompanhamentoPaciente.Services;
using AcompanhamentoPaciente.Services.Interfaces;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson(options =>
            options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            ); 
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ILeitorArquivoService, LeitorArquivoService>();
builder.Services.AddScoped<IAcompanhamentoService, AcompanhamentoService>();
builder.Services.AddScoped<ICargoService, CargoService>();
builder.Services.AddScoped<IExameService, ExameService>();
builder.Services.AddScoped<IPacienteService, PacienteService>();
builder.Services.AddScoped<IProfissionalService, ProfissionalService>();

builder.Services.AddDbContext<DataContext>();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Acompanhamento Cliente API",
        Description = " ",
        TermsOfService = new Uri("https://acompanhamento.com/terms"),
        Contact = new OpenApiContact
        {
            Name = "acompanhamento Contact",
            Url = new Uri("https://acompanhamento.com/contact")
        },
        License = new OpenApiLicense
        {
            Name = "acompanhamento License",
            Url = new Uri("https://acompanhamento.com/license")
        }
    });

    // using System.Reflection;
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseSwagger();

app.UseSwaggerUI(c =>
{
      c.SwaggerEndpoint("/swagger/v1/swagger.json", "Centralizador de Exames V1");
      c.RoutePrefix = String.Empty;
});

app.Run();


