﻿namespace FestivalManager.Entities.Factories
{
	using System;
	using System.Linq;
	using System.Reflection;
	using System.Runtime.InteropServices.WindowsRuntime;
	using Contracts;
	using Entities.Contracts;
	using Instruments;

	public class InstrumentFactory : IInstrumentFactory
	{
		public IInstrument CreateInstrument(string type)
		{
           
            Type @class = Assembly.GetCallingAssembly().GetTypes()
               .FirstOrDefault(t => t.Name == type);

            IInstrument instrument = (IInstrument)Activator.CreateInstance(@class);

            return instrument;

        }
	}
}