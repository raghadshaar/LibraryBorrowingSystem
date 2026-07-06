using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem
{
    public class MemberRepository
    {

        private List<Member> members = new List<Member>();


        public void AddMember(Member member)
        {

            Member? mem = members.FirstOrDefault(m => m.Id == member.Id);
            if (mem is null) members.Add(member);
        }
        public void RemoveMember(Member member)
        {
            Member? mem = members.FirstOrDefault(m => m.Id == member.Id);
            if (mem != null)
            {
                members.Remove(mem);
            }

        }
        public IReadOnlyList<Member> GetMembers()
        {
            return members;
        }
    }
}
