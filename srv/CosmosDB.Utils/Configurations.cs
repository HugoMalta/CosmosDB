using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace CosmosDB.Utils
{
    public class Configurations
	{
		private IConfigurationBuilder _builder { get; }

		public Configurations()
		{
            _builder = new ConfigurationBuilder()
				.SetBasePath(System.IO.Directory.GetCurrentDirectory())
				.AddJsonFile("appsettings.json");

			Configuration = _builder.Build();
		}
		
		public IConfiguration Configuration { get; private set; }

		public string GetConfiguration(string key)
		{
			return Configuration[key];
		}
	}
}
