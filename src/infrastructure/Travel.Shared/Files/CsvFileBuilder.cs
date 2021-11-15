using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using System.IO;
using Travel.Application.Common.Interfaces;

namespace Travel.Shared.Files
{
    public class CsvFileBuilder : ICsvFileBuilder
    {
        public byte[] BuildTourPackagesFile(IEnumerable<TourPackageRecord> records)
        {
            using var memoryStream = new MemoryStream();

            return memoryStream.ToArray();
        }
    }
}
