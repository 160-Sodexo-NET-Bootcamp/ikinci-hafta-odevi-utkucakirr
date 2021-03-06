using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.DataModel;
using Data.DataModel.DTOs;
using Data.Uow;
using Microsoft.Extensions.Logging;

namespace UtkuCakir_Odev2.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public class ContainerController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<ContainerController> _logger;

        public ContainerController(ILogger<ContainerController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            //Getting all containers from database.
            var listOfContainers = await _unitOfWork.ContainerRepository.GetAll();
            if (listOfContainers is null)
            {
                return Ok("There is no containers.");
            }
            return Ok(listOfContainers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            //getting the container whose id is equal to the parameter value.
            var container = await _unitOfWork.ContainerRepository.GetById(id);
            if (container is null)
            {
                return NotFound();
            }

            return Ok(container);
        }

        //Creating a container. For this method, ContainerViewModel is used. By this way, the user don't have to enter id value. Id value will be generated by database.
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ContainerViewModel entity)
        {
            //Converting ContainerViewModel to Container model for adding to the database.
            Container addedEntity = _unitOfWork.ContainerRepository.Convert(entity);
            var response = await _unitOfWork.ContainerRepository.Add(addedEntity);
            _unitOfWork.Complete();
            if (response)
            {
                return Ok("Added");
            }
            return Ok("Failed");
        }

        //Updating a container. For this method, ContainerUpdateModel is used. By this way, the user can't change the VehicleId value.
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] ContainerUpdateModel entity)
        {
            //Converting process will be achieved in UpdateWithoutVehicle method.
            var response = await _unitOfWork.ContainerRepository.UpdateWithoutVehicle(entity);
            _unitOfWork.Complete();
            return Ok();
        }

        //Deleting a container by just entering the id value.
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var response = await _unitOfWork.ContainerRepository.Delete(id);
            _unitOfWork.Complete();
            if (response)
            {
                return Ok("Deleted.");
            }
            return Ok("Failed");
        }
    }
}
