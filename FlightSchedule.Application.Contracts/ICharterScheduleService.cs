using System;
using System.Collections.Generic;
using System.Text;

namespace FlightSchedule.Application.Contracts
{
    public interface ICharterScheduleService
    {
        Guid Create(CreateCharterScheduleDto dto);
        CharterTemplateDto GetById(Guid id);
    }
}
