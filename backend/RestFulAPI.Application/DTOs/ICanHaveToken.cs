namespace RestFulAPI.Application.DTOs;

public interface ICanHaveToken
{
    public string RoleForToken();
    public string NameForToken();
    
    public int UserId();

}