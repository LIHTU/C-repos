using System;
using static System.Console;
using System.Reflection;

namespace FitnessClub
{
    class Member
    {
        // Notice that these are fields, not properties...
        // I wonder if they are detectable via reflection
        public int annualFee;
        private string name;
        private int memberId;
        private int memberSince;

        public override string ToString()
        {
            return
                "\nName: " + name +
                "\nMember ID: " + memberId +
                "\nMember Since: " + memberSince +
                "\nTotal Annual Fee: " + annualFee + "\n";
        }

        public Member()
        {
            WriteLine("Parent Constructor with no parameter.");
        }
        public Member(string pName, int pMemberId, int pMemberSince)
        {
            WriteLine("Parent constuctor ember with 3 params");
            name = pName;
            memberId = pMemberId;
            memberSince = pMemberSince;
        }
        public virtual void CalculateAnnualFee()
        {
            annualFee = 0;
        }
    }
    class NormalMember : Member
    {
        public NormalMember()
        {
            WriteLine("Child (NormalMember) Constructor with no param");
        }
        public NormalMember(string remarks, string pName, int pMemberId, int pMemberSince) : base(pName, pMemberId, pMemberSince)
        {
            WriteLine("Child (NormalMember) Constructor with 4 params");
            WriteLine("Remarks: {0}", remarks);
        }
        public override void CalculateAnnualFee()
        {
            annualFee = 100 + 12 * 30;
        }
    }
    class VipMember : Member
    {
        public VipMember(string name, int memberId, int memberSince) : base(name, memberId, memberSince)
        {
            WriteLine("Vip Child Constructor with 3 params.");

        }
        public override void CalculateAnnualFee()
        {
            annualFee = 1200; // notice the lower case refering to field...
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            Member[] clubMembers = new Member[5];
            clubMembers[0] = new NormalMember("Speical Rate", "James", 1, 2010);
            clubMembers[1] = new NormalMember("Normal Rate", "Andy", 2, 2011);
            clubMembers[2] = new NormalMember("Normal Rate", "Bill", 3, 2010);
            clubMembers[3] = new VipMember("Carol", 4, 2012);
            clubMembers[4] = new VipMember("Evelyn", 5, 2012);

            foreach (Member m in clubMembers)
            {
                m.CalculateAnnualFee();
                WriteLine(m.ToString());
            }

            if (clubMembers[0].GetType() == typeof(VipMember))
                WriteLine("Yes");
            else
                WriteLine("No");

            ReadKey();
        }
    }
}
