using WebApiRifa.Entidades;

namespace WebApiRifa.Services
{
    public interface IService
    {
        List<Cartas> EjecutarSeleccion(List<Cartas> cartas);

    }

    public class ServicioSelecciones : IService
    {
        public List<Cartas> EjecutarSeleccion(List<Cartas> Cartas)
        {
            Random random = new Random();
            List<Cartas> lista = new List<Cartas>();
            for (int i = 0; i < Cartas.Count; i++)
            {
                int indice = random.Next(0, Cartas.Count);
                lista.Add(Cartas[indice]);
                Cartas.Remove(Cartas[indice]);
            }
            return Cartas;

        }
    }
}
