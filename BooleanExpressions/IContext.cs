namespace BooleanExpressions
{
	public interface IContext
	{
		bool Lookup(string s);
		void Assign(string name, bool value);
	}
}