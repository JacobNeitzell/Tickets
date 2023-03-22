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

  public UserTickets GetByUserTicketId(int userticketId)
  {
    string sql = @"
  SELECT 
  *,
  COUNT(ut.id) AS UserTick,
  ut.id AS userticketsId
  FROM usertickets ut
  WHERE id =@userticketsId
  GROUP BY ut.id 

  ;";
    return _db.QueryFirstOrDefault<UserTickets>(sql, new { userticketId });
  }




}

