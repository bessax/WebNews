using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebNews.Application.Interface;
using WebNews.Domain.Dtos;

namespace WebNews.API.Controllers;

[ApiController]
[Route("/api/{v:apiVersion}/[controller]")]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class NewsController : ControllerBase
{
    private readonly INewsAppService newsappservice;
    public NewsController(INewsAppService newsappservice)
    {
        this.newsappservice = newsappservice;
    }

    [HttpPost]
    public async Task<ActionResult<NewsDTO>> PostNews(NewsDTO dto)
    {
        var retorno = await this.newsappservice.AddNewsAsync(dto);
        return this.Ok(retorno);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<NewsDTO>> GetNews(int id)
    {
        var news = await this.newsappservice.FindNewsIdAsync(id);

        if (news == null)
        {
            return this.NotFound();
        }

        return news;
    }


    [HttpGet]
    public async Task<ActionResult<IEnumerable<NewsDTO?>>> GetAgencias()
    {
        var listNews = await this.newsappservice.FindNewsAsync();

        if (listNews == null)
        {
            return this.NotFound();
        }

        return Ok(listNews);
    }


}