using Agrobook.Domain.Core.Models;

namespace Agrobook.Domain.Models
{
    public class Colaborador : Entity<Colaborador>
    {
        public string Nome { get; set; }
        public string Email { get; set; }
    }
}
