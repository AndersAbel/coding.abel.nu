using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CodingAbelNu.Utilities.ToSelectListItems;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace MvcApplication.Models
{
    public class SelectDemoModel
    {
        private class Color
        {
            public Color(int id, string name)
            {
                Id = id;
                Name = name;
            }
            public int Id { get; set; }
            public string Name { get; set; }
        }

        public SelectDemoModel()
        {
            Debug.WriteLine("SelectDemoModel.SelectDemoModel()");
            Message = "Default Message";
        }

        private static readonly List<Color> colors = new List<Color> { 
        new Color(1, "Black"),  new Color(2, "Red"), new Color(3, "Green"),
        new Color(4, "Blue"), new Color(5, "White")};

        private string message;

        [Required]
        public string Message
        {
            get
            {
                Debug.WriteLine("SelectDemoModel.Message.get returning " + message);
                return message;
            }
            set
            {
                Debug.WriteLine("SelectDemoModel.Message.set setting value to " + value);
                message = value;
            }
        }

        [Required]
        public int ColorId { get; set; }

        private static readonly IEnumerable<SelectListItem>
            colorChoises = colors.ToSelectListItems(c => c.Id, c => c.Name);

        public static IEnumerable<SelectListItem> Colors
        {
            get
            {
                return colorChoises;
            }
        }
    }
}