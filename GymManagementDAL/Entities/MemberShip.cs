using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementDAL.Entities
{
    public class MemberShip : BaseEntity
    {
        //StartDate - CreatedAt Of BaseEntity
        public DateTime EndDate { get; set; }

        //ReadOnly Property
        public string Status
        {
            get
            {
                if (EndDate >= DateTime.Now)
                    return "Expired";
                else
                    return "Active";

            }
        }
        public Member Member { get; set; } = null!;
        public Plan Plan { get; set; } = null!;
        public int MemberId { get; set; }
        public int PlanId { get; set; }
    }
}
