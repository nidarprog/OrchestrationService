using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PlatformService.Data;
using PlatformService.Dtos;

namespace PlatformService.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class Platformsontroller : ControllerBase
    {
        // private readonly ILogger<Platformsontroller> _logger;// we will use later
        private readonly IPlatformRepo _repository;
        private readonly IMapper _mapper;   

        public Platformsontroller(IPlatformRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PlatformReadDto>> getPlatforms()
        {
            Console.WriteLine("--> Getting platform service from commandline serive");
            
            var platformItem = _repository.GetAllPlatforms();

            return Ok(_mapper.Map<IEnumerable<PlatformReadDto>>(platformItem));
        }
    }
}