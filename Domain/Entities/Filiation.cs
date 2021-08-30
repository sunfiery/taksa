using Domain.Entities.Abstract;
using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Filiation : IEntity
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public DateTime DateCreate { get; set; }
        public DateTime? DateModify { get; set; }

        //Navigation
        public virtual ICollection<Group> Groups { get; set; }

    }
}
