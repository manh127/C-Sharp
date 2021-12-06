using EntityFrameWorkJoin.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityFrameWorkJoin
{
   public class ClassRepository
    {
        public bool Create(string name , int grade)
        {
            try
            {
                var classes = new Classes
                {
                    Id = Guid.NewGuid(),
                    Name = name,
                    Grade = grade
                };
                using (var db = new MyDbContext())
                {
                    db.Classes.Add(classes);
                    db.SaveChanges();
                }
                    return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public ClassModels GetClassInfo(Guid id)
        {
            try
            {
                using (var db = new MyDbContext())
                {
                    var classInfo = db.Classes.Where(x => x.Id == id).FirstOrDefault();
                    if (classInfo != null)
                    {
                        return new ClassModels
                        {
                            Id = id,
                            Name = classInfo.Name
                        };
                    }
                    return null;
                }
            }
            catch (Exception)
            {

                return null;
            }
        }
        public bool Update(Guid id, string name, int grade)
        {
            try
            {
                var ClassUpdate = new Classes()
                {
                    Id=id,
                    Name=name,
                    Grade=grade
                };
                using(var db = new MyDbContext())
                {
                    ClassUpdate = db.Classes.Where(x => x.Id == id).FirstOrDefault();
                    if(ClassUpdate!=null)
                    {
                        ClassUpdate.Name = name;
                        ClassUpdate.Grade = grade;
                        db.Classes.Update(ClassUpdate);
                        db.SaveChanges();
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
        public bool Delete(Guid id)
        {
            try
            {
                using(var db =new MyDbContext())
                {
                    var DeleteCl = db.Classes.Where(x => x.Id == id).FirstOrDefault();
                    if(DeleteCl==null)
                    {
                        return false;
                    }
                    else
                    {
                        db.Classes.Remove(DeleteCl);
                        db.SaveChanges();
                    }
                }
                return true;
            }
            catch (Exception e)
            {

                return false;
            }
        }

    }
   
}
