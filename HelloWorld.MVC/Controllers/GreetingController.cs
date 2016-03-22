using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using HelloWorld.Domain.Entities;
using HelloWorld.Domain.ServiceInterfaces;
using HelloWorld.MVC.Models;

namespace HelloWorld.MVC.Controllers
{
    public class GreetingController : Controller
    {
        private readonly IGreetingService _greetingService;

        public GreetingController(IGreetingService greetingService)
        {
            _greetingService = greetingService;
        }

        // GET: Greeting
        public ActionResult Index()
        {
            var greetings = _greetingService.Data.ToList();

            var viewModel = Mapper.Map<IList<GreetingViewModel>>(greetings);

            return View(viewModel);
        }

        // GET: Greeting/Details/5
        public ActionResult Details(int id)
        {
            var greeting = _greetingService.GetById(id);

            var viewModel = Mapper.Map<GreetingViewModel>(greeting);

            return View(viewModel);
        }

        // GET: Greeting/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Greeting/Create
        [HttpPost]
        public ActionResult Create(GreetingViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var greeting = Mapper.Map<Greeting>(viewModel);

                    _greetingService.Insert(greeting);

                    return RedirectToAction("Index");
                }
                catch
                {
                    return View(viewModel);
                }
            }

            return View(viewModel);
        }

        // GET: Greeting/Edit/5
        public ActionResult Edit(int id)
        {
            var greeting = _greetingService.GetById(id);

            var viewModel = Mapper.Map<GreetingViewModel>(greeting);

            return View(viewModel);
        }

        // POST: Greeting/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, GreetingViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var greeting = Mapper.Map<Greeting>(viewModel);

                    _greetingService.Update(greeting);

                    return RedirectToAction("Index");
                }
                catch
                {
                    return View(viewModel);
                }
            }
            else
            {
                return View(viewModel);
            }
        }

        // GET: Greeting/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Greeting/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, GreetingViewModel viewModel)
        {
            try
            {
                _greetingService.Delete(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View(viewModel);
            }
        }
    }
}
