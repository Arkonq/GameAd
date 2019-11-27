using System;

namespace GameAd
{
	public class Picture
	{
		public Guid Id { get; set; } = Guid.NewGuid();
		public Guid GameId { get; set; }
		public virtual Game Game { get; set; }
		public string Value { get; set; }

		public override string ToString()
		{
			return Value;
		}
	}
}