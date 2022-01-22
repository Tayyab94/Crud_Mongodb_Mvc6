using CRUD_Operation_MVC_Mongodb.Models;

namespace CRUD_Operation_MVC_Mongodb.Repositories
{
    public interface IEmployeeRepositroy
    {
        Task<bool> AddEmployee(EmployeeDetail employee);

        Task <List<EmployeeDetail>> GetAllEmployees();

        Task<bool>DeleteEmployeeId(string employeeId);

        Task<EmployeeDetail> GetEmployeeById(string employeeId);

        Task<bool> UpdateEmployee(EmployeeDetail employee);
    }
}
