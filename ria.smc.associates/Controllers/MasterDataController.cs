using Microsoft.AspNetCore.Mvc;
using ria.smc.associates.DataAccessLayer.Interfaces.MasterData;
using ria.smc.associates.Models.MasterData;

namespace ria.smc.associates.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MasterDataController : ControllerBase
    {
        private readonly IMasterDataRepository _masterDataRepository;

        public MasterDataController(IMasterDataRepository masterDataRepository)
        {
            _masterDataRepository = masterDataRepository;
        }

        [HttpGet("GetGenders")]
        public async Task<IActionResult> GetGenders()
        {
            List<Genders> Genders = new List<Genders>();
            try
            {
                Genders = await _masterDataRepository.GetGenders();
                if (Genders != null)
                {
                    return Ok(Genders);
                }
                else
                {
                    return StatusCode(404, "An unexpected error occurred. Please try again later.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An unexpected error occurred. Please try again later.");
            }
        }

        [HttpGet("GetBloodGroups")]
        public async Task<IActionResult> GetBloodGroups()
        {
            List<BloodGroups> bloodGroups = new List<BloodGroups>();
            try
            {
                bloodGroups = await _masterDataRepository.GetBloodGroups();
                if (bloodGroups != null)
                {
                    return Ok(bloodGroups);
                }
                else
                {
                    return StatusCode(404, "An unexpected error occurred. Please try again later.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An unexpected error occurred. Please try again later.");
            }
        }

        [HttpGet("GetMaritalStatuses")]
        public async Task<IActionResult> GetMaritalStatuses()
        {
            List<MaritalStatuses> maritalStatuses = new List<MaritalStatuses>();
            try
            {
                maritalStatuses = await _masterDataRepository.GetMaritalStatus();
                if (maritalStatuses != null)
                {
                    return Ok(maritalStatuses);
                }
                else
                {
                    return StatusCode(404, "An unexpected error occurred. Please try again later.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An unexpected error occurred. Please try again later.");
            }
        }
        [HttpGet("GetEmployeeTypes")]
        public async Task<IActionResult> GetEmployeeTypes()
        {
            List<EmployeeTypes> employeeTypes = new List<EmployeeTypes>();
            try
            {
                employeeTypes = await _masterDataRepository.GetEmployeeTypes();
                if (employeeTypes != null)
                {
                    return Ok(employeeTypes);
                }
                else
                {
                    return StatusCode(404, "An unexpected error occurred. Please try again later.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An unexpected error occurred. Please try again later.");
            }
        }

        [HttpGet("GetEmployeeStatus")]
        public async Task<IActionResult> GetEmployeeStatus()
        {
            List<EmployeeStatuses> employeeStatuses = new List<EmployeeStatuses>();
            try
            {
                employeeStatuses = await _masterDataRepository.GetEmployeeStatuses();
                if (employeeStatuses != null)
                {
                    return Ok(employeeStatuses);
                }
                else
                {
                    return StatusCode(404, "An unexpected error occurred. Please try again later.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An unexpected error occurred. Please try again later.");
            }
        }
    }
}
