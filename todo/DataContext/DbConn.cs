using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using todo.Models;

namespace todo.DataContext
{
    class DbConn : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\Local;Initial Catalog=todo;Integrated Security=True");
        }

        public DbSet<Todo> todo { get; set; }
    }
}
    