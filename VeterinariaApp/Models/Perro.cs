namespace VeterinariaApp.Models
{
    public class Perro : Mascota
{
    private String raza { get; set; }
    private String tamanio { get; set; }
    public Perro(String nombre, double peso, String sexo, int edad, String propietario, String estado, String raza, String tamanio)
        : base(nombre, peso, sexo, edad, propietario, estado)
    {
        this.raza = raza;
        this.tamanio = tamanio;
    }
}
}