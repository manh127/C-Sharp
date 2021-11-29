using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFrameWorkJoin.MongoModels
{
      public class RepositoryStudentMongo
    {
        public bool Create(string name, string sex, int yearOfBirth)
        {
            try
            {
                var student = new StudentInformation
                {
                    Id = Guid.NewGuid(),
                    Name = name,
                    Sex = sex,
                    YearOfBirth = yearOfBirth
                };
                using (var db = new MongoDBContext())
                {
                    db.StudentInformation.Collection.InsertOne(student);
                }
                return true;
            }
            catch (Exception E)
            {
                return false;
            }
        }
    }
}
