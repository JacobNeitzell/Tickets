namespace Tickets.Services;

public class TicketsService
{
  private readonly TicketsRepository _tr;

  public TicketsService(TicketsRepository tr)
  {
    _tr = tr;
  }


  internal Ticket CreateTicket(Ticket newTicket)
  {
    return _tr.Create(newTicket);
  }


  internal Ticket GetTicketId(int ticketId, string userInfo)
  {
    Ticket foundTicket = _tr.GetById(ticketId);
    if (foundTicket == null)
    {
      throw new Exception("Ticket Does Not Exist");

    }
    return foundTicket;
  }

  internal void DeleteTicket(int ticketId, string accountId)
  {
    Ticket foundTicket = GetTicketId(ticketId, accountId);
    if (foundTicket == null)
    {
      throw new Exception("Ticket Does not Exist");
    }
    if (foundTicket.CreatorId != accountId)
    {
      throw new Exception("Unauthorized to delete ticket");
    }
    _tr.Delete(foundTicket);
  }

  internal Ticket UpdateTicket(Ticket ticketData, string userId)
  {
    Ticket original = GetTicketId(ticketData.Id, ticketData.CreatorId);
    if (ticketData.CreatorId != original.CreatorId)
    {
      throw new Exception("Unauthorized to edit this Ticket");
    }
    if (original.CreatorId != userId)
    {
      throw new Exception("Not authorized");
    }
    original.Ticketname = ticketData.Ticketname ?? original.Ticketname;
    original.Description = ticketData.Description ?? original.Description;
    _tr.Update(original);
    return original;



  }











}