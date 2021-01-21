using System;
using System.Collections.Generic;
using System.Text;

namespace PsuHistoryWeb.Domain.Entities.Monuments
{
    public class Victim : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public bool IsHeroSoviet { get; set; }
        public bool IsPartisan { get; set; }
        public string DateOfBirth { get; set; }
        public string DateOfDeath { get; set; }

        public int TypeVictimId { get; set; }
        public int DutyStationId { get; set; }
        public int BirthPlaceId { get; set; }
        public int ConscriptionPlaceId { get; set; }
        public int BurialId { get; set; }
        public virtual TypeVictim TypeVictim { get; set; }
        public virtual DutyStation DutyStation { get; set; }
        public virtual BirthPlace BirthPlace { get; set; }
        public virtual ConscriptionPlace ConscriptionPlace { get; set; }
        public virtual Burial Burial { get; set; }
    }
}
