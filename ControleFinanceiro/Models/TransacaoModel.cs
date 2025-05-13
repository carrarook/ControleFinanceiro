using System.ComponentModel.DataAnnotations;
namespace ControleFinanceiro.Models
{
    public class TransacaoModel
    {
        [Key]
        public string TransacaoId { get; set; }
        public string UserId { get; set; }
        public int CategoriaId { get; set; }

        public decimal Valor { get; set; }
        public DateTime Data { get; set; }
    }
}
