using BackendLab2.Models;
using BackendLab2.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BackendLab2.Controllers;

[ApiController]
public class RecordController : ControllerBase
{
    private readonly RecordRepository _repository;

    public RecordController(RecordRepository recordRepository)
    {
        _repository = recordRepository;
    }
    [HttpGet("/record/{id:int}")]
    public async Task<ActionResult<Record>> GetRecord(int id)
    {
        try
        {
            var record = await _repository.GetRecord(id);
            return Ok(record);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpDelete("/record/{id:int}")]
    public async Task<ActionResult> DeleteRecord(int id)
    {
        try
        {
            await _repository.DeleteRecord(id);
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPost("/record")]
    public async Task<ActionResult> PostRecord([FromBody] Record record)
    {
        try
        {
            await _repository.CreateRecord(record);
            return Created();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    [HttpGet("record")]
    public async Task<ActionResult<List<Record>>> ListRecord([FromQuery] int? userId, [FromQuery] int? categoryId)
    {
        try
        {
            var records = await _repository.ListRecord(userId, categoryId);
            return Ok(records);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}