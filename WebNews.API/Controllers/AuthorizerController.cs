﻿using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebNews.API.Models;
using WebNews.API.Utils;

namespace WebNews.API.Controllers;

[Route("/api/{v:apiVersion}/[controller]")]
[ApiController]
public class AuthorizerController : ControllerBase
{
    private readonly UserManager<IdentityUser> userManager;
    private readonly SignInManager<IdentityUser> signInManager;
    private readonly IValidator<UserDTO> validator;
    private readonly GenerateToken generateToken;
    private readonly IConfiguration configuration;

    public AuthorizerController(UserManager<IdentityUser> userManager,
        SignInManager<IdentityUser> signInManager,
        IValidator<UserDTO> _validator,
        IConfiguration configuration)
    {
        this.userManager = userManager;
        this.signInManager = signInManager;       
        this.configuration = configuration;
        validator = _validator;
        generateToken = new GenerateToken(this.configuration);

    }

    [HttpPost("Register")]
    public async Task<IActionResult> RegistrarUsuario(UserDTO user)
    {
        var validation = await validator.ValidateAsync(user);

        if (!validation.IsValid)
        {
            return this.BadRequest(validation.ToDictionary());
        }

        var identityUser = new IdentityUser
        {
            UserName = user.Email,
            Email = user.Email,
            EmailConfirmed = true

        };

        var result = await userManager.CreateAsync(identityUser, user.Password);
        if (!result.Succeeded)
        {
            return BadRequest("Falha ao criar usuário. Contacte o administrador ===>" + result.Errors);
        }
        await signInManager.SignInAsync(identityUser, false);
        return Ok(generateToken.GenerateUserToken(user));
    }

    [HttpPost("Login")]
    public async Task<IActionResult> LoginUsuario(UserDTO user)
    {
        var validation = await validator.ValidateAsync(user);

        if (!validation.IsValid)
        {
            return this.BadRequest(validation.ToDictionary());
        }

        var result = await signInManager.PasswordSignInAsync(user.Email,
            user.Password, isPersistent: false, lockoutOnFailure: false);

        if (!result.Succeeded)
        {
            return BadRequest("Login inválido.");
        }
        return Ok(generateToken.GenerateUserToken(user));

    }

}
