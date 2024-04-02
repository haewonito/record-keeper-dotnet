using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using record_keeper_dotnet.Dtos.Record;

namespace record_keeper_dotnet
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Record, GetRecordResponseDto>();
            CreateMap<AddRecordRequestDto, Record>();
            CreateMap<Record, AddRecordResponseDto>();
            CreateMap<UpdateRecordRequestDto, Record>();
        }
    }
}

