using RobotCloud.CoreMongoDb.MNVN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreApi.Models
{
    public class MongoDBContext : BaseMongoUseObjectIdDbContext
    {
        public MongoDBContext() : base("localhost", "Manh1999", "useradmin", "manh1999") { }
        public DbSetUseObjectId<Student> Students { get; set; }
        public DbSetUseObjectId<ClassStudent> ClassStudents { get; set; }
        public DbSetUseObjectId<Classes> Classes { get; set; }
    }
}
