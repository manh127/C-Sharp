using MongoDB.Bson;
using RobotCloud.CoreMongoDb.MNVN;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EntityFrameWorkJoin.MongoModels
{
    public class ClassStudent: IEntityUseObjectId
    {
        public Guid Id { get; set; }
      
        public Guid IdStudent { get; set; }

        public Guid  IdClass { get; set; }
        ObjectId IEntityUseObjectId.Id { get ; set ; }
    }
}
