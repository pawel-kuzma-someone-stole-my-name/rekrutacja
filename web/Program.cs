using Rekrutacja.Endpoints;
using Rekrutacja.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// BAZADANYCH
// polaczenie z baza dancych
// preferuje micro ORM nad EF
// chyba ze dostalbym zapewnienie ze API bezdie czyms na zasadzie mikroserwisu i nigdy nie wyjdzie po za obszar domeny dokumentow - wtym przypadku poszedl bym w stronę migracji i code first
// w innym przypadku urzyl bym micro ORM np Dapper, schemat bazy danych tj skrypty tworzace inicjujace dodal bym do repo
// sama baze wybral bym po konsultacji z devopsami klienta / istniejaca architektura / wymaganiami co do ilosci danych / wymaganiami w stosunku do regionu świata

// WYJATKI, RESPONSY, BLEDY
// middleware do przechwytywania wszystkich wyjątków
// - jezeli wpadnie do niego blad z listy bledow to procesuj dalej zgodnie z bledem i przemapuj na koperte zgodna z danym 4xx status code
// - jezeli wpadnie do niego blad z naszego try catch to procesuj dalej zgodnie z bledem i przemapuj na koperte zgodna z danym 4xx status code
// - jezeli wpadnie do niego blad ogólny Exception niezgodny z powyzszym przemapuj na koperte z ogolnym bledem 400

// CLIENT HTTP
// uzywal bym wbudowanego IHttpClientFactory oraz HttpClient zamiast frameworkow takich jak np RestSharp

// MAPOWANIE DTO
// mapowanie reczne / w ramach klasy DTO 
// nie uzywal bym automappera

// KOPERATA kazdy response z aplikacji powinien posiadac koperte z modelem response, traceid, lista bledow

app.UseHttpsRedirection();

app.MapGet("/orders", (int page, int pageSize) => Orders.GetOrders(page, pageSize))
.WithName("GetOrders")
.WithOpenApi();

app.MapGet("/orders/{code}", (string code) => Orders.GetOrdersByName(code))
.WithName("GetordersByName")
.WithOpenApi();

app.MapGet("/orders/{code}/{status}", (string code, string status) => Orders.GetOrdersByNameAndStatus(code, status))
.WithName("GetordersByNameAndStatus")
.WithOpenApi();

app.MapPost("/orders", (OrdersDTO request) => Orders.CreateOrders(request))
.WithName("Createorders")
.WithOpenApi();

app.MapPut("/orders", (OrdersDTO request) => Orders.UpdateOrders(request))
.WithName("Updateorders")
.WithOpenApi();

app.MapDelete("/orders/{code}", (string code) => Orders.DeleteOrders(code))
.WithName("Deleteorders")
.WithOpenApi();

app.MapPatch("/orders", (UpdateOrderStatusDTO request) => Orders.PatchStatusOrders(request))
.WithName("PatchStatusOrders")
.WithOpenApi();

app.Run();

