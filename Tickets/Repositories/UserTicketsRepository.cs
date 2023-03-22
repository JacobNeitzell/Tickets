namespace Tickets.Repositories;

public class UserTicketsRepository : BaseRepo
{
  public UserTicketsRepository(IDbConnection db) : base(db)
  {

  }

  public UserTickets Create(UserTickets newTicket)
  {
    string sql = @"
INSERT INTO usertickets
(creatorId,ticketId)
VALUES(@CreatorId,@TicketId)
SELECT LAST_INSERT_ID()
;";
    int id = _db.ExecuteScalar<int>(sql, newTicket);
    newTicket.Id = id;
    return newTicket;

  }


  public void Delete(UserTickets savedTicket)
  {
    string sql = @"
  DELETE FROM 
  usertickets
  WHERE id = @Id LIMIT 1
  ;";
    _db.Execute(sql, savedTicket);
  }



}

