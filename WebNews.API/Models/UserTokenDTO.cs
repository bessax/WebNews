﻿namespace WebNews.API.Models;
public class UserTokenDTO
{
    public bool Authenticated { get; set; }
    public DateTime Expiration { get; set; }
    public string Token { get; set; } = string.Empty;
    public string Message { get; set; } = string.Empty;
}
