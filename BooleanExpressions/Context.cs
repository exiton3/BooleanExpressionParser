using System;
using System.Collections.Generic;

namespace BooleanExpressions
{
	public class Context : IContext
	{
		private readonly IDictionary<string, bool> contextDic;

		public Context()
		{
			contextDic = new Dictionary<string, bool>();
		}
		public bool Lookup(string s)
		{
			return contextDic[s];
		}

		public void Assign(string name, bool value)
		{
			if (name == null) throw new ArgumentNullException("name");

			bool val;
			if (contextDic.TryGetValue(name, out val))
			{
				contextDic[name] = value;
			}
			else
			{
				contextDic.Add(name, value);
			}
		}
	}
}