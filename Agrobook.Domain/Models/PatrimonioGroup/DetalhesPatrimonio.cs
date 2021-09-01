﻿namespace Agrobook.Domain.Models.PatrimonioGroup
{
    using Agrobook.Domain.Core.Models;

    public class DetalhesPatrimonio : Entity<DetalhesPatrimonio>
    {
        public int Observacao {  get; set; }

        public int PatrimonioId {  get; set; }
        public Patrimonios Patrimonio {  get; set; }
    }
}
