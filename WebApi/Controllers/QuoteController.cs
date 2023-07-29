using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class QuoteController : ControllerBase
{
    private QuoteService _quoteService = new QuoteService();

    [HttpPost("Create")]
    public Quote AddQuote(Quote quote)
    {
        return _quoteService.CreateQuote(quote);
    }


    [HttpGet("Read")]
    public List<Quote> ReadQuotes()
    {
        return _quoteService.GetQuotes();
    }

    [HttpPost("Update")]
    public int UpdateQuotes(Quote quote)
    {
        return _quoteService.UpdateQuotes(quote);
    }

    [HttpDelete("Delete")]
    public int DeleteQuotes(int id)
    {
        return _quoteService.DeleteQuotes(id);
    }

    [HttpGet("ByCategory")]
    public List<Quote> ReadQuotesByCategory(int category)
    {
        return _quoteService.GetAllQuotesByCategory(category);
    }

    [HttpGet("Random")]
    public Quote ReadQuotesRandom()
    {
        return _quoteService.GetQuoteRandom();
    }

}