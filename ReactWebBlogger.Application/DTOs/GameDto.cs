﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactWebBlogger.Application.DTOs
{
    public class GameDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Url { get; set; }
        public string? ImageSource { get; set; }
    }
}