using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Library.LearningMangementSystem.models
{
    public class Module
    {
        public string? Name { get; set; }

        public string? Descrition { get; set; }

        public List<ContentItem> Content {  get; set; }
        public Module() { 
            Content = new List<ContentItem>();
        }
    }
}
