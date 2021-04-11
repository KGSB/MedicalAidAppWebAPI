﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalAidAppWebApi.AnonymousModels
{
    //anonymous in the sense that the database doesn't know about it. This is soley for use by the API.
    public class ConnectionRequestAnonymous
    {
        public string CaretakerName { get; set; }
        public string PatientName { get; set; }
    }
}
