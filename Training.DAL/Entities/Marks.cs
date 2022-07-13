namespace Training.DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Marks
    {
        [Key]
        public int MarkID { get; set; }

        public int? TopicID { get; set; }

        public int? UserID { get; set; }

        public int Mark { get; set; }

        public virtual Topics Topics { get; set; }

        public virtual Users Users { get; set; }
    }
}
