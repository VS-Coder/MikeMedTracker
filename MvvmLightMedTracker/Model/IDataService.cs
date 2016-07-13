using System.Threading.Tasks;

namespace MvvmLightMedTracker.Model
{
    public interface IDataService
    {
        Task<DataItem> GetData();
    }
}