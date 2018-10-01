Imports System.ServiceModel
Imports Partner.Eligibility.Data.Entities

<ServiceContract()>
Public Interface IEligibilityService
	<OperationContract()>
	Function GetMemberInfo(ByVal memberId As String) As MemberInfo
End Interface
