namespace Tickets.Repositories;

public class TicketsRepository : BaseRepo
{

  public TicketsRepository(IDbConnection db) : base(db)
  {

  }


  public Ticket Create(Ticket newTicket)
  {
    string sql = @"
    INSERT INTO tickets(description,ticketname,ticketclient)
    VALUES(@Description,@Ticketname,@Ticketclient);
    SELECT LAST_INSERT_ID()
    ;";
    int ticketId = _db.ExecuteScalar<int>(sql, newTicket);
    newTicket.Id = ticketId;
    return newTicket;
  }

  public void Delete(Ticket foundTicket)
  {
    string sql = @"
DELETE FROM tickets
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
    return _db.Query<Ticket, Profile, Ticket>(sql, (ticket, profile) =>
    {
      ticket.Creator = profile;
      return ticket;
    }, new { ticketId }).FirstOrDefault();
  }














}