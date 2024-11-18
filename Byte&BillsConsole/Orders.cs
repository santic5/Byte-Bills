using CommandLine;

[Verb("crear", HelpText = "Crear una nueva orden.")]
class OrdenCrearOptions
{
    [Option('t', "type", Required = true, HelpText = "Tipo de orden.")]
    public string Type { get; set; }
}

[Verb("eliminar", HelpText = "Eliminar órdenes.")]
class OrdenEliminarOptions { }

[Verb("revisar", HelpText = "Revisar órdenes.")]
class OrdenRevisarOptions
{
    [Option('a', "all", Default = false, HelpText = "Revisar todas las órdenes.")]
    public bool All { get; set; }

    [Option('f', "first", Default = true, HelpText = "Revisar solo la primera orden")]
    public bool Open { get; set; }
}
