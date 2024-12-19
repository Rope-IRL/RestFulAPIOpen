using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace RestFulAPI.Application.Services;

public class Authenticate
{
    public const string ISSUER = "Publisher";
    public const string AUDIENCE = "Org";
    private const string key = "somesecretkeyveryverysecretasdfasdsdf";
    public const int LIFETIME = 300;

    public static SymmetricSecurityKey GetSymmetricKey()
    {
        return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key));
    }
}