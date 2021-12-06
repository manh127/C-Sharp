using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace EntityFrameWorkJoin.MongoModels
{
        public  class RepositoryClassMongo
    {
       public bool CreateClass( string name,int grade)
        {
            try
            {
                var ClassInfor = new Classes
                {
                    Id = Guid.NewGuid(),
                    Name=name,
                    Grade=grade
                };
                using (var db = new MongoDBContext())
                {
                    db.Classes.Collection.InsertOne(ClassInfor);
                }
                return true;
            }
            catch (Exception e)
            {
                return false;
                throw;
            }
        }
       public ClassModelsMongo GetInformation(Guid id)
        {
            try
            {
                using (var db = new MongoDBContext())
                {
                    var classInfor = db.Classes.Where(x => x.Id == id).FirstOrDefault();
                    if(classInfor!=null)
                    {
                        return new ClassModelsMongo
                        {
                            Id=id,
                            Name=classInfor.Name
                        };
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
       public bool UpdateClass (Guid id , string name , int grade )
        {
            try
            {
                var classInfo = new Classes
                {
                    Id=id,
                    Name=name,
                    Grade=grade
                };
                using(var db = new MongoDBContext())
                {
                    classInfo = db.Classes.Where(x => x.Id == id).FirstOrDefault();
                    if(classInfo!=null)
                    {
                        classInfo.Name = name;
                        classInfo.Grade = grade;
                        db.Classes.Update(classInfo);
                    }
                    else
                    {
                        return false;
                    }
                }
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
       public bool DeleteClass(Guid id)
        {
            try
            {      
                using(var db = new MongoDBContext())
                {
                    var removeClass = db.Classes.Where(x => x.Id == id).FirstOrDefault();
                    if(removeClass==null)
                    {
                        return false;
                    }
                    else
                    {
                        db.Classes.Delete(removeClass);
                    }
                }
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
