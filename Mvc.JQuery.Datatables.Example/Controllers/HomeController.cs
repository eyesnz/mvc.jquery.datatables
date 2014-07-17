﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Resources;

namespace Mvc.JQuery.Datatables.Example.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult InitialSearch()
        {
            return View();
        }

        public ActionResult JSUnitTests()
        {
            return View();
        }

        public DataTablesResult<UserView> GetUsers(DataTablesParam dataTableParam)
        {
            return DataTablesResult.Create(FakeDatabase.Users.Select(user => new UserView()
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Position = user.Position == null ? "" : user.Position.ToString(),
                Number = user.Number,
                Hired = user.Hired,
                IsAdmin = user.IsAdmin,
                Salary = user.Salary
            }), dataTableParam,
            uv => new 
            {
                Name = "<b>" + uv.Name + "</b>",
                Hired = uv.Hired == null ? "&lt;pending&gt;" : uv.Hired.Value.ToShortDateString() + " (" + FriendlyDateHelper.GetPrettyDate(uv.Hired.Value) + ") "
            });
        }

        //public DataTablesResult<User> GetUsersUntyped(DataTablesParam dataTableParam)
        //{
        //    var users = FakeDatabase.Users;

        //    return DataTablesResult.Create(users, dataTableParam);
        //}


    }


   

    public class UserView
    {
       
        [DataTables(DisplayName = "Name", DisplayNameResourceType = typeof(UserViewResource), MRenderFunction = "encloseInEmTag")]
        public string Name { get; set; }

        [DataTables(SortDirection = SortDirection.Ascending, Order = 0)]
        public int Id { get; set; }

        [DataTables(DisplayName = "E-Mail", Searchable = false)]
        public string Email { get; set; }

        [DataTables( Sortable = false)]
        public bool IsAdmin { get; set; }

        [DataTables(Visible = false)]
        public bool AHiddenColumn { get; set; }


        [DataTables(Visible = false)]
        public decimal Salary { get; set; }
        
        public string Position { get; set; }
        public DateTime?  Hired { get; set; }

        public Numbers Number { get; set; }

        
    }
}