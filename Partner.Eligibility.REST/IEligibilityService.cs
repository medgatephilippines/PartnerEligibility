using System.IO;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace Partner.Eligibility.REST
{
	[ServiceContract]
	public interface IEligibilityService
	{
		[OperationContract]
		[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped, Method = "GET", ResponseFormat = WebMessageFormat.Xml, UriTemplate = "/getmemberinfo?memberId={memberId}")]
		Stream GetMemberInfo(string memberId);
	}
}
