//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EntitySonKısım
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class DBEntityEğitimEntities : DbContext
    {
        public DBEntityEğitimEntities()
            : base("name=DBEntityEğitimEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Tbl_Ders> Tbl_Ders { get; set; }
        public virtual DbSet<Tbl_Kulup> Tbl_Kulup { get; set; }
        public virtual DbSet<Tbl_Not> Tbl_Not { get; set; }
        public virtual DbSet<Tbl_Ogrenci> Tbl_Ogrenci { get; set; }
        public virtual DbSet<Tbl_Urun> Tbl_Urun { get; set; }
    
        public virtual ObjectResult<KULUPLER_Result> KULUPLER()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<KULUPLER_Result>("KULUPLER");
        }
    }
}
