//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Partner.Eligibility.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Member
    {
        public int InternalMemberId { get; set; }
        public string ExternalMemberId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public System.DateTime Birthdate { get; set; }
        public string EligibilityStatus { get; set; }
        public System.DateTime CoverageStart { get; set; }
        public System.DateTime CoverageEnd { get; set; }
    }
}
