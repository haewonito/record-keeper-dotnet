using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using record_keeper_dotnet.Dtos.Record;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace record_keeper_dotnet.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecordController : ControllerBase
    {
        private readonly IRecordService _recordService;
        public RecordController(IRecordService recordService)
        {
            _recordService = recordService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<GetRecordResponseDto>>>> Get()
        {
            return Ok(await _recordService.GetAllRecords());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetRecordResponseDto>>> GetSingle(int id)
        {
            return Ok(await _recordService.GetRecordById(id));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<AddRecordResponseDto>>>> AddRecord(AddRecordRequestDto newRecord)
        {
            return Ok(await _recordService.AddRecord(newRecord));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<AddRecordResponseDto>>>> UpdateRecord(UpdateRecordRequestDto updatedRecord)
        {
            var response = await _recordService.UpdateRecord(updatedRecord);

            if (response.Data == null)
            {
                return NotFound(response);
            }

            return Ok(await _recordService.UpdateRecord(updatedRecord));
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<List<GetRecordResponseDto>>>> DeleteRecordById(int id)

        {
            var response = await _recordService.DeleteRecordById(id);

            if (response.Data == null)
            {
                return NotFound(response);
            }

            return Ok(response);
        }

    }
}