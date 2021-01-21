using System;
using System.Collections.Generic;
using System.Text;

namespace PsuHistoryWeb.Domain.Entities.Histories
{
    public class Form : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
    }
}
