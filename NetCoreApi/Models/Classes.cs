using MongoDB.Bson;
using RobotCloud.CoreMongoDb.MNVN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreApi.Models
{
    public class Classes : IEntityUseObjectId
        {
            public Guid Id { get; set; }
            public string Name { get; set; }
            public int Grade { get; set; }
            ObjectId IEntityUseObjectId.Id { get; set; }
        }
}
