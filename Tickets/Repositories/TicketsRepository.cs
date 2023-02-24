namespace Tickets.Repositories;

public class TicketsRepository : BaseRepo
{

  public TicketsRepository(IDbConnection db) : base(db)
  {

  }


  public Ticket Create(Ticket newTicket)
  {
    string sql = @"
    INSERT INTO tickets(ticketId,description,ticketname,ticketclient)
    VALUES(@TicketId,@Description,@Ticketname,@Ticketclient)
    SELECT LAST_INSERT_ID()
    ;";
    int ticketId = _db.ExecuteScalar<int>(sql, newTicket);
    newTicket.Id = ticketId;
    return newTicket;
  }

















}