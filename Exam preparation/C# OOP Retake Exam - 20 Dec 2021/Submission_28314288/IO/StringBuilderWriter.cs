namespace NavalVessels.IO
{
	using NavalVessels.IO.Contracts;
	using System.Text;

	public class StringBuilderWrirer : IWriter
	{
		private StringBuilder sb;

		public StringBuilderWrirer()
		{
			this.sb = new StringBuilder();
		}

		public void Write(string message)
		{
			this.sb.Append(message);
		}

		public void WriteLine(string message)
		{
			this.sb.AppendLine(message);
		}

		public override string ToString() => this.sb.ToString().TrimEnd();

	}
}