using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebUI.DTOs.OpeningHourDto
{
    public class GetByIdOpeningHourDto 
    {
        public int OpeningHoursId { get; set; }
        public string WeekDay { get; set; }
        public string Hour { get; set; }
    }
}
