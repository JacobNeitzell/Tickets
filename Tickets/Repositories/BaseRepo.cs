namespace Tickets.Repositories;

public class BaseRepo
{

  protected readonly IDbConnection _db;

  public BaseRepo(IDbConnection db)
  {
    _db = db;
  }

}