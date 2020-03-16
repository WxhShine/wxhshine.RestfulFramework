using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using wxhshine.Domian.Entities;

namespace wxhshine.Interface.RestAPI.Controllers
{
    [ApiController]
    [Route("api/company/{companyId}/employees")]
    public class EmployeesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly AspCoreRestApiDbContext _context;

        public EmployeesController(IMapper mapper, AspCoreRestApiDbContext context)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
    }
}
