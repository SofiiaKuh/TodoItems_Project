namespace TodoApi.Models
{
	public class TodoItem
	{
		public int Id { get; set; }
		public required string Title { get; set; }
		public required string Description { get; set; }

		public override bool Equals(object? obj)
		{
			if (obj is TodoItem other)
			{
				return Id == other.Id &&
					   Title == other.Title &&
					   Description == other.Description;
			}
			return false;
		}

		public override int GetHashCode()
		{
			return HashCode.Combine(Id, Title, Description);
		}
	}
}