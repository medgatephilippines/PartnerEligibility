using Partner.Eligibility.Data.Entities;
using System.ServiceModel;

namespace Partner.Eligibility.WCF
{
	[ServiceContract]
	public interface IEligibilityService
	{
		[OperationContract]
		MemberInfo GetMemberInfo(string memberId);
	}
}
