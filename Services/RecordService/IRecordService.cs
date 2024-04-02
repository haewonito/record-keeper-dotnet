using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using record_keeper_dotnet.Dtos.Record;
using record_keeper_dotnet.Models;

namespace record_keeper_dotnet.Services.RecordService
{
    public interface IRecordService
    {
        Task<ServiceResponse<List<GetRecordResponseDto>>> GetAllRecords();
        Task<ServiceResponse<GetRecordResponseDto>> GetRecordById(int id);
        Task<ServiceResponse<List<AddRecordResponseDto>>> AddRecord(AddRecordRequestDto newRecord);
        Task<ServiceResponse<List<GetRecordResponseDto>>> UpdateRecord(UpdateRecordRequestDto newRecord);
        Task<ServiceResponse<List<GetRecordResponseDto>>> DeleteRecordById(int id);
    }
}