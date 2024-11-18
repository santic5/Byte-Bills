using CommandLine;

[Verb("crear", HelpText = "Crear una nueva reserva.")]
class ReservaCrearOptions
{
    [Option('i', "id", Required = true, HelpText = "Identificacion de quien creo la reserva.")]
    public int Id { get; set; }

    [Option('f', "fecha", Required = true, HelpText = "Fecha de la reserva (DD-MM-YYYY 00:00 24h).")]
    public string Fecha { get; set; }
}

[Verb("verificar", HelpText = "Verificar una reserva existente.")]
class ReservaVerificarOptions
{
    [Option('i', "id", Required = true, HelpText = "Identificacion de quien creo la reserva.")]
    public int Id { get; set; }

    [Option('f', "fecha", Required = true, HelpText = "Fecha de la reserva (YYYY-MM-DD).")]
    public string Fecha { get; set; }
}

[Verb("eliminar", HelpText = "Eliminar una reserva.")]
class ReservaEliminarOptions
{
    [Option('i', "id", Required = true, HelpText = "Identificacion de quien creo la reserva.")]
    public int Id { get; set; }

    [Option('f', "fecha", Required = true, HelpText = "Fecha de la reserva (YYYY-MM-DD).")]
    public string Fecha { get; set; }
}

[Verb("mostrar", HelpText = "Mostrar todas las reservas.")]
class ReservaMostrarOptions { }

[Verb("cantidad", HelpText = "Mostrar la cantidad de reservas.")]
class ReservaCantidadOptions { }

[Verb("purgar", HelpText = "Eliminar todas las reservas.")]
class ReservaPurgarOptions { }
