using System;
using System.Collections.Generic;
using System.Xml;

namespace XmlParsingLesson
{
    class Program
    {
        static void Main(string[] args)
        {
            Country country = new Country()
            {
                Id = 1,
                Name = "USSR",
                Cities = new List<City>
                {
                    new City
                    {
                        Id = 1,
                        Name = "Pavlodar",
                        Population = 335,
                        PopulationCountType = PopulationCountType.thousand
                    },
                    new City
                    {
                        Id = 2,
                        Name = "Aqmola",
                        Population = 1.2,
                        PopulationCountType = PopulationCountType.millions
                    }
                }
            };
            //List<Country> Countries = new List<Country>();

            //XmlDocument document = new XmlDocument();
            //document.Load("countries.xml");

            //XmlElement rootElement = document.DocumentElement;

            //foreach (XmlDocument countryElement in rootElement.ChildNodes)
            //{
            //    XmlElement idElement = countryElement.GetElementsByTagName("id")[0] as XmlElement;
            //    XmlElement nameElement = countryElement.GetElementsByTagName("name")[0] as XmlElement;
            //    XmlElement citiesElement = countryElement.GetElementsByTagName("cities")[0] as XmlElement;

            //    List<City> cities = new List<City>();
            //    foreach (XmlElement cityElement in citiesElement.ChildNodes)
            //    {
            //        XmlElement cityIdElement = cityElement.GetElementsByTagName("id")[0] as XmlElement;
            //        XmlElement cityNameElement = cityElement.GetElementsByTagName("name")[0] as XmlElement;
            //        XmlElement cityPopulationElement = cityElement.GetElementsByTagName("population")[0] as XmlElement;

            //        string type = cityPopulationElement.GetAttribute("type");
            //        cities.Add(new City
            //        {
            //            Id = int.Parse(cityIdElement.InnerText),
            //            Name = cityNameElement.InnerText,
            //            Population = double.Parse(cityPopulationElement.InnerText),
            //            PopulationCountType = Enum.Parse<PopulationCountType>(type)
            //        });
            //    }
            //    Countries.Add(new Country
            //    {
            //        Id = int.Parse(idElement.InnerText),
            //        Name = nameElement.InnerText,
            //        cities = citiesElement
            //    });
            //}


            //запись
            var document = new XmlDocument();
            var declaration = document.CreateXmlDeclaration("1.0", "utf-8", string.Empty);
            var rootElement = document.CreateElement("country");

            var countryIdElement = document.CreateElement("id");
            var countryNameElement = document.CreateElement("id");
            var countryCitiesElement = document.CreateElement("id");

            countryIdElement.InnerText = country.Id.ToString();
            countryNameElement.InnerText = country.Name;

            foreach(var city in country.Cities)
            {
                var cityElement = document.CreateElement("city");

                var cityIdElement = document.CreateElement("id");
                var cityNameElement = document.CreateElement("name");
                var cityPopulationElement = document.CreateElement("population");

                var citypopulationTypeAttribute = document.CreateAttribute("type");

                cityIdElement.InnerText = city.Id.ToString();
                cityNameElement.InnerText = city.Name;
                cityPopulationElement.InnerText = city.Population.ToString();

                citypopulationTypeAttribute.Value = city.PopulationCountType.ToString();

                cityPopulationElement.Attributes.Append(citypopulationTypeAttribute);

                cityElement.AppendChild(cityIdElement);
                cityElement.AppendChild(cityNameElement);
                cityElement.AppendChild(cityPopulationElement);

                countryCitiesElement.AppendChild(cityElement);

            }

            rootElement.AppendChild(countryIdElement);
            rootElement.AppendChild(countryNameElement);
            rootElement.AppendChild(countryCitiesElement);

            document.AppendChild(declaration);
            document.AppendChild(rootElement);

            document.Save("1.xml");
        }
    }
}
