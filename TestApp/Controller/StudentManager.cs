using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.Interface;
using TestApp.Model;
using TestApp.Repository;

namespace TestApp.Controller
{
    public class StudentManager : IStudentManager
    {
        StudentEntities dbContext;
        public StudentManager()
        {
            dbContext = new StudentEntities();
        }

        private Member GetStudent(int id)
        { 
            return dbContext.Members.FirstOrDefault(x => x.Id == id);
        }

        private string ValidateStudenyDetails(MemberModel obj)
        {
            StringBuilder sb = new StringBuilder();

            if (string.IsNullOrEmpty(obj.IdNumber))
                sb.AppendLine("Please provide Student Identity Number");

            if (string.IsNullOrEmpty(obj.FirstName))
                sb.AppendLine("Please provide Student FirstName");

            if (string.IsNullOrEmpty(obj.FirstName))
                sb.AppendLine("Please provide Student LAstname");

            return sb.ToString();
        }


        public async Task<ResponseModel> Add(MemberModel obj)
        {
            try
            {
                var valid = ValidateStudenyDetails(obj);
                if (string.IsNullOrEmpty(valid))
                {
                    var student = dbContext.Members.FirstOrDefault(x => x.IdNumber == obj.IdNumber);

                    if (student != null)
                        return new ResponseModel() { Success = false, Message = "Student already Exists" };
                    else
                    {
                        dbContext.Members.Add(new Member()
                        {
                            FirstName = obj.FirstName,
                            ContactNumber = obj.ContactNumber,
                            Email = obj.ContactNumber,
                            LastName = obj.LastName,
                            IdNumber = obj.IdNumber
                        });

                        dbContext.SaveChanges();

                        return await Task.FromResult(new ResponseModel() { Success = true, Message = "Student Successfully  Added" });
                    }
                }
                else
                    return new ResponseModel() { Success = false, Message = valid };

            }
            catch (Exception ex)
            {
                return new ResponseModel() { Success = false, Message = ex.Message };
            }
        }

        public async Task<ResponseModel> Delete(int id)
        {
            try
            {
                var obj = GetStudent(id);

                if (obj != null)
                {
                    dbContext.Members.Remove(obj);
                    dbContext.SaveChanges();

                    return new ResponseModel() { Success = true, Message = "Student has been removed" };
                }
                else
                    return new ResponseModel() { Success = false, Message = "Student does not exist" };
            }
            catch (Exception ex)
            {
                return new ResponseModel() { Success = false, Message = ex.Message };
            }
        }

        public async Task<(ResponseModel response, MemberModel model)> Get(int id)
        {
            try
            {
                var obj = GetStudent(id);

                if (obj != null)
                {
                    return await Task.FromResult((new ResponseModel(), new MemberModel()
                    {
                        ContactNumber = obj.ContactNumber,
                        Email = obj.Email,
                        FirstName = obj.FirstName,
                        IdNumber = obj.IdNumber,
                        LastName = obj.LastName
                    }));
                }
                else
                    return (new ResponseModel() { Success = false, Message = "Student does not exist" }, null);

            }
            catch (Exception ex)
            {
                return (new ResponseModel() { Success = false, Message = ex.Message },null);
            }
        }

        public async Task<ResponseModel> Update(MemberModel obj)
        {
            try
            {
                var member = GetStudent(obj.Id);

                if (member == null)
                    return new ResponseModel() { Success = false, Message = "Could not update Student, Student does not exist" };
                else
                {
                    member.LastName = obj.LastName;
                    member.FirstName = obj.FirstName;
                    member.IdNumber = obj.IdNumber;
                    member.ContactNumber = obj.ContactNumber;
                    member.Email = obj.Email;

                    dbContext.SaveChanges();

                    return await Task.FromResult(new ResponseModel() { Success = true, Message ="Student has been updated" });
                }
            }
            catch (Exception ex)
            {
                return new ResponseModel() { Success = false, Message = ex.Message };
            }
        }
    }
}
