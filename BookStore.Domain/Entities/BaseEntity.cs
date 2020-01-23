using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BookStore.Domain.Entities
{
    public abstract class BaseEntity // Base para as demais tabelas do banco
    {
        [Key]
        public Guid Id { get; set; }
        private DateTime? _createAt  { get; set; }
        public DateTime? _Update { get; set; }

    }
}
