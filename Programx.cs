using System;
using System.ComponentModel.DataAnnotations;

class Programx
{
    static void Mainx()
    {
        Person person = new Person();

        // Exemplo de entrada do usuário
        Console.Write("Digite o nome: ");
        person.Name = Console.ReadLine();

        // Validação usando anotações de dados
        var validationContext = new ValidationContext(person, serviceProvider: null, items: null);
        var validationResults = new System.Collections.Generic.List<ValidationResult>();

        if (Validator.TryValidateObject(person, validationContext, validationResults, validateAllProperties: true))
        {
            Console.WriteLine("Dados válidos. Nome: " + person.Name);
        }
        else
        {
            foreach (var validationResult in validationResults)
            {
                Console.WriteLine(validationResult.ErrorMessage);
            }
        }
    }
}

class Person
{
    [Required(ErrorMessage = "O nome é obrigatório.")]
    public string Name { get; set; }
}
