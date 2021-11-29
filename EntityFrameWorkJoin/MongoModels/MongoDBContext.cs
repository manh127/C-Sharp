using RobotCloud.CoreMongoDb;
using RobotCloud.CoreMongoDb.MNVN;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFrameWorkJoin.MongoModels
{
    public class MongoDBContext : BaseMongoUseObjectIdDbContext
    {
        public MongoDBContext() : base("118.70.117.208", "ManhTest", "sysadmin", "1234a@A") { }

        public DbSetUseObjectId<StudentInformation> StudentInformation { get; set; }
        public DbSetUseObjectId<ClassStudent> ClassStudent { get; set; }
        public DbSetUseObjectId<Classes> Classes { get; set; }
    }
}
