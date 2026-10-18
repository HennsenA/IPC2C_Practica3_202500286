namespace VeterinariaApp.Models
{
    public class Ave : Mascota { 
    private double envergadura { get; set; }
    private String vuela { get; set; }
    public Ave(String nombre, double peso, String sexo, int edad, String propietario, String estado, double envergadura, String vuela): base(nombre, peso, sexo, edad, propietario, estado)
    {
        this.envergadura = envergadura;
        this.vuela = vuela;
    }

    public override double CalcularPorcentaje()
    {
        return 0.50;
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
            Envergadura: {envergadura}
            Vuela: {vuela}

            """;

        Console.WriteLine(informacion);
    }
    }
}