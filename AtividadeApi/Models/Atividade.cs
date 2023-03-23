namespace AtividadeApi.Models
{
    public class Atividade
    {
        public int Id { get; set; }
        public string NomeAtividade { get; set; } // Nome da atividade
        public DateTime InicioAtividade { get; set; } // Data inicial da atividade com horas
        public DateTime FimAtividade { get; set;} // Data final da atividade com horas
        public string HorasAtividade { get; set; } // Em String para se ter mais controle - duração da atividade
    }
}
