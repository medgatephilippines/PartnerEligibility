namespace Partner.Eligibility.Data
{
	public class MemberDatabaseContext : MemberDatabaseEntities
	{
		public MemberDatabaseContext()
		{
			Configuration.AutoDetectChangesEnabled = true;
			Configuration.EnsureTransactionsForFunctionsAndCommands = true;
			Configuration.LazyLoadingEnabled = false;
		}
	}
}
