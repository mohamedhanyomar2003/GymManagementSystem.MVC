using GymManagementDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementDAL.Repositories.Interfaces
{
    interface IPlanRepository
    {

        //GetAll
        IEnumerable<Plan> GetAll();
        //Get By Id
        Plan? GetById(int id);
        //Add
        int Add(Plan plan);
        //Update
        int Update(Plan plan);
        //Delete
        int Delete(Plan plan);
    }
}
