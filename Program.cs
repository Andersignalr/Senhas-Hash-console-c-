using BCrypt.Net;


namespace ProjetoMensagem;

class Program
{
    public static void Main()
    {
        // Exemplo de registro: Hash da senha
        string senhaDoUsuario = "senha123";
        string hashDaSenha = Crypto.Encrypt(senhaDoUsuario);

        // Exemplo de login: Verificar a senha
        string senhaInseridaPeloUsuario = "senha123";
        bool senhaCorreta = Crypto.Verify(senhaInseridaPeloUsuario, hashDaSenha);

        if (senhaCorreta)
        {
            Console.WriteLine("Login bem-sucedido!");
        }
        else
        {
            Console.WriteLine("Credenciais inválidas.");
        }

    }
}

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

public class Mensagem
{
    public int Id;
    public string? Content;
    public string? RemetentId;
    public DateTime? CreatedAt;
}

public class User
{
    public int Id;
    public string? Name;
    public string? UserName;
    public string? Password;
}