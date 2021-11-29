using MongoDB.Bson;
using RobotCloud.CoreMongoDb.MNVN;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EntityFrameWorkJoin.models
{
    [Table("classes")]
    public class Classes
    {
        [Column(TypeName = "varchar(40)")]
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Grade { get; set; }
    }
}
