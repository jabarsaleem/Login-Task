using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Login_Task.Models
{
    public class Users: DbContext
    { 
       public Users(DbContextOptions<Users> options) : base(options)
    {

    }
        public DbSet<Userlogin> userlogin { get; set; }

    
    }
}
