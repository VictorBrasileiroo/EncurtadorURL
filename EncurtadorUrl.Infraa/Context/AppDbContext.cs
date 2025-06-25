﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EncurtadorURL.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace EncurtadorURL.Infra.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<UrlModel> Urls { get; set; }
    }
}
