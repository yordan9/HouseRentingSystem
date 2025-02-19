﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseRentingSystem.Core.Constants
{
    public static class MessageConstants
    {
        public const string RequiredMessage = "The {0} field is required";
        public const string LengthMessage = "The field {0} must be between {2} and {1} characters long";
        public const string PhoneExists = "Phone number alredy exists. Enter another one!";
        public const string HasRents = "You should have no rents to become an agent.";
        public const string CustomErrorMessage = "Something is wrong! You are alredy an agent.";
    }
}
