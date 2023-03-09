namespace Tickets.Interfaces;

public interface ICreated
{
  string CreatorId { get; set; }

  Account Creator { get; set; }
}