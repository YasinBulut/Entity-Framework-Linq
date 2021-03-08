using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Skill_CodeFirst_Entity.Models.Sınıflar
{
    public class CONTEXT : DbContext
    {
        public DbSet<Yetenekler> YETENEKLERS  { get; set; }
    }
}