namespace Training.DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TestQuestions
    {
        [Key]
        public int QuestionID { get; set; }

        public string Question { get; set; }

        [StringLength(50)]
        public string Answer_1 { get; set; }

        [StringLength(50)]
        public string Answer_2 { get; set; }

        [StringLength(50)]
        public string Answer_3 { get; set; }

        [StringLength(50)]
        public string Answer_4 { get; set; }

        [StringLength(50)]
        public string Correct_answer { get; set; }

        public int? TestID { get; set; }

        public virtual Tests Tests { get; set; }
    }
}
