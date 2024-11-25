namespace M295_TodoServiceAndAutomapper.Domain;

public class AuthResult
{
    public string Token { get; set; }
    public bool Success { get; set; }
    public List<string> Errors { get; set; }
}