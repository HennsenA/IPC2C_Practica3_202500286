namespace VeterinariaApp.Models
{
    public class Gato : Mascota { 
    private String raza { get; set; }
    private String esterilizado { get; set; }

    public Gato(String nombre, double peso, String sexo, int edad, String propietario, String estado, String raza, String esterilizado)
        : base(nombre, peso, sexo, edad, propietario, estado)
    {
        this.raza = raza;
        this.esterilizado = esterilizado;
    }

    public override double CalcularPorcentaje()
    {
        return 0.90;
    }

    public override void ImprimirInfo()
    {
        String informacion = 
            $"""

            Codigo: {codigo}
            Mascota: {nombre}
            Peso: {peso}
            Sexo: {sexo}
            Edad: {edad}
            Propietario: {propietario}
            Estado: {estado}
            Raza: {raza}
            Esterilizado: {esterilizado}

            """;

        Console.WriteLine(informacion);
    }
}
}