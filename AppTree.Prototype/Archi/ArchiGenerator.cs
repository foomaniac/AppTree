using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using AppTree.Infrastructure;
using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.EntityFrameworkCore;

namespace AppTree.Prototype.Archi
{
    public class ArchiGenerator
    {
        private static AppTreeContext _context;

        public void ExportDiagram()
        {
            var options = new DbContextOptionsBuilder<AppTreeContext>();
            options.UseSqlServer("server=DAJONESW10\\SQLEXPRESS;database=DEV_AppTree;trusted_connection=true;", null);
            _context = new AppTreeContext(options.Options);

            var artemis = _context.Applications
                .Include(app => app.Dependencies)
                .ThenInclude(appDep => appDep.Application).First(app => app.Id == 1);

            var listOfElements = new List<Element>();
            var listOfRelations = new List<Relation>();

            var diagram = new Element($"id-{Guid.NewGuid()}", "ArchimateModel", "AppTree Diagram", "");
            listOfElements.Add(diagram);

            var parentAppGuid = Guid.NewGuid();

            var parentApp = new Element($"id-{parentAppGuid}", "ApplicationComponent", artemis.Name, artemis.Summary);
            listOfElements.Add(parentApp);

            foreach (var artemisDependency in artemis.Dependencies)
            {
                var dependencyAppGuid = Guid.NewGuid();
                listOfElements.Add(new Element($"id-{dependencyAppGuid}",
                    "ApplicationService",
                    artemisDependency.Application.Name,
                    artemisDependency.Application.Summary));

                listOfRelations.Add(new Relation($"id-{Guid.NewGuid()}", "ServingRelationship", "", "", $"id-{parentAppGuid}", $"id-{dependencyAppGuid}"));
            }

            WriteCSVFiles(listOfElements, listOfRelations);
        }

        private void WriteCSVFiles(IList<Element> elements, IList<Relation> relations)
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                ShouldQuote = args => true
            };


            using (var writer = new StreamWriter("C:\\Archi\\elements.csv"))
            using (var csv = new CsvWriter(writer, config))
            {
                csv.WriteRecords(elements);
            }

            using (var writer = new StreamWriter("C:\\Archi\\relations.csv"))
            using (var csv = new CsvWriter(writer, config))
            {
                csv.WriteRecords(relations);
            }
        }
        private abstract class ArchiBaseType
        {
            public string ID { get; internal set; }
            public string Type { get; internal set; }

            public string Name { get; internal set; }

            public string Documentation { get; internal set; }
        }

        private class Element : ArchiBaseType
        {
            public Element(string id, string type, string name, string documentation)
            {
                ID = id;
                Type = type;
                Name = name;
                Documentation = documentation;
            }
        }

        private class Relation
        {
            public Relation(string id, string type, string name, string documentation, string source, string target)
            {
                ID = id;
                Type = type;
                Name = name;
                Documentation = documentation;
                Source = source;
                Target = target;
            }

            public string ID { get; internal set; }
            public string Type { get; internal set; }

            public string Name { get; internal set; }

            public string Documentation { get; internal set; }

            public string Source { get; private set; }
            public string Target { get; private set; }
        }
    }
}
