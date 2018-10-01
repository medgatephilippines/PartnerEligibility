using System;
using System.ServiceModel;

namespace Partner.Eligibility.WCF
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Starting Service...");
			ServiceHost host = new ServiceHost(typeof(EligibilityService));
			host.Open();			
			Console.WriteLine("Service is running at: " + host.Description.Endpoints[0].Address);
			Console.ReadKey();
			Console.WriteLine("End");
		}
	}
}
