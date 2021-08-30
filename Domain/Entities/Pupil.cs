using Domain.Entities.Abstract;
using System;

namespace Domain.Entities
{
    public class Pupil : IEntity
    {
        public int ID { get; set; }
        public int GroupID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PatronymicName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Parents { get; set; }
        public string ContactPhones { get; set; }
        public bool IsActive { get; set; }
        public DateTime DateCreate { get; set; }
        public DateTime? DateModify { get; set; }


        //Navigation
        public virtual Group Group { get; set; }
    }
}
