using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.Abstract
{
    public interface IEntity
    {
        [Key]
        public int ID { get; set; }
        public DateTime DateCreate { get; set; }
        public DateTime? DateModify { get; set; }
    }
}
