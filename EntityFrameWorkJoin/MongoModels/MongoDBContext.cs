using RobotCloud.CoreMongoDb;
using RobotCloud.CoreMongoDb.MNVN;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFrameWorkJoin.MongoModels
{
    public class MongoDBContext : BaseMongoUseObjectIdDbContext
    {
        public MongoDBContext() : base("127.0.0.1", "Manh1999", "useradmin", "manh1999") { }
        public DbSetUseObjectId<StudentInformation> StudentInformation { get; set; }
        public DbSetUseObjectId<ClassStudent> ClassStudent { get; set; }
        public DbSetUseObjectId<Classes> Classes { get; set; }
    }
}
