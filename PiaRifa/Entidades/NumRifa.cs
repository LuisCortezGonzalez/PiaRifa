namespace WebApiRifa.Entidades
{
    public class NumRifa
    {
        public int Id { get; set; }

        public int NumeroRifa { get; set; }

        public int ParticipanteId { get; set; }

        public Participante Participante { get; set; }

    }
}
