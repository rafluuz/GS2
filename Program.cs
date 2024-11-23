using SustenAI.API.Repository;
using SustenAI.API.Services.Recommendation;
using SustenAI.Configuration;
using SustenAI.Extentions;
using SustenAI.Repository;

var builder = WebApplication.CreateBuilder(args);

IConfiguration configuration = builder.Configuration;
AppConfiguration appConfiguration = new AppConfiguration();
configuration.Bind(appConfiguration);


builder.Services.AddSingleton<RecommendationService>();

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDBContexts(appConfiguration);
builder.Services.AddSwagger(appConfiguration);
builder.Services.AddServices();
builder.Services.AddScoped<UsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IDispositivoRepository, DispositivoRepository>();
builder.Services.AddScoped<IAlertaRepository, AlertaRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
