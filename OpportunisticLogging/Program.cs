using System;
using System.IO;
using log4net;

namespace OpportunisticLogging
{
	public class Program
	{
		private static ILog Logger = LogManager.GetLogger(typeof (Program));

		static void Main(string[] args)
		{
			InitializeLoggingConfiguration();

			Logger.Info("The application is starting up.");

			Logger.Info("The applicationis doing work.");

			Console.WriteLine("Please press any key to quit...");
			Console.Read();

			Logger.Info("The application is shutting down.");

			Logger.Error("I'm an error.  Above me is some info statements.");
		}

		private static void InitializeLoggingConfiguration()
		{
			var fi = new FileInfo(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log4net.config"));

			if (fi.Exists)
				log4net.Config.XmlConfigurator.ConfigureAndWatch(fi);
		}
	}
}
