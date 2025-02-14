using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HouseRentingSystem.Infrastructure.Constants.DataConstants;

namespace HouseRentingSystem.Core.Models.Agent
{
    internal class BecomeAgentFormModel
    {
        [Required]
        [MaxLength(PhoneNumberMaxLength),MinLength(PhoneNumberMinLength)]
        public string PhoneNumber { get; set; } = string.Empty;

    }
}
