using Newtonsoft.Json;
using Partner.Eligibility.Data;
using Partner.Eligibility.Data.Entities;
using System;
using System.IO;
using System.Linq;
using System.ServiceModel.Web;
using System.Text;

namespace Partner.Eligibility.REST
{
	public class EligibilityService : IEligibilityService
	{
		public Stream GetMemberInfo(string memberId)
		{
			string result = null;

			try
			{
				Member member;

				using (MemberDatabaseContext ctx = new MemberDatabaseContext())
				{
					member = ctx.Members.FirstOrDefault(m => m.ExternalMemberId == memberId);
				}

				if(member != null)
				{
					MemberInfo memberInfo = new MemberInfo();
					memberInfo.RequestStatus = "SUCCESSFUL";
					memberInfo.MemberId = member.ExternalMemberId;
					memberInfo.FirstName = member.FirstName;
					memberInfo.LastName = member.LastName;
					memberInfo.Birthdate = member.Birthdate;
					memberInfo.EligibilityStatus = member.EligibilityStatus;
					memberInfo.CoverageStart = member.CoverageStart;
					memberInfo.CoverageEnd = member.CoverageEnd;
					result = JsonConvert.SerializeObject(memberInfo);
				}
				else
				{
					MemberInfo memberInfo = new MemberInfo();
					memberInfo.RequestStatus = "INVALID";
					memberInfo.MemberId = memberId;
					memberInfo.FirstName = null;
					memberInfo.LastName = null;
					memberInfo.Birthdate = DateTime.MinValue;
					memberInfo.EligibilityStatus = null;
					memberInfo.CoverageStart = DateTime.MinValue;
					memberInfo.CoverageEnd = DateTime.MinValue;
					result = JsonConvert.SerializeObject(memberInfo);
				}
			}
			catch(Exception ex)
			{
				Console.WriteLine(ex.Message);
			}

			// Set the content type of the outgoing response to application/json
			WebOperationContext.Current.OutgoingResponse.ContentType = "application/json; charset=utf-8";
			return new MemoryStream(Encoding.UTF8.GetBytes(result));
		}
	}
}
