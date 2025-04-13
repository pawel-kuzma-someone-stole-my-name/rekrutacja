namespace Rekrutacja.Models;

public class OrdersDTO
{
    public int Id { get; set; }
    public string Code { get; set; }
    public string Status { get; set; }
}

public class UpdateOrderStatusDTO
{
    public string Status { get; set; }
}
