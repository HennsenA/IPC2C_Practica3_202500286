namespace VeterinariaApp.Models
{
    public class NodoLista
    {
        public Mascota Paciente{get; set;}
        public NodoLista? Siguiente{get; set;}

        public NodoLista(Mascota paciente)
        {
            Paciente = paciente;
            Siguiente = null;
        }
    }
}