using System;
using System.Collections.Generic;
using System.Text;

namespace XmlParsingLesson
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection <City> Cities {get;set;}
    }
}
