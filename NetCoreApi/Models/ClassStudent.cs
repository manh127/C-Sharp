using MongoDB.Bson;
using RobotCloud.CoreMongoDb.MNVN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreApi.Models
{
        public class ClassStudent : IEntityUseObjectId
        {
            public Guid Id { get; set; }

            public Guid IdStudent { get; set; }

            public Guid IdClass { get; set; }
            ObjectId IEntityUseObjectId.Id { get; set; }
        }
}
