using System.Collections.Generic;
using System.Threading.Tasks;
using Data.DataModel;
using Data.DataModel.DTOs;
using Data.Generic;

namespace Data.Repositories.ContainerRepo
{
    public interface IContainerRepository:IGenericRepository<Container>
    {
        Task<IEnumerable<Container>> GetByVehicleId(long id);
        Task<bool> UpdateWithoutVehicle(ContainerUpdateModel entity);
        Task<List<GroupModelForContainers>> GroupByVehicleId(long id, int n);
        GroupModelForContainers GroupModelCreator(int n, List<ContainerViewModel> containers);
        ContainerViewModel ConvertToViewModel(Container entity);
        Container Convert(ContainerViewModel entity);
    }
}
