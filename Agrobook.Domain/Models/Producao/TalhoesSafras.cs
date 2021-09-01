using Agrobook.Domain.Core.Models;

namespace Agrobook.Domain.Models.Producao
{
    public class TalhoesSafras : Entity<TalhoesSafras>
    {
        public int TalhaId {  get; set; }
        public Talhoes Talhao {  get; set; }
        public int SafraId {  get; set; }
        public Safras Safra {  get; set; }
    }
}
