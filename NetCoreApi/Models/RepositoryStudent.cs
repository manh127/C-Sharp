using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetCoreApi;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
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
            catch (Exception )
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
            catch (Exception )
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
        public async Task<bool> AddStudentToClass(Guid studentId, Guid classId)
        {
            try
            {
                using (var db = new MongoDBContext())
                {
                    var student = await db.Students.Where(x => x.Id == studentId).FirstOrDefaultAsync();
                    var classInfo = await db.Classes.Where(x => x.Id == classId).FirstOrDefaultAsync();
                    if(student ==null || classInfo==null)
                    {
                        return false;
                    }
                    var studentClass = await db.ClassStudents.Where(x => x.IdStudent == studentId && x.IdClass == classId).FirstOrDefaultAsync();
                    if(studentClass!=null)
                    {
                        return true;
                    }
                    var newStudentClass = new ClassStudent
                    {
                        Id = Guid.NewGuid(),
                        IdClass = classId,
                        IdStudent=studentId
                    };
                    await db.ClassStudents.Collection.InsertOneAsync(newStudentClass);
                }
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public List<StudentModels> GetStudentOfClass(Guid idClass)
        {
            try
            {
                using (var db = new MongoDBContext())
                {
                    var listStudentId = db.ClassStudents.Where(x => x.IdClass == idClass).Select(x => x.IdStudent).ToList();
                    var listStudentInfo = db.Students.Where(x => listStudentId.Contains(x.Id)).Select(x => new StudentModels
                    {
                        Id = x.Id,
                        Name = x.Name
                    }).ToList();
                    return listStudentInfo;
                }
            }
            catch (Exception)
            { 
                return null;
            }
        }
        public List<StudentModels> GetStudenOfClassJoin(Guid idClass)
        {
            try
            {
                using ( var db = new MongoDBContext())
                {
                    var listStudent = new List<StudentModels>();
                    var studentClasses = db.ClassStudents.Where(x => x.IdClass == idClass)
                       .Join(db.Students,
                       cs => cs.IdStudent,
                       s => s.Id,
                       (cs, s) => new { s }).ToList();
                    if(studentClasses.Count()>0)
                    {
                        foreach (var item in studentClasses)
                        {
                            listStudent.Add
                                (new StudentModels 
                            {
                                Name=item.s.Name,
                                Id=item.s.Id,
                            }  
                                );
                        } 
                    }
                    return listStudent;
                }
            }
            catch (Exception)
            {

                return null;
            }
        }
    }
}

