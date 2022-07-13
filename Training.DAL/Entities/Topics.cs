namespace Training.DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Topics
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Topics()
        {
            Marks = new HashSet<Marks>();
        }

        [Key]
        public int TopicID { get; set; }

        [StringLength(50)]
        public string TopicName { get; set; }

        [Column(TypeName = "text")]
        public string Topic { get; set; }

        public int SequenceNumber { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Marks> Marks { get; set; }

        public virtual Tests Tests { get; set; }
    }
}
