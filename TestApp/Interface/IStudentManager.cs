using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.Model;

namespace TestApp.Interface
{
    public  interface IStudentManager
    {
        Task<ResponseModel> Add(MemberModel obj);
        Task<ResponseModel> Update(MemberModel obj);
        Task<ResponseModel> Delete(int id);
        Task<(ResponseModel response, MemberModel model)> Get(int id);
    }
}
