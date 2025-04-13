namespace Rekrutacja.Endpoints;

public static class Documents
{
    public static IResult GetDocuments()
    {
        // Urzywamy repozytorium do pobrania dokumentów
        return Results.Ok($"GetDocuments");
    }

    public static IResult GetDocumentsById(int? id)
    {
        return Results.Ok($"GetDocumentsById id: {id}");
    }

    public static IResult GetDocumentsByName(string? name)
    {
        return Results.Ok($"GetDocumentsByName name: {name}");
    }
}