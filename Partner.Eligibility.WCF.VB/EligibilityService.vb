Imports Partner.Eligibility.Data
Imports Partner.Eligibility.Data.Entities

Public Class EligibilityService
	Implements IEligibilityService

	Public Function GetMemberInfo(memberId As String) As MemberInfo Implements IEligibilityService.GetMemberInfo
		Dim result As MemberInfo
		result = New MemberInfo

		Try
			Dim member As Member
			Using ctx As New MemberDatabaseContext
				member = ctx.Members.FirstOrDefault(Function(m) m.ExternalMemberId = memberId)
			End Using

			If Not member Is Nothing Then
				result.RequestStatus = "SUCCESSFUL"
				result.MemberId = member.ExternalMemberId
				result.FirstName = member.FirstName
				result.LastName = member.LastName
				result.Birthdate = member.Birthdate
				result.EligibilityStatus = member.EligibilityStatus
				result.CoverageStart = member.CoverageStart
				result.CoverageEnd = member.CoverageEnd
			Else
				result.RequestStatus = "INVALID"
				result.MemberId = memberId
				result.FirstName = Nothing
				result.LastName = Nothing
				result.Birthdate = DateTime.MinValue
				result.EligibilityStatus = Nothing
				result.CoverageStart = DateTime.MinValue
				result.CoverageEnd = DateTime.MinValue
			End If
		Catch ex As Exception
			Console.WriteLine(ex.Message)
		End Try

		' Set the content type of the outgoing response to application/json
		Return result
	End Function
End Class
