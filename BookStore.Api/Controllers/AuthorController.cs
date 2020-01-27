using BookStore.Domain.Entities;
using BookStore.Domain.Interfaces.Services;
using BookStore.Service.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Application.Controllers
{
    public class AuthorController : BaseController<AuthorEntity>
    {
        public AuthorController(IAuthorService service) : base(service)
        {
        }
    }
}
