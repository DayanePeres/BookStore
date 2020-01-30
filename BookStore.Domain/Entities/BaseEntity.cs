using System;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Domain.Entities
{
    public abstract class BaseEntity // Base para as demais tabelas do banco
    {
        [Key]
        public Guid Id { get; set; }
        private DateTime? _createAt  { get; set; }
        public DateTime? _Update { get; set; }

        public DateTime? CreateAt
        {
            get { return _createAt; }
            set { _createAt = (value == null ? DateTime.UtcNow : value); }
        }
        public DateTime? UpdateAt { get; set; }
    }
}
