using Microsoft.AspNetCore.Mvc;
using ria.smc.associates.Common.Constants;
using ria.smc.associates.DataAccessLayer.Interfaces.EmployeeManagement;
using ria.smc.associates.DataAccessLayer.Repositories.EmployeeManagement;
using ria.smc.associates.Models.EmployeeManagement;
using ria.smc.associates.UI.Utilities;
using ria.smc.associatesDto.EmployeeManagement;

namespace ria.smc.associates.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeManagementController : ControllerBase
    {
        private readonly IEmployeeManagementRepository _employeeManagementRepository;

        public EmployeeManagementController(IEmployeeManagementRepository employeeManagementRepository)
        {
            _employeeManagementRepository = employeeManagementRepository;
        }
        [HttpGet]
        [Route("GetEmployeeInformation")]
        public async Task<IActionResult> GetEmployeeInformation(string? employeeCode, string? cnic, string? mobileNumber, string? department)
        {
            List<EmployeeInformation> employeeInformation = new List<EmployeeInformation>();
            try
            {
                employeeInformation = await _employeeManagementRepository.GetEmployeeInformation(employeeCode, cnic, mobileNumber, department);
                if (employeeInformation.Any())
                {
                    return Ok(employeeInformation);
                }
                else
                {
                    return StatusCode(404, ApplicationMessages.NotDataFound);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An unexpected error occurred. Please try again later.");
            }

        }
        [HttpPost]
        [Route("EmployeeRegistration")]
        public async Task<IActionResult> EmployeeRegistration([FromBody] EmployeeInformationDTO employeeInformationDTO)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string isValideModel = _employeeManagementRepository.ValidateEmployeeInformation(employeeInformationDTO);
                    if (!string.IsNullOrEmpty(isValideModel))
                    {
                        return StatusCode(StatusCodes.Status500InternalServerError, ApplicationMessages.UnableToPersist);
                    }
                    else
                    {
                        if (employeeInformationDTO.RecordMode == RecordMode.Added)
                        {

                            var result = await _employeeManagementRepository.InsertEmployeeInformation(employeeInformationDTO);
                            if (result < 0)
                                return StatusCode(StatusCodes.Status500InternalServerError, ApplicationMessages.UnableToPersist);
                            return new OkObjectResult(result);

                        }
                        else if (employeeInformationDTO.RecordMode == RecordMode.Updated)
                        {
                            var result = await _employeeManagementRepository.UpdateEmployeeInformation(employeeInformationDTO);
                            if (result < 0)
                                return StatusCode(StatusCodes.Status500InternalServerError, ApplicationMessages.UnableToPersist);
                            return new OkObjectResult(result);
                        }
                        else
                        {
                            var result = await _employeeManagementRepository.DeleteEmployeeInformation(employeeInformationDTO.EmployeeId);
                            if (result < 0)
                                return StatusCode(StatusCodes.Status500InternalServerError, ApplicationMessages.UnableToPersist);
                            return new OkObjectResult(result);
                        }
                    }
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, ApplicationMessages.ValidationFailled);
                }

            }
            catch (Exception ex)
            {
                return StatusCode(500, "An unexpected error occurred. Please try again later.");
            }

        }
    }
}
