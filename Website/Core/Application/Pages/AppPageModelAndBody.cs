using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Html;

namespace CommunicatorCms.Core.Application.Pages
{
    public class AppPageModelAndBody
    {
        public object Model { get; set; }
        public IHtmlContent Body { get; set; }

        public AppPageModelAndBody(object model, IHtmlContent body) 
        {
            Model = model;
            Body = body;
        }
    }
}
