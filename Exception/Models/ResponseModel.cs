namespace Exception.Models;

public class ResponseModel
{
    public bool Success { get; set; } = false;
    public object? Data { get; set; } = null;
    public string Message { get; set; } = String.Empty;
}