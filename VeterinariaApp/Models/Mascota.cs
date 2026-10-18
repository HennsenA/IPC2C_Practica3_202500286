namespace VeterinariaApp.Models
{
    public class Mascota
{
    public String nombre { get; set; }
    public double peso { get; set; }
    public String sexo { get; set; }
    public int edad { get; set; }
    public String propietario { get; set; }
    public String codigo { get; set; }
    public String estado { get; set; }

    public Mascota(String nombre, double peso, String sexo, int edad, String propietario, String estado)
    {
        this.nombre = nombre;
        this.peso = peso;
        this.sexo = sexo;
        this.edad = edad;
        this.propietario = propietario;
        this.estado = estado;
    }

    public double CalculoDosis(double dosis_por_kg)
    {
        double reduccion = CalcularPorcentaje();
        double dosisBase = dosis_por_kg * peso;

        return reduccion*dosisBase;
    }
    public virtual double CalcularPorcentaje() { return 1.0; }

    public void CambiarEstado(String estado)
    {
        this.estado = estado;
    }

    public virtual void ImprimirInfo()
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

            """;

        Console.WriteLine(informacion);
    }
}
}