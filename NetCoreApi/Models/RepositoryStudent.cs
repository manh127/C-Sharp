using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetCoreApi;
namespace NetCoreApi.Models
{
    public class RepositoryStudent
    {
        public bool Create(string name, string sex, int yearOfBirth)
        {
            try
            {
                var student = new Student
                {
                    Id = Guid.NewGuid(),
                    Name = name,
                    Sex = sex,
                    YearOfBirth = yearOfBirth
                };
                using (var db = new MongoDBContext())
                {
                    db.Students.Collection.InsertOne(student);
                }
                return true;
            }
            catch (Exception E)
            {
                return false;
            }
        }
        public StudentModels GetStudentInfor(Guid id)
        {
            try
            {
                using (var db = new MongoDBContext())
                {
                    var StudentInfor = db.Students.Where(x => x.Id == id).FirstOrDefault();
                    if (StudentInfor != null)
                    {
                        return new StudentModels
                        {
                            Id = id,
                            Name = StudentInfor.Name,
                        };
                    }
                }
                return null;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public bool UpdateStudent(Guid id, String name, string sex, int yearofbirth)
        {
            try
            {
                var student = new Student
                {
                    Id = id,
                    Name = name,
                    Sex = sex,
                    YearOfBirth = yearofbirth
                };
                using (var db = new MongoDBContext())
                {
                    student = db.Students.Where(x => x.Id == id).FirstOrDefault();
                    if (student != null)
                    {
                        student.Name = name;
                        student.Sex = sex;
                        student.YearOfBirth = yearofbirth;
                        db.Students.Update(student);
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
        public bool DeleteStudent(Guid id)
        {
            try
            {
                using (var db = new MongoDBContext())
                {
                    var removeStudent = db.Students.Where(x => x.Id == id).FirstOrDefault();
                    if (removeStudent != null)
                    {
                        db.Students.Delete(removeStudent);
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
        public bool AddStudentToClass(Guid studentId, Guid clasId)
        {
            try
            {

                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}

