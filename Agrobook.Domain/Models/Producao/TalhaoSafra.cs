using Agrobook.Domain.Core.Models;

namespace Agrobook.Domain.Models.Producao
{
    public class TalhaoSafra : Entity<TalhaoSafra>
    {
        public int TalhaId {  get; set; }
        public Talhao Talhao {  get; set; }
        public int SafraId {  get; set; }
        public Safra Safra {  get; set; }
    }
}
