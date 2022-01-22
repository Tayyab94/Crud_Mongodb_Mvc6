using CRUD_Operation_MVC_Mongodb.Models;
using CRUD_Operation_MVC_Mongodb.Models.DBAccess;
using MongoDB.Bson;
using MongoDB.Driver;

namespace CRUD_Operation_MVC_Mongodb.Repositories
{
    public class EmployeeRepository : IEmployeeRepositroy
    {
        private readonly DemoContext context;

        public EmployeeRepository(DemoContext context)
        {
            this.context = context;
        }

        public async Task<bool> AddEmployee(EmployeeDetail employee)
        {
            var employeeCollection = context.ConnectToMongo<EmployeeDetail>("EmployeeDetails");
            try
            {
                await employeeCollection.InsertOneAsync(employee);
            }
            catch (Exception)
            {
                return false;
                throw;
            }
            return true;
        }

        public async Task<List<EmployeeDetail>> GetAllEmployees()
        {
            var employeeCollection = context.ConnectToMongo<EmployeeDetail>("EmployeeDetails");

            //var empList =await employeeCollection.FindAsync(new BsonDocument());
            var empList = await employeeCollection.FindAsync(_ => true);

            return await empList.ToListAsync();
        }

        public async Task<bool> DeleteEmployeeId(string employeeId)
        {
            var employeeCollection = context.ConnectToMongo<EmployeeDetail>("EmployeeDetails");

            var id = ObjectId.Parse(employeeId.ToString());
            //var resust = await employeeCollection.DeleteOneAsync(s => s.Id == Convert.ToString(employeeId));

            //await employeeCollection.DeleteOneAsync(Builders<EmployeeDetail>.Filter.Eq("_id", employeeId.ToString()));
            try
            {
                await employeeCollection.DeleteOneAsync(s => s.Id == employeeId);
                //await employeeCollection.DeleteOneAsync(Builders<EmployeeDetail>.Filter.Eq("id", employeeId));

                //var fResult = Builders<EmployeeDetail>.Filter.Eq("_id", employeeId);

                //employeeCollection.DeleteOne(fResult);
            }
            catch (Exception e)
            {

                throw;
            }

            //await employeeCollection.DeleteOneAsync(Builders<EmployeeDetail>.Filter.Eq("id",ObjectId.Parse(employeeId.ToString())));

            return true;
        }

        public async Task<EmployeeDetail> GetEmployeeById(string employeeId)
        {
            var employeeCollection = context.ConnectToMongo<EmployeeDetail>("EmployeeDetails");

            var data =await employeeCollection.FindAsync(s => s.Id == employeeId);
            return await data.FirstOrDefaultAsync();

        }

        public async Task<bool> UpdateEmployee(EmployeeDetail employee)
        {
            var employeeCollection = context.ConnectToMongo<EmployeeDetail>("EmployeeDetails");


            // Below Code can Update the Employee Details

            //var update =await employeeCollection.FindOneAndUpdateAsync(Builders<EmployeeDetail>.Filter.Eq("Id", employee.Id), 
            //            Builders<EmployeeDetail>.Update.Set("Name", employee.Name).Set("Department", employee.Department)
            //                .Set("Address", employee.Address).Set("City", employee.City).Set("Country", employee.Country));

            //var data = Builders<EmployeeDetail>.Filter.Eq("_id", employee.Id);

            await employeeCollection.ReplaceOneAsync(s => s.Id == employee.Id, employee, new ReplaceOptions { IsUpsert = true });
            return true;
        }
    }
}
