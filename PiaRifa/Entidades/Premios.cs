namespace WebApiRifa.Entidades
{
    public class Premios
    {
        public int Id { get; set; }

        public string premios { get; set; }

        public int RifaId  { get; set; }
        public Rifa Rifa { get; set; }
    }
}
