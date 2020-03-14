using ASPCoreRestfulApiDemo.Data;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPCoreRestfulApiDemo.Controllers
{
    [ApiController]
    [Route("api/company/{companyId}/employees")]
    public class EmployeesController:ControllerBase
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
