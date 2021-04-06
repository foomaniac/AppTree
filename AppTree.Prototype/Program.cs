using System;
using System.Linq;
using AppTree.Infrastructure;
using AppTree.Prototype.Archi;
using Microsoft.EntityFrameworkCore;

namespace AppTree.Prototype
{
    class Program
    {
       
        static void Main(string[] args)
        {
            var archiGenerator = new ArchiGenerator();
            archiGenerator.ExportDiagram();
        }
    }
}
