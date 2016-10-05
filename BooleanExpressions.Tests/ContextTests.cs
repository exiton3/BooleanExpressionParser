using NUnit.Framework;

namespace BooleanExpressions.Tests
{
	//Assign one variable with value
	// if one variable is already assigned don't create new one
	//
	[TestFixture]
	public class ContextTests
	{
		private Context context;

		[SetUp]
		public void SetUp()
		{
			context = new Context();
		}

		[Test]
		public void Assign_NameNotNull_AddNameWithValueToDictionary()
		{
			const string name = "x";
			
			context.Assign(name, true);
			
			Assert.That(context.Lookup(name), Is.EqualTo(true));
		}

		[Test]
		public void Assign_TwoTimesTheSameVariable_DoesNotAddToDictionary()
		{
			
			const string name = "x";
			context.Assign(name, true);
			
			context.Assign(name, false);
			
			Assert.That(context.Lookup("y"), Is.EqualTo(false));
		}
	}
}