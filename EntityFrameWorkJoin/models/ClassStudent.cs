using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EntityFrameWorkJoin.models
{
    [Table("classstudent")]
    public class ClassStudent
    {
        [Column(TypeName = "varchar(40)")]
        [Key]
        public Guid Id { get; set; }
        [Column(TypeName = "varchar(40)")]
        public Guid IdStudent { get; set; }
        [Column(TypeName = "varchar(40)")]
        public Guid  IdClass { get; set; }
    }
}
