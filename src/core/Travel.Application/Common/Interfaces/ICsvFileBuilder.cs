using System;
using System.Collections.Generic;
using System.Text;

namespace Travel.Application.Common.Interfaces
{
    public interface ICsvFileBuilder
    {
        byte[] BuildTourPackageFile(IEnumerable<TourPackageRecord> records);
    }
}
