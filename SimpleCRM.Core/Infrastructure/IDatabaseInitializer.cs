using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCRM.Core.Infrastructure
{
	/// <summary>
	/// Interface to be implemented by Database initializer classes
	/// </summary>
	public interface IDatabaseInitializer
	{
		Task SeedAsync();
	}
}
