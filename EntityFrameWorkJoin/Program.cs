using EntityFrameWorkJoin.models;
using EntityFrameWorkJoin.MongoModels;
using System;

namespace EntityFrameWorkJoin
{
    class Program
    {
        static void Main(string[] args)
        {
            var mongoStudentRepository = new RepositoryStudentMongo();
            var mongoClassRepository = new RepositoryClassMongo();





            /* var classResponsitory = new ClassRepository();
             var studentResponsitory = new StudentRespository();*/
            /* mongoStudentRepository.Create("Manh", "Nam", 1999);
             mongoStudentRepository.Create("Dung", "Nam", 1999);
             mongoStudentRepository.Create("Nam", "Nam", 2001);
             mongoStudentRepository.Create("Lan", "Nu", 1999);
             mongoStudentRepository.Create("Hang","Nu", 2000);
             mongoStudentRepository.Create("Bao", "Nam", 1998);
             mongoStudentRepository.Create("Diep", "Nu", 2002);
             mongoStudentRepository.Create("Hue", "Nu", 1999);
             mongoStudentRepository.Create("Hung", "Nam", 1999);
             mongoStudentRepository.Create("Cuong", "Nam", 2000);
             mongoStudentRepository.Create("Hong", "Nu", 1999);
             mongoStudentRepository.Create("Tuan", "Nam", 1995);
             mongoStudentRepository.Create("Thang", "Nam", 1996);
             mongoStudentRepository.Create("Dang", "Nam", 1997);
             mongoStudentRepository.Create("Xuan", "Nu", 1998);*/

          /*  mongoClassRepository.CreateClass("Van", 10);
            mongoClassRepository.CreateClass("Toan", 11);
            mongoClassRepository.CreateClass("Anh", 12);
            mongoClassRepository.CreateClass("Su", 13);
            mongoClassRepository.CreateClass("Dia", 14);
            mongoClassRepository.CreateClass("GDCD", 11);
            mongoClassRepository.CreateClass("The Duc", 12);
            mongoClassRepository.CreateClass("Sinh Hoc", 13);
            mongoClassRepository.CreateClass("Hoa Hoc", 14);
            mongoClassRepository.CreateClass("Cong Nghe", 10);
            mongoClassRepository.CreateClass("Quan Su", 11);
            mongoClassRepository.CreateClass("Triet Hoc", 10);*/



            /* responsitory.Create("manh", "nam", 1999);
             responsitory.Create("nam", "nam", 1998);
             responsitory.Create("linh", "nu", 1997);
             responsitory.Create("den", "nam", 1996);
             responsitory.Create("vau", "nu", 1999);*/


            //responsitory.Create("Manh", 8);
            //responsitory.Create("Nam", 9);
            //responsitory.Create("Linh", 7);
            //responsitory.Create("Den", 6);
            //responsitory.Create("Vau", 9)


            //Guid id = Guid.Parse("0319d750-39ee-4afc-a32c-3109ee3f89c6");
            //responsitory.GetStudentInfo(id);
            //var data = responsitory.GetStudentInfo(id);
            //if (data == null)
            //{
            //    Console.WriteLine("khong tim thay hoc sinh");
            //}
            //if (data != null)
            //{
            //    Console.WriteLine($"ten hoc sinh la {data.Name}");
            //}


            //Guid id = Guid.Parse("0562f3eb-1e77-40bc-8642-61ca5bd21e75");
            //var data = responsitory.GetClassInfo(id);
            //if (data == null)
            //{
            //    Console.WriteLine("khong tim thay lop");
            //}
            //if (data != null)
            //{
            //    Console.WriteLine($"ten hoc sinh la {data.Name}");
            //}


            //string id;
            //Console.WriteLine("Moi nhap id hoc vien");
            //id = Console.ReadLine();
            //Guid studentId;
            //if (!Guid.TryParse(id, out studentId))
            //{
            //    Console.WriteLine("id khong dung ");
            //    return;
            //}
            //var data = responsitory.GetStudentInfo(studentId);
            //if (data == null)
            //{
            //    Console.WriteLine("khong tim thay hoc sinh");
            //}
            //if (data != null)
            //{
            //    string name;
            //    Console.WriteLine("Nhap ten moi hoc sinh ");
            //    name = Console.ReadLine();
            //    string gioitinh;
            //    Console.WriteLine("Nhap gioi tinh moi hoc sinh ");
            //    gioitinh = Console.ReadLine();
            //    int namsinh;
            //    Console.WriteLine("Nhap nam sinh moi hoc sinh ");
            //    namsinh = int.Parse(Console.ReadLine());

            //    var kq =  responsitory.UpdateStudent(studentId,name,gioitinh,namsinh);
            //  if(kq==true)
            //    {
            //        Console.WriteLine("updated");
            //    }
            //    else
            //    {
            //        Console.WriteLine("That bai");
            //    }
            //}




            //string id;
            //Console.WriteLine("Nhap id cho Class");
            //id = Console.ReadLine();
            //Guid Classid;
            //if(!Guid.TryParse(id ,out Classid))
            //{
            //    Console.WriteLine(" id khong dung ");
            //    return;
            //}
            //var data = responsitory.GetClassInfo(Classid);
            //    if(data==null)
            //{
            //    Console.WriteLine(" Khong tim thay lop ");
            //}
            //    else
            //{
            //    string name;
            //    Console.WriteLine("Nhap ten moi cho lop ");
            //    name = Console.ReadLine();
            //    int grade;
            //    Console.WriteLine("Nhap ten moi cho grade");
            //    grade = int.Parse(Console.ReadLine());
            //   var kq = responsitory.Update(Classid, name, grade);
            //    if (kq == true)
            //    {
            //        Console.WriteLine("updated");
            //    }
            //    else
            //    {
            //        Console.WriteLine("That bai");
            //    }
            //}



            //string id;
            //Console.WriteLine("Nhap id Student");
            //id = Console.ReadLine();
            //Guid StudentId;
            //if(!Guid.TryParse(id,out StudentId))
            //{
            //    Console.WriteLine("id khong hop le");
            //    return;
            //}
            //var data = responsitory.GetStudentInfo(StudentId);
            //if(data == null)
            //{
            //    Console.WriteLine(" Khong tim thay hoc sinh");
            //}
            //else
            //{
            //    responsitory.DeleteStudent(StudentId);

            //}





            //string id;
            //Console.WriteLine("Nhap id Class");
            //id = Console.ReadLine();
            //Guid IdClass;
            //if(!Guid.TryParse(id,out IdClass))
            //{
            //    Console.WriteLine("id khong hop le");
            //    return;
            //}
            //var data = responsitory.GetClassInfo(IdClass);
            //if(data ==null)
            //{
            //    Console.WriteLine(" Khong tim thay Class");
            //}
            //else
            //{
            //    responsitory.Delete(IdClass);
            //}



            //    string idClass;
            //    Console.WriteLine("Nhap id Class");
            //    idClass = Console.ReadLine();
            //    string idStudent;
            //    Console.WriteLine("Nhap id Student");
            //    idStudent = Console.ReadLine();
            //    Guid idClassGuid;
            //    Guid idStudentGuid;
            //    if( !Guid.TryParse(idClass,out idClassGuid) )
            //    {
            //        Console.WriteLine("id khong hop le");
            //        return;
            //    }
            //    if (!Guid.TryParse(idStudent, out idStudentGuid))
            //    {
            //        Console.WriteLine("id khong hop le");
            //        return;
            //    }
            //   var kq= responsitory.AddStudentToClass(idStudentGuid, idClassGuid);
            //    if(kq==true)
            //    {
            //        Console.WriteLine("thanh cong");
            //    }
            //    else
            //    {
            //        Console.WriteLine("that bai");
            //    }




            //string idClass;
            //Console.WriteLine("Nhap id Class");
            //idClass = Console.ReadLine();
            //Guid idClassGuid;
            //if (!Guid.TryParse(idClass, out idClassGuid))
            //{
            //    Console.WriteLine("id khong hop le");
            //    return;
            //}
            //var classInfor = classResponsitory.GetClassInfo(idClassGuid);
            //if(classInfor ==null)
            //{
            //    Console.WriteLine("lop khong ton tai");
            //    return;
            //}
            //var listStudent = studentResponsitory.GetStudentOfClass(idClassGuid);
            //if (listStudent.Count==0)
            //{
            //    Console.WriteLine("lop khong co hoc sinh");
            //    return;
            //}
            //Console.WriteLine($"lop : {classInfor.Name } " );
            //foreach (var item in listStudent)
            //{
            //    Console.WriteLine($"ten hoc sinh : { item.Name} ");
            //}


        }
    }
}
