﻿using PizzaProject2.Models.GraphData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PizzaProject2.Controllers
{
    public class GraphController : Controller
    {
        // GET: Graph
        //public ActionResult Index()
        //{
        //    return View();
        //}

        [Authorize(Roles = "Admin")]
        public ActionResult ViewGraph()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public ActionResult ViewGraph2()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public ActionResult GetJsonTest()
        {
            GraphDataClass gdc = new GraphDataClass();
            List<GraphDataViewModel> viewModels = gdc.ConvertToViewModels();

            return Json(viewModels, JsonRequestBehavior.AllowGet);
        }
    }
}