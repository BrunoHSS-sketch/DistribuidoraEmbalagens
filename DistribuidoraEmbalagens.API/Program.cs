using DistribuidoraEmbalagens.Infrastructure.Data;
using DistribuidoraEmbalagens.Infrastructure.Services;
using DistribuidoraEmbalagens.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using DistribuidoraEmbalagens.Infrastructure.Mappings;

var builder = WebApplication.CreateBuilder(args);

// Adiciona servi�os do Entity Framework com SQL Lite
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=distribuidora.db"));

// Adiciona AutoMapper com o perfil personalizado
builder.Services.AddAutoMapper(typeof(ProdutoProfile).Assembly);

// Injeta a implementa��o do servi�o de produto
builder.Services.AddScoped<IProdutoService, ProdutoService>();
// Injeta a implementa��o do servi�o de venda
builder.Services.AddScoped<IVendaService, VendaService>();

// AddControllers + Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();