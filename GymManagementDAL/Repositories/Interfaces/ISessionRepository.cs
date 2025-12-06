using GymManagementDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementDAL.Repositories.Interfaces
{
    interface ISessionRepository
    {

        //GetAll
        IEnumerable<Session> GetAll();
        //Get By Id
        Session? GetById(int id);
        //Add
        int Add(Session session);
        //Update
        int Update(Session session);
        //Delete
        int Delete(Session session);
    }
}
