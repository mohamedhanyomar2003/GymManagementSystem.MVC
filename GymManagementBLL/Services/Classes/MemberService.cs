using GymManagementBLL.Services.Interfaces;
using GymManagementBLL.ViewModels.MemberViewModels;
using GymManagementDAL.Entities;
using GymManagementDAL.Repositories.Classes;
using GymManagementDAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementBLL.Services.Classes
{
    class MemberService : IMemberService
    {
        private readonly IGenericRepository<Member> _memberRepository;

        public MemberService(IGenericRepository<Member> memberRepository)
        {
            _memberRepository = memberRepository;
        }

        public bool CreateMember(CreateMemberViewModel CreatedMember)
        {
            try
            {
                // Check If Email Is Exists
                var emailExists = _memberRepository.GetAll(X => X.Email == CreatedMember.Email).Any();

                // Check If Phone Is Exists
                var PhoneExists = _memberRepository.GetAll(X => X.Phone == CreatedMember.Phone).Any();

                // If One Of Them Exists Return False
                if (emailExists || PhoneExists) return false;
                // If Not Return True After Adding The Member
                var member = new Member()
                {
                    Email = CreatedMember.Email,
                    Name = CreatedMember.Name,
                    Phone = CreatedMember.Phone,
                    Gender = CreatedMember.Gender,
                    DateOfBirth = CreatedMember.DateOfBirth,
                    Address = new Address()
                    {
                        BuildingNumber = CreatedMember.BuildingNumber,
                        Street = CreatedMember.Street,
                        City = CreatedMember.City
                    },
                    HealthRecord = new HealthRecord()
                    {
                        Height = CreatedMember.HealthRecordViewModel.Height,
                        Weight = CreatedMember.HealthRecordViewModel.Weight,
                        BloodType = CreatedMember.HealthRecordViewModel.BloodType,
                        Note = CreatedMember.HealthRecordViewModel.Note
                    }


                };

                return _memberRepository.Add(member) > 0;
            }

            catch(Exception)
            {
                return false;
            }
        }

        public IEnumerable<MemberViewModel> GetAllMembers()
        {
            var Members = _memberRepository.GetAll();
            if (Members is null || !Members.Any()) return [];
            var memberViewModels = Members.Select(m => new MemberViewModel
            {
                Id = m.ID,
                Name = m.Name,
                Email = m.Email,
                Gender = m.Gender.ToString(),
                Phone = m.Phone,
                Photo = m.Photo
            });
            return memberViewModels;
        }
    }
}
