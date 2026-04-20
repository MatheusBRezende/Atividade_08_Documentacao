using BibliotecaApi.Data;

var builder = WebApplication.CreateBuilder(args);

// Repositório em memória (Singleton para manter dados entre requisições)
builder.Services.AddSingleton<BibliotecaRepository>();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new Microsoft.OpenApi.OpenApiInfo
    {
        Version = "v1",
        Title = "Api da Biblioteca",
        Description = "API REST para gerenciamento do acervo e empréstimos de uma biblioteca.",
        Contact = new Microsoft.OpenApi.OpenApiContact
        {
            Name = "Equipe de Desenvolvimento",
            Email = "dev@biblioteca.exemplo.com"
        }
    });
    
    var xmlFilename = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFilename);
    if (File.Exists(xmlPath))
    {
        options.IncludeXmlComments(xmlPath);
    }
});
var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
