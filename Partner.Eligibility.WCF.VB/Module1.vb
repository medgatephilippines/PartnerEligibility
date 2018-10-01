Imports System.ServiceModel

Module Module1

	Sub Main()
		Console.WriteLine("Starting Service...")
		Dim host = New ServiceHost(GetType(EligibilityService))
		host.Open()
		Console.WriteLine("Service is running at: " + host.Description.Endpoints(0).Address.ToString)
		Console.ReadKey()
		Console.WriteLine("End")
	End Sub

End Module
