namespace VeterinariaApp.Models
{
    public class Lista
    {
        public NodoLista? Inicio{get; set;}
        
        public Lista()
        {
            Inicio = null;
        }

        public void Insertar(Mascota mascota)
        {
            string codigo = GenerarCodigo();
            if (Inicio == null)
            {
                mascota.codigo = codigo;
                Inicio = new NodoLista(mascota);
            }
            else
            {
                var actual = Inicio;

                while (actual.Siguiente != null)
                {
                    actual = actual.Siguiente;
                }
                actual.Siguiente = new NodoLista(mascota);//Insercion de nuevo elemento
            }
        }

        public void Eliminar(string codigo)//Eliminacion de un nodo por codigo
        {
            var actual = Inicio;

            while (actual.Siguiente != null)
            {
                if(actual.Siguiente.Paciente.codigo == codigo)
                {
                    //Cambio de puntero para eliminar el nodo de la lista
                    actual.Siguiente = actual.Siguiente.Siguiente;
                    return;
                }
                actual = actual.Siguiente;
            }

            Console.WriteLine("No se encontro el nodo a eliminar");
        }

        public string ImprimirLista()//Realizar la concatenacion de la informacion de la lista para imprimirla
        {
            return "";
        }

        public NodoLista Buscar(string codigo)//Funcion de busqueda, retorna el nodo
        {
            var actual = Inicio;

            while(actual != null)
            {
                if (actual.Paciente.codigo == codigo)
                {
                    return actual;
                }
                actual = actual.Siguiente;
            }

            return actual;
        }

        public bool CambiarEstado(string codigo)
        {
            var nodo = Buscar(codigo);
            if (nodo != null)
            {
                if(nodo.Paciente.estado == "sano")
                {
                    nodo.Paciente.CambiarEstado("enfermo");
                }
                else
                {
                    nodo.Paciente.CambiarEstado("sano");
                }
                return true;
            }
            else
            {
                Console.WriteLine("No se encontro el nodo a actualizar");
                return false;
            }
        }

        private string GenerarCodigo()//Generacion de codigo para mascota
        {
            return "";
        }

        public double CalcularDosis(string codigo, double dosis_por_kg)
        {
            var nodo = Buscar(codigo);
            if (nodo != null)
            {
                return nodo.Paciente.CalculoDosis(dosis_por_kg);
            }
            else
            {
                Console.WriteLine("No se encontro el nodo para calcular la dosis");
                return 0.0;
            }
        }

        public bool EditarInfo(string codigo, string nombre, double peso, string sexo, int edad, string propietario)
        {
            var nodo = Buscar(codigo);
            if (nodo != null)
            {
                nodo.Paciente.nombre = nombre;
                nodo.Paciente.peso = peso;
                nodo.Paciente.sexo = sexo;
                nodo.Paciente.edad = edad;
                nodo.Paciente.propietario = propietario;
                return true;
            }
            else
            {
                Console.WriteLine("No se encontro el nodo para editar la informacion");
                return false;
            }
        }
    }
}