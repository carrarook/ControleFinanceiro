namespace ControleFinanceiro.DTOs
{
    public class TransacaoPatchDTO
    {
        public decimal? Valor { get; set; }
        public DateTime? Data { get; set; }
        public int? CategoriaId { get; set; }
    }
}
