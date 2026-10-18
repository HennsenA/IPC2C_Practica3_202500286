namespace VeterinariaApp.Models
{
    public class Tortuga : Mascota {
    private String caparazon;
    private String acuatica;

    public Tortuga(String nombre, double peso, String sexo, int edad, String propietario, String estado, String caparazon, String acuatica): base(nombre, peso, sexo, edad, propietario,estado) {
        this.caparazon = caparazon;
        this.acuatica = acuatica;
    }

    public override double CalcularPorcentaje()
    {
        return 0.80;
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
            Caparazon: {caparazon}
            Acuatica: {acuatica}

            """;

        Console.WriteLine(informacion);
    }
}
}