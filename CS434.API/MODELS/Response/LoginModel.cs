﻿using CS434.API.MODELS.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CS434.API.MODELS.Response
{
	public class LoginModel
	{
		public bool Result { get; set; }
        public string Message { get; set; }
		public Users User { get; set; }

	}
}
