namespace Tickets.Repositories;

public class TicketsRepository : BaseRepo
{

  public TicketsRepository(IDbConnection db) : base(db)
  {

  }


  public Ticket Create(Ticket newTicket)
  {
    string sql = @"
    INSERT INTO ticket(description,ticketname,ticketclient,creatorId)
    VALUES(@Description,@Ticketname,@Ticketclient,@CreatorId);
    SELECT LAST_INSERT_ID()
    ;";
    int ticketId = _db.ExecuteScalar<int>(sql, newTicket);
    newTicket.Id = ticketId;
    return newTicket;
  }

  public void Delete(Ticket foundTicket)
  {
    string sql = @"
DELETE FROM ticket
WHERE id = @id
;";
    int ticketRows = _db.Execute(sql, foundTicket);
    if (ticketRows == 0)
    {
      throw new Exception("Unable to delete the Ticket");
    }
  }


  public Ticket GetById(int ticketId)
  {
    string sql = @"
SELECT 
tick.*
a.*
FROM ticket tick
JOIN accounts a on a.id = tick.creatorId
WHERE tick.id = @ticketId
;";
    return _db.Query<Ticket, Account, Ticket>(sql, (ticket, account) =>
    {
      ticket.Creator = account;
      return ticket;
    }, new { ticketId }).FirstOrDefault();
  }














}