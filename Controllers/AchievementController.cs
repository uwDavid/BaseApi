using AutoMapper;
using FormulaOne.Dtos.Requests;
using FormulaOne.Dtos.Responses;
using FormulaOne.Models;
using FormulaOne.Repository.Interface;
using Microsoft.AspNetCore.Mvc;

namespace FormulaOne.Controllers;

public class AchievementController : BaseController
{
    public AchievementController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    { }

    [HttpGet]
    [Route("{driverId:guid}")]
    public async Task<IActionResult> GetDriverAchievements(Guid driverId)
    {
        var achievements = await _unitOfWork.Achievements.GetDriverAchievementAsync(driverId);
        if (achievements == null) return NotFound("Achievements not found.");

        var result = _mapper.Map<DriverAchievementResponse>(achievements);

        return Ok(result);
    }

    [HttpPost("")]
    public async Task<IActionResult> AddAchievement([FromBody] CreateDriverAchievementRequest achievement)
    {
        if (!ModelState.IsValid) return BadRequest();

        var result = _mapper.Map<Achievement>(achievement);

        await _unitOfWork.Achievements.Add(result);
        await _unitOfWork.CompleteAsync();

        return CreatedAtAction(nameof(GetDriverAchievements), new { driverId = result.DriverId }, result);
    }

    [HttpPut("")]
    public async Task<IActionResult> UpdateAchievement([FromBody] UpdateDriverAchievementRequest achievement)
    {
        if (!ModelState.IsValid) return BadRequest();

        var result = _mapper.Map<Achievement>(achievement);
        await _unitOfWork.Achievements.Update(result);
        await _unitOfWork.CompleteAsync();

        return NoContent();

    }

}