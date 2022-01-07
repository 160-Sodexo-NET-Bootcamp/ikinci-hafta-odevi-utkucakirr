using Data.DataModel;
using Data.DataModel.DTOs;
using Data.Generic;

namespace Data.Repositories.VehicleRepo
{
    public interface IVehicleRepository:IGenericRepository<Vehicle>
    {
        Vehicle Convert(VehicleViewModel entity);
    }
}
