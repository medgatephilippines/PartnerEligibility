Imports System.IO
Imports System.ServiceModel.Web
Imports System.Text
Imports Newtonsoft.Json
Imports Partner.Eligibility.Data
Imports Partner.Eligibility.Data.Entities

Public Class EligibilityService
	Implements IEligibilityService

	Public Function GetMemberInfo(memberId As String) As Stream Implements IEligibilityService.GetMemberInfo
		Dim result As String
		result = ""
		Dim member As Member

		Try
			Using ctx As New MemberDatabaseContext
				member = ctx.Members.FirstOrDefault(Function(m) m.ExternalMemberId = memberId)
			End Using

			If Not member Is Nothing Then
				Dim memberInfo As MemberInfo
				memberInfo = New MemberInfo
				memberInfo.RequestStatus = "SUCCESSFUL"
				memberInfo.MemberId = member.ExternalMemberId
				memberInfo.FirstName = member.FirstName
				memberInfo.LastName = member.LastName
				memberInfo.Birthdate = member.Birthdate
				memberInfo.EligibilityStatus = member.EligibilityStatus
				memberInfo.CoverageStart = member.CoverageStart
				memberInfo.CoverageEnd = member.CoverageEnd
				result = JsonConvert.SerializeObject(memberInfo)
			Else
				Dim memberInfo As MemberInfo
				memberInfo = New MemberInfo
				memberInfo.RequestStatus = "INVALID"
				memberInfo.MemberId = memberId
				memberInfo.FirstName = Nothing
				memberInfo.LastName = Nothing
				memberInfo.Birthdate = DateTime.MinValue
				memberInfo.EligibilityStatus = Nothing
				memberInfo.CoverageStart = DateTime.MinValue
				memberInfo.CoverageEnd = DateTime.MinValue
				result = JsonConvert.SerializeObject(memberInfo)
			End If
		Catch ex As Exception
			Console.WriteLine(ex.Message)
		End Try

		' Set the content type of the outgoing response to application/json
		WebOperationContext.Current.OutgoingResponse.ContentType = "application/json; charset=utf-8"
		Return New MemoryStream(Encoding.UTF8.GetBytes(result))
	End Function
End Class
