using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoCrud.API.Models.Domain;
using MongoCrud.API.Models.DTO;
using MongoCrud.API.Repository;
using System.Runtime.InteropServices;

namespace MongoCrud.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IBranchRepository _branchRepo;

        public BranchController(IMapper mapper,IBranchRepository branchRepo)
        {
            _mapper = mapper;
            _branchRepo = branchRepo;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddBranchDto branchDto)
        {
            //dto to model
            var branchModel = _mapper.Map<Branch>(branchDto);
            branchModel = await _branchRepo.CreateAsync(branchModel);
            return Ok(branchModel);
        }

        [HttpGet]
        [Route("branchid/{branchid}")]
        public async Task<IActionResult> GetByBranchId([FromRoute] int branchid)
        {
            try
            {
                var branch = await _branchRepo.GetByBranchIdAsync(branchid);
                if (branch == null)
                {
                    return NotFound("Branch with this BranchId not found");
                }
                return Ok(branch);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet]
        [Route("id/{id}")]
        public async Task<IActionResult> GetById([FromRoute] string id)
        {
            try
            {
                var branch = await _branchRepo.GetByIdAsync(id);
                if (branch == null)
                {
                    return NotFound("Branch with this Id not found");
                }
                return Ok(branch);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var branch = await _branchRepo.GetAllAsync();
            return Ok(branch);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] string id, [FromBody] UpdateBranchDto branchDto)
        {
            var branch=await _branchRepo.UpdateAsync(id, branchDto);
            if(branch == null)
            {
                return BadRequest("id not found");
            }
            return Ok(branch);
        }

    }
}
