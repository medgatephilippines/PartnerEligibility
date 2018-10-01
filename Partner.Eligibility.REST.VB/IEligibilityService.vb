Imports System.IO
Imports System.ServiceModel
Imports System.ServiceModel.Web

<ServiceContract()>
Public Interface IEligibilityService
	<OperationContract()>
	<WebInvoke(BodyStyle:=WebMessageBodyStyle.Wrapped, Method:="GET", ResponseFormat:=WebMessageFormat.Xml, UriTemplate:="/getmemberinfo?memberId={memberId}")>
	Function GetMemberInfo(ByVal memberId As String) As Stream
End Interface
