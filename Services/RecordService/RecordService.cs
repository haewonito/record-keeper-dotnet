using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using record_keeper_dotnet.Dtos.Record;
using record_keeper_dotnet.Models;


namespace record_keeper_dotnet.Services.RecordService
{
    public class RecordService : IRecordService
    {
        private static List<Record> records = new List<Record>(){
            new Record(),
            new Record { Id = 1, Title = "Sample Record"}
        };

        private readonly IMapper _mapper;
        public RecordService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<GetRecordResponseDto>>> GetAllRecords()
        {
            // var recordsDto = _mapper.Map<List<GetRecordResponseDto>>(records);

            var recordsDto = records.Select(r => _mapper.Map<GetRecordResponseDto>(r)).ToList();
            return new ServiceResponse<List<GetRecordResponseDto>> { Data = recordsDto };
        }

        public async Task<ServiceResponse<GetRecordResponseDto>> GetRecordById(int id)
        {
            var record = records.FirstOrDefault(x => x.Id == id);

            if (record is not null)
            {
                var recordDto = _mapper.Map<GetRecordResponseDto>(record);
                return new ServiceResponse<GetRecordResponseDto> { Data = recordDto };
            }
            throw new Exception($"Record Not Found with ID: @{id}");
        }

        public async Task<ServiceResponse<List<AddRecordResponseDto>>> AddRecord(AddRecordRequestDto newRecord)
        {
            var record = _mapper.Map<Record>(newRecord);
            record.Id = records.Max(x => x.Id) + 1;
            records.Add(record);
            var recordsResponseDtoList = records.Select(r => _mapper.Map<AddRecordResponseDto>(r)).ToList();

            return new ServiceResponse<List<AddRecordResponseDto>> { Data = recordsResponseDtoList };
        }
        //I am going to use put instead of patch here. In the front UI, I will have the previous fields for him to see so that the whole thing's passed in every time. 
        public async Task<ServiceResponse<List<GetRecordResponseDto>>> UpdateRecord(UpdateRecordRequestDto updatedRecord)
        {
            var response = new ServiceResponse<List<GetRecordResponseDto>>();
            var record = _mapper.Map<Record>(updatedRecord);

            var originalRecord = records.FirstOrDefault(x => x.Id == record.Id);

            if (originalRecord is null)
            {
                throw new Exception($"Record with id: [{updatedRecord.Id}] does not exist.");
            }

            try
            {
                _mapper.Map(updatedRecord, originalRecord);
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Success = false;
            }

            response.Data = records.Select(r => _mapper.Map<GetRecordResponseDto>(r)).ToList();

            return response;
        }

        public async Task<ServiceResponse<List<GetRecordResponseDto>>> DeleteRecordById(int id)
        {
            var response = new ServiceResponse<List<GetRecordResponseDto>>();

            var recordToDelete = records.FirstOrDefault(x => x.Id == id);

            if (recordToDelete is null)
            {
                throw new Exception($"Record with id: [{id}] does not exist.");
            }

            records.Remove(recordToDelete);

            response.Data = records.Select(r => _mapper.Map<GetRecordResponseDto>(r)).ToList();

            return response;

        }
    }
}