using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.Controller;
using TestApp.Interface;
using TestApp.Model;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            IStudentManager manager = new StudentManager();

            MemberModel newMemeber = new MemberModel()
            {
                ContactNumber = "0749257845",
                FirstName = "Thabang",
                Email = "tmsibanyoni@gmail.com ",
                IdNumber = "8807155345085",
                LastName = "Sibanyoni"
                };
            //Add Student
            var AddStudent = manager.Add(newMemeber).Result;

            if (AddStudent.Success)
                Console.WriteLine(AddStudent.Message);
            else
                Console.WriteLine(AddStudent.Message);

            newMemeber = new MemberModel()
            {
                ContactNumber = "0749257845",
                FirstName = "Danile",
                Email = "tmsibanyoni@gmail.com ",
                IdNumber = "8807155345085",
                LastName = "New Surname",
                Id = 1
            };


            //Update
            var updateStudent = manager.Update(newMemeber).Result;

            if (updateStudent.Success)
                Console.WriteLine(updateStudent.Message);
            else
                Console.WriteLine(updateStudent.Message);


            //Delete
            var deleteStudent = manager.Delete(1).Result;

            if (deleteStudent.Success)
                Console.WriteLine(deleteStudent.Message);
            else
                Console.WriteLine(deleteStudent.Message);



            Console.ReadLine();

        }
    }
}
