namespace WebApiRifa.Entidades
{
    public class RifaParticipante
    {
        public string RifaId { get; set; }
        
        public string ParticipanteId { get; set; }
        public string CartaId { get; set; }

        public Rifa Rifa { get; set; }

        public Participante Participante { get; set; }

        public Cartas Cartas { get; set; }
    }
}
