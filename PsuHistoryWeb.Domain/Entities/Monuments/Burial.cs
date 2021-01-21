using System;
using System.Collections.Generic;
using System.Text;

namespace PsuHistoryWeb.Domain.Entities.Monuments
{
    public class Burial : BaseEntity
    {
        public int NumberBurial { get; set; }
        public string Location { get; set; }
        public int NumberPeople { get; set; }
        public int UnknownNumber { get; set; }
        public int Year { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Description { get; set; }

        public int TypeBurialId { get; set; }
        public virtual TypeBurial TypeBurial { get; set; }
    }
}
