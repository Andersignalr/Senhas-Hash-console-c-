class Person : IValidatableObject
{
    [Required(ErrorMessage = "O nome é obrigatório.")]
    [StringLength(20, ErrorMessage = "O nome não pode ter mais de 20 caracteres.")]
    [RegularExpression("^[a-zA-Z0-9]+$", ErrorMessage = "O nome deve conter apenas letras e números.")]
    [MinLength(5, ErrorMessage = "O nome deve ter no mínimo 5 caracteres.")]
    public string Name { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (string.IsNullOrWhiteSpace(Name))
        {
            yield return new ValidationResult("O nome não pode conter espaços em branco.");
        }

        if (!Name.EndsWith(":"))
        {
            yield return new ValidationResult("O nome deve terminar com dois pontos (:).");
        }
    }