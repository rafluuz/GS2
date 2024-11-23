namespace SustenAI.Models
{
    public class Alerta
    {
        public int IdAlerta { get; set; }

        public string TipoAlerta { get; set; }

        public string Mensagem { get; set; }

        public DateTime DataCriacao { get; set; }

        public string StatusAlerta  { get; set; }
    }
}