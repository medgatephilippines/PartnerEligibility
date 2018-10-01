using Partner.Eligibility.Data;
using Partner.Eligibility.Data.Entities;
using System;
using System.Linq;

namespace Partner.Eligibility.WCF
{
	public class EligibilityService : IEligibilityService
	{
		public MemberInfo GetMemberInfo(string memberId)
		{
			MemberInfo result = new MemberInfo();

			try
			{
				Member member;

				using (MemberDatabaseContext ctx = new MemberDatabaseContext())
				{
					member = ctx.Members.FirstOrDefault(m => m.ExternalMemberId == memberId);
				}

				if(member != null)
				{
					result.RequestStatus = "SUCCESSFUL";
					result.MemberId = member.ExternalMemberId;
					result.FirstName = member.FirstName;
					result.LastName = member.LastName;
					result.Birthdate = member.Birthdate;
					result.EligibilityStatus = member.EligibilityStatus;
					result.CoverageStart = member.CoverageStart;
					result.CoverageEnd = member.CoverageEnd;
				}
				else
				{
					result.RequestStatus = "INVALID";
					result.MemberId = memberId;
					result.FirstName = null;
					result.LastName = null;
					result.Birthdate = DateTime.MinValue;
					result.EligibilityStatus = null;
					result.CoverageStart = DateTime.MinValue;
					result.CoverageEnd = DateTime.MinValue;
				}
			}
			catch(Exception ex)
			{
				Console.WriteLine(ex.Message);
			}

			return result;
		}
	}
}
