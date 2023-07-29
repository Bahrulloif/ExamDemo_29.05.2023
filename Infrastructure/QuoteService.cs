using Dapper;
using Npgsql;

public class QuoteService
{
    private DapperContext _context;
    public QuoteService()
    {
        _context = new DapperContext();
    }
    public List<Quote> GetQuotes()
    {
        var connection = _context.CreateConnection();
        var sql = "SELECT * FROM quotes";
        return connection.Query<Quote>(sql).ToList();
    }

    public Quote CreateQuote(Quote quote)
    {
        var connection = _context.CreateConnection();
        var sql = "insert into quotes (id, TextOfQuote, author, categoryid) " +
        "values (@id, @TextOfQuote, @author, @categoryid) returning id";
        var createdId = connection.ExecuteScalar<int>(sql, quote);
        quote.Id = createdId;
        return quote;
    }

    public int UpdateQuotes(Quote quote)
    {
        var connection = _context.CreateConnection();
        var sql = "update quotes set TextOfQuote=@TextOfQuote, author=@author, categoryid=@categoryid where id=@id";
        var response = connection.Execute(sql, quote);
        return response;
    }

    public int DeleteQuotes(int id)
    {
        var connection = _context.CreateConnection();
        var sql = "delete from quotes where id=@id";
        var response = connection.Execute(sql, new { id });
        return response;
    }

    public List<Quote> GetAllQuotesByCategory(int categoryid)
    {
        var connection = _context.CreateConnection();
        var sql = "select * from quotes where categoryid=@categoryid";
        var response = connection.Query<Quote>(sql, new { categoryid }).ToList();
        return response;
    }

    public Quote GetQuoteRandom()
    {
        var connection = _context.CreateConnection();
        var sql = "SELECT * FROM quotes ORDER BY RANDOM() LIMIT 1";
        var response = connection.QuerySingleOrDefault<Quote>(sql);
        return response;

    }



}