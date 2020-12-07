using System;
using System.Collections.Generic;
using System.Text;

namespace PsuHistoryWeb.Domain.Entities.Histories
{
    public class AttachmentForm : BaseEntity
    {
        public string Path { get; set; }
        public string FileType { get; set; }

        public int FormId { get; set; }
        public virtual Form Form { get; set; }
    }
}
