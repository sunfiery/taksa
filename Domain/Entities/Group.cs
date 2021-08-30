using Domain.Entities.Abstract;
using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Group : IEntity
    {
        public int ID { get; set; }
        public int FiliationID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateCreate { get; set; }
        public DateTime? DateModify { get; set; }

        //Navigation
        public virtual Filiation Filiation { get; set; }
        public virtual ICollection<Pupil> Pupils { get; set; }
    }
}
