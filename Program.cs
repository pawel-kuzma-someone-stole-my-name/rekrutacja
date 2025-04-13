using Rekrutacja.Endpoints;

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

app.UseHttpsRedirection();

app.MapGet("/documents", () => Documents.GetDocuments())
.WithName("GetDocumentsById")
.WithOpenApi();

app.MapGet("/documents", (int? id) => Documents.GetDocumentsById(id))
.WithName("GetDocumentsById")
.WithOpenApi();

app.MapGet("/documents", (string? name) => Documents.GetDocumentsByName(name))
.WithName("GetDocumentsByName")
.WithOpenApi();

app.MapGet("/documents", (string? name) => Documents.GetDocumentsByName(name))
.WithName("GetDocumentsByName")
.WithOpenApi();

app.Run();

