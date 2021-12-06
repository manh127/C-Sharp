using MongoDB.Bson;
using RobotCloud.CoreMongoDb.MNVN;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFrameWorkJoin.MongoModels
{
    public class StudentModelsMongo
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
