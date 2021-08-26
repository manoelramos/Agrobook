namespace Agrobook.Domain.Core.Models
{
    using FluentValidation;
    using System;

    public class Entity<T> : AbstractValidator<T> where T : Entity<T>
    {
        public int Id {  get; set; }
        public DateTime AddedDate{  get; set; }
        public DateTime ModifiedDate {  get; set; }
        public bool Ativo{  get; set; }
    }
}
