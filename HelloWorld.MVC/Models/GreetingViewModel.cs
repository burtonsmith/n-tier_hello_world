using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using HelloWorld.Domain.Entities;
using HelloWorld.MVC.Infrastructure;

namespace HelloWorld.MVC.Models
{
    public class GreetingViewModel : ICreateMapping<Greeting>
    {
        public int Id { get; set; }

        [Required]
        public string Description { get; set; }
    }
}