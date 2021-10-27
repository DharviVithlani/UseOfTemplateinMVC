﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataAccess
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class exampleEntities : DbContext
    {
        public exampleEntities()
            : base("name=exampleEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<State> States { get; set; }
        public virtual DbSet<User> Users { get; set; }
    
        public virtual ObjectResult<uspGetAllMembers_Result> uspGetAllMembers(string searchBy, string sortby, string sorttype)
        {
            var searchByParameter = searchBy != null ?
                new ObjectParameter("SearchBy", searchBy) :
                new ObjectParameter("SearchBy", typeof(string));
    
            var sortbyParameter = sortby != null ?
                new ObjectParameter("sortby", sortby) :
                new ObjectParameter("sortby", typeof(string));
    
            var sorttypeParameter = sorttype != null ?
                new ObjectParameter("sorttype", sorttype) :
                new ObjectParameter("sorttype", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<uspGetAllMembers_Result>("uspGetAllMembers", searchByParameter, sortbyParameter, sorttypeParameter);
        }
    
        public virtual ObjectResult<uspGetUserByUserName_Result> uspGetUserByUserName(string userName)
        {
            var userNameParameter = userName != null ?
                new ObjectParameter("UserName", userName) :
                new ObjectParameter("UserName", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<uspGetUserByUserName_Result>("uspGetUserByUserName", userNameParameter);
        }
    
        public virtual int uspUploadProfile(Nullable<int> id, string imagepath)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            var imagepathParameter = imagepath != null ?
                new ObjectParameter("imagepath", imagepath) :
                new ObjectParameter("imagepath", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("uspUploadProfile", idParameter, imagepathParameter);
        }
        public virtual ObjectResult<uspGetAllUsers_Result> uspGetAllUsers()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<uspGetAllUsers_Result>("uspGetAllUsers");
        }
    }
}
