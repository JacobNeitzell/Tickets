using Tickets.Interfaces;

namespace Tickets.Models;

public class Ticket : ICreated, IRepoItem<int>
{
  public int Id { get; set; }

  public string Ticketname { get; set; }
  public string Ticketclient { get; set; }

  public string Description { get; set; }

  public Account Creator { get; set; }

  public string CreatorId { get; set; }
  public DateTime CreatedAt { get; set; }


  public DateTime UpdatedAt { get; set; }


}

public class AllTickets : Ticket
{

  public int UserTicketId { get; set; }
  public int TicketId { get; set; }

  public string UserTicketCreatorId { get; set; }
}