﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CookBookASP.Converters;
using CookBookASP.Models;
using CookBookASP.Session;
using CookBookASP.ViewModels;
using CookBookBLL.Logic;
using CookBookBLL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using static CookBookASP.Converters.ModelConverter;

namespace CookBookASP.Controllers
{
    public class StepController :  ControllerBase<StepController>
    {
        private readonly SessionManager<ItemInfo> sessionManager;
        private readonly IMapper mapper;
        private readonly StepProcessor stepProcessor;

        public StepController(StepProcessor stepProcessor, IMapper mapper, SessionManager<ItemInfo> sessionManager)
        {
            this.sessionManager = sessionManager;
            this.mapper = mapper;
            this.stepProcessor = stepProcessor;
        }
        public ActionResult Index(int id)
        {
            List<StepVM> model = stepProcessor.Get(id).DTOToViewModelList(MapStep);
            return View(model);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            int recipeId= stepProcessor.Delete(id);
            return RedirectToAction(nameof(Index), new { id=recipeId });
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(StepVM model)
        {
            stepProcessor.Create(mapper.Map<StepDTO>(model));
            return RedirectToAction(nameof(Index),
                new { id = model.Recipe_Id });
        }

        [HttpPost]
        public ActionResult Edit(StepVM model)
        {
            int id=stepProcessor.Update(mapper.Map<StepDTO>(model));
            return RedirectToAction(nameof(Index), 
                new { id});
        }
    }
}

