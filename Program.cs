using BCrypt.Net;


namespace ProjetoMensagem;

class Program
{
    public static void Main()
    { 

        User user = GUI.GetUser();

        if (!GUI.Login(user))
            return;

        GUI.ReceiveMessages(user);

    }

    // A responsabilidade de imprimir uma mensagem é da entidade responsavel / que conhece o retângulo em que ela será inserida
    

}

public class GUI
{
    public static User GetUser()
    {
        Console.WriteLine("-------Criando a conta-----");
        Console.Write("Usuario: ");
        var userName = Console.ReadLine();
        Console.Write("Senha: ");
        var passwordHashed = Console.ReadLine() ?? "";
        passwordHashed = Crypto.Encrypt(passwordHashed);

        return new() { Id = "1", Name = userName, UserName = userName, Password = passwordHashed };
    }

    public static bool Login(User user)
    {
        Console.WriteLine("-----------Logando---------");
        Console.Write("Senha de " + user.UserName + ": ");
        var password = Console.ReadLine() ?? "";
        if (!Crypto.Verify(password, user.Password))
        {
            Console.WriteLine("Senha inválida");
            return false;
        }
        Console.WriteLine("\nLogin efetuado com sucesso!\n");
        return true;
    }

    public static void ReceiveMessages(User user)
    {
        string entrada;
        do
        {
            entrada = Console.ReadLine() ?? "";

            if (entrada != "")
            {
                Mensagem mensagem = new()
                {
                    Id = 1,
                    Content = entrada,
                    RemetentId = user.Id,
                    CreatedAt = DateTime.Now,
                };

                ImprimeMensagem(mensagem, user);
            }


        } while (entrada != ".quit");
    }

    private static void ImprimeMensagem(Mensagem mensagem, User user)
    {
        Console.ResetColor();

        Console.WriteLine();
        Console.WriteLine("\x1b[1;32m" + user.Name + ":");
        Console.WriteLine("\x1b[1;33m" + "  " + mensagem.Content);
        if (mensagem.CreatedAt != null)
            Console.WriteLine("\x1b[1;36m" + "                                " + mensagem.CreatedAt.Value.Hour + ":" + mensagem.CreatedAt.Value.Minute);
        Console.WriteLine();
        Console.ResetColor();
    }
}

/*
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
 */