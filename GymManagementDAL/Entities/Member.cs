using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementDAL.Entities
{
   public class Member : GymUser
    {
        //JoinDate==CreatedAt Of BaseEntity
        public string? Photo { get; set; }
        #region RelationShips
        #region Member - HealthRecord
        public HealthRecord HealthRecord { get; set; } = null!;
        #endregion

        #region Member - Membership
        public ICollection<MemberShip> MemberShips { get; set; } = null!;
        #endregion

        #region Member - MemberSession
        public ICollection<MemberSession> MemberSessions { get; set; } = null!;
        #endregion
        #endregion

    }
}
