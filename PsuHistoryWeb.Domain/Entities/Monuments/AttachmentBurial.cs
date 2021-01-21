using System;
using System.Collections.Generic;
using System.Text;

namespace PsuHistoryWeb.Domain.Entities.Monuments
{
    public class AttachmentBurial : BaseEntity
    {
        public string Path { get; set; }

        public int BurialId { get; set; }
        public virtual Burial Burial { get; set; }
    }
}
