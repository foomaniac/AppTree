using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using AppTree.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace AppTree.Prototype.Draw.IO
{
    /// <summary>
    /// POC To generate data to import into Draw.IO
    /// </summary>
    public class DrawIOGenerator
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

            Console.WriteLine($"{artemis.Id},{artemis.Name},#dae8fc,#6c8ebf,rectangle,");

            foreach (var artemisDependency in artemis.Dependencies)
            {
                Console.WriteLine(
                    $"{artemisDependency.ApplicationId},{artemisDependency.Application.Name},#fff2cc,#d6b656,rectangle,{artemis.Id}");
            }

            Console.ReadLine();
        }
    }
}
