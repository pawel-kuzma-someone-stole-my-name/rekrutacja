using Rekrutacja.Models;

namespace Rekrutacja.Endpoints;

public static class Orders
{
    // SCHEMAT FLOW APLIKACJI
    // - Urzywamy repozytorium do pobrania dokumentów
    // - Serwisy do logiki biznesowej
    // - Relacja Endpoint --> serwis --> repozytorium

    // VALIDACJA
    // Stworzył był ActionFiltr ktory by walidował request
    // - na poziomie modelbinding, starałbym się przepuścić wszystko co się da aby request doleciał do filtra
    // - nie uzywałbym atrybutów na modelu dto do validowania requestu
    // - kumulował bym błedy do listy i zwracał koperte z listą błędów status code 400
    // - podczas pracy w serwisach uzywal bym try catch ktore by wrapowaly repozytoria, obslugiwalbym w ten sposob wyjatki zwiazane z baza danych / logika biznesowa, rzucal roznego radzaju exception, ktore by byly mapowane na odpowiednie status code w middleware 404/422 etc
    // - do validacji dostepnosci (401 403) nadpisal bym autentitacion / autorization filter

    public static IResult GetOrders(int page, int pageSize)
    {
        return Results.Ok($"GetOrders page: {page}  code: {pageSize}");
    }

    public static IResult GetOrdersByName(string code)
    {
        return Results.Ok($"GetOrdersByName code: {code}");
    }

    public static IResult GetOrdersByNameAndStatus(string? code, string? status)
    {
        return Results.Ok($"GetOrdersByNameAndStatus status: {status}  code: {code}");
    }

    public static IResult CreateOrders(OrdersDTO request)
    {
        return Results.Ok($"CreateOrders request: {System.Text.Json.JsonSerializer.Serialize(request)}");
    }

    public static IResult UpdateOrders(OrdersDTO request)
    {
        return Results.Ok($"UpdateOrders request: {System.Text.Json.JsonSerializer.Serialize(request)}");
    }

    public static IResult DeleteOrders(string code)
    {
        return Results.Ok($"DeleteOrders code: {code}");
    }

    public static IResult PatchStatusOrders(UpdateOrderStatusDTO status)
    {
        return Results.Ok($"PatchStatusOrders status: {status}");
    }
}