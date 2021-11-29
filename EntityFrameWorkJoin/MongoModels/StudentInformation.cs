using MongoDB.Bson;
using RobotCloud.CoreMongoDb.MNVN;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EntityFrameWorkJoin.MongoModels
{
   public class StudentInformation: IEntityUseObjectId
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Sex { get; set; }
        public int YearOfBirth { get; set; }
        ObjectId IEntityUseObjectId.Id { get ; set ; }
    }
}
