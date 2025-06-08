using Microsoft.EntityFrameworkCore;
using PreventPlus.Data;
using Microsoft.OpenApi.Models;
using PreventPlus.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<PreventPlusContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IAlertaService, AlertaService>();
builder.Services.AddScoped<IChecklistService, ChecklistService>();
builder.Services.AddScoped<IDicaService, DicaService>();
builder.Services.AddScoped<IHistoricoRiscoService, HistoricoRiscoService>();
builder.Services.AddScoped<IKitService, KitService>();
builder.Services.AddScoped<ILocalFavoritoService, LocalFavoritoService>();
builder.Services.AddScoped<ILocalSeguroService, LocalSeguroService>();
builder.Services.AddScoped<INotificacaoService, NotificacaoService>();
builder.Services.AddScoped<IRegiaoService, RegiaoService>();
builder.Services.AddScoped<ITipoDesastreService, TipoDesastreService>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();



builder.Services.AddRazorPages();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();



builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "PreventPlus API",
        Version = "v1",
        Description = "API de prevenção e educação para desastres naturais"
    });
});

var app = builder.Build();

// Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "PreventPlus API v1");
    });
}

app.UseStaticFiles();
app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();
app.MapControllers();

app.Run();