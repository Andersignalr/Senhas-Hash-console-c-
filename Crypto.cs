namespace ProjetoMensagem;

public static class Crypto
{
    public static string Encrypt(string input)
    {
        if(input != "")
            return BCrypt.Net.BCrypt.HashPassword(input);

        return "";
    }

    public static bool Verify(string input, string hash)
    { 
        if(input != "" && hash != "") 
            return BCrypt.Net.BCrypt.Verify(input, hash);

        return false;
    }
}
