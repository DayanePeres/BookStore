﻿using BookStore.Data.Context;
using BookStore.Data.Repository;
using BookStore.Domain.Entities;
using BookStore.Domain.Interfaces.Services;
using BookStore.Service.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace BookStore.Application.Controllers
{

    public class BookController : BaseController<BookEntity>
    {
        public BookController(IBookService service) : base(service)
        {
        }
    }

}
