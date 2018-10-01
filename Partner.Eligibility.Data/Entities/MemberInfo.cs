using System;

namespace Partner.Eligibility.Data.Entities
{
	public class MemberInfo
	{
		public string RequestStatus { get; set; }
		public string MemberId { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public DateTime Birthdate { get; set; }
		public string EligibilityStatus { get; set; }
		public DateTime CoverageStart { get; set; }
		public DateTime CoverageEnd { get; set; }
	}
}
