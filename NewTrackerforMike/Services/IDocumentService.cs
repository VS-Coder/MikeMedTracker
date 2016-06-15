using NewTrackerforMike.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewTrackerforMike.Services
{
    public interface IDocumentService
    {
        string GetImagePath(Meds med);
    }
}
