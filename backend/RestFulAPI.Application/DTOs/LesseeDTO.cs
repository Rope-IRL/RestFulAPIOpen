namespace RestFulAPI.Application.DTOs;

public class LesseeDTO : ICanHaveToken
{
    public int? Id { get; set; }

    public string Login { get; set; }
    
    public string Password { get; set; }
    
    public string? Email { get; set; }
    
    public string? Name { get; set; }
    
    public string? Token {  get; private set; }

    public string? Role { get; private set; } = "lessee";

    public string RoleForToken()
    {
        return Role;
    }

    public string NameForToken()
    {
        return Name == null ? Login : Name;
    }

    public int UserId()
    {
        return (int)Id;
    }

    public void SetToken(string token)
    {
        Token = token;
    }
}