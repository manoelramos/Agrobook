namespace Agrobook.Domain.Core.Models
{
    using FluentValidation;
    using FluentValidation.Results;
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Text.Json.Serialization;

    public class Entity<T> : AbstractValidator<T> where T : Entity<T>
    {
        public int Id { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool Ativo { get; set; } = true;

        [NotMapped]
        [JsonIgnore]
        public ValidationResult ValidationResult { get; protected set; } = new ValidationResult();

        public virtual bool IsValid() => true;

        public override bool Equals(object obj)
        {
            if (obj is not Entity<T> compareTo) return false;

            if (ReferenceEquals(this, compareTo)) return true;

            return Id.Equals(compareTo.Id);
        }        

        public static bool operator ==(Entity<T> a, Entity<T> b)
        {
            if (a is null && b is null)
                return true;

            if (a is null || b is null)
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(Entity<T> a, Entity<T> b) => !(a == b);

        public override int GetHashCode() => (GetType().GetHashCode() * 907) + Id.GetHashCode();

        public override string ToString() => $"{GetType().Name} [Id={Id}]";
    }
}
