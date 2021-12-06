using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace EntityFrameWorkJoin.models
{
   public class StudentRespository
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
                using (var db = new MyDbContext())
                {
                    db.StudentInformation.Add(student);
                    db.SaveChanges();
                }

                return true;
            }
            catch (Exception E)
            {
                return false;
            }
        }
        public StudentModels GetStudentInfo(Guid id)
        {
            try
            {
                using (var db = new MyDbContext())
                {
                    var studentInfo = db.StudentInformation.Where(x => x.Id == id).FirstOrDefault();
                    if (studentInfo != null)
                    {
                        return new StudentModels
                        {
                            Id = id,
                            Name = studentInfo.Name
                        };
                    }
                 return null;
                }
            }
            catch (Exception e)
            {

                return null;
            }
        }
        public bool UpdateStudent(Guid id ,string name, string sex, int yearOfBirth)
        {
            try
            {
                var student = new StudentInformation
                {
                    Id =id,
                    Name = name,
                    Sex = sex,
                    YearOfBirth = yearOfBirth
                };
                using(var db = new MyDbContext())
                {
                    student = db.StudentInformation.Where(x => x.Id == id).FirstOrDefault();
                    if (student!=null)
                    {
                        student.Name = name;
                        student.Sex = sex;
                        student.YearOfBirth = yearOfBirth;
                        db.StudentInformation.Update(student);
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
        public bool DeleteStudent(Guid id)
        {
            try
            {
                using (var db = new MyDbContext())
                {
                    var RemoveStd = db.StudentInformation.Where(x => x.Id == id).FirstOrDefault();
                    if(RemoveStd==null)
                    {
                        return false;
                    }
                    else
                    {
                        db.StudentInformation.Remove(RemoveStd);
                        db.SaveChanges();
                    }
                }
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public bool AddStudentToClass(Guid studentId,Guid classId)
        {
            try
            {
                using(var db = new MyDbContext())
                {
                    var student = db.StudentInformation.Where(x => x.Id == studentId).FirstOrDefault();
                    var classInfor = db.Classes.Where(x => x.Id == classId).FirstOrDefault();

                    if (student == null || classInfor == null)
                    {
                        return false;
                    }

                    var classStudent = db.ClassStudent.Where(x => x.IdStudent == studentId && x.IdClass == classId).FirstOrDefault();
                    if(classStudent!= null)
                    {
                        return true;
                    }
                    var newClassStudent = new ClassStudent()
                    {
                        Id = Guid.NewGuid(),
                        IdClass=classId,
                        IdStudent=studentId
                    };
                    db.ClassStudent.Add(newClassStudent);
                    db.SaveChanges();

                }
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public List<StudentModels> GetStudentOfClass (Guid idClass)
        {
            try
            {
                using (var db = new MyDbContext())
                {
                    var listStudentId = db.ClassStudent.Where(x => x.IdClass == idClass).Select(x => x.IdStudent).ToList();

                    var listStudentInfor = db.StudentInformation.Where(x => listStudentId.Contains(x.Id)).Select(x => new StudentModels
                    {
                        Id = x.Id,
                        Name = x.Name
                    }).ToList();
                    return listStudentInfor;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
        public List<StudentModels> GetStudentOfClassSecond(Guid idClass)
        {
            try
            {
                using (var db = new MyDbContext())
                {
                    var listStudent = new List<StudentModels>();
                    var studentClasses = db.ClassStudent.Where(x => x.IdClass == idClass)
                         .Join(db.StudentInformation, cs => cs.IdStudent, s => s.Id, (cs,s) => new {s}).ToList();
                    if(studentClasses.Count()>0 )
                    {
                        foreach (var item in studentClasses)
                        {
                            listStudent.Add(new StudentModels { Name = item.s.Name,Id=item.s.Id });
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
