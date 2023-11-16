using AutoMapper;
using FormulaOne.Dtos.Responses;
using FormulaOne.Models;
using FormulaOne.Repository.Interface;
using Microsoft.AspNetCore.Mvc;


namespace FormulaOne.Controllers;

public class DriverController : BaseController
{
    public DriverController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {
    }

    [HttpGet("")]
    public async Task<IActionResult> GetAllDrivers()
    {
        var driver = await _unitOfWork.Drivers.All();

        var result = _mapper.Map<IEnumerable<GetDriverResponse>>(driver);

        return Ok(result);
    }

    [HttpGet]
    [Route("{driverId:Guid}")]
    public async Task<IActionResult> GetDriver(Guid driverId)
    {
        var driver = await _unitOfWork.Drivers.GetById(driverId);

        if (driver == null) return NotFound();

        var result = _mapper.Map<GetDriverResponse>(driver);

        return Ok(result);
    }

    [HttpPost("")]
    public async Task<IActionResult> AddDriver([FromBody] Driver driver)
    {
        if (!ModelState.IsValid) return BadRequest();

        var result = _mapper.Map<Driver>(driver);

        await _unitOfWork.Drivers.Add(result);
        await _unitOfWork.CompleteAsync();

        return CreatedAtAction(nameof(GetDriver), new { driverId = result.Id }, result);
    }

    [HttpPut("")]
    public async Task<IActionResult> UpdateDriver([FromBody] Driver driver)
    {
        if (!ModelState.IsValid) return BadRequest();

        var result = _mapper.Map<Driver>(driver);

        await _unitOfWork.Drivers.Update(result);
        await _unitOfWork.CompleteAsync();

        return NoContent();
    }

    [HttpDelete]
    [Route("{driverId:guid}")]
    public async Task<IActionResult> DeleteDriver(Guid driverId)
    {
        var driver = await _unitOfWork.Drivers.GetById(driverId);

        if (driver == null) return NotFound();

        await _unitOfWork.Drivers.Delete(driverId);
        await _unitOfWork.CompleteAsync();

        return NoContent();
    }

}