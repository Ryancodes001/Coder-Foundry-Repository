﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Coder_Foundry_Portfolio.Models.CodeFirst
{

        public class Comment 
        {
            public int Id { get; set; }
            public int PostId { get; set; }
            public string AuthorId { get; set; }
            [DataType(DataType.MultilineText)]
            public string Body { get; set; }
            public DateTimeOffset Created { get; set; }
            public DateTimeOffset? Updated { get; set; }
            public string UpdateReason { get; set; }
            public virtual ApplicationUser Author { get; set; }
            public virtual BlogPost Post { get; set; }
        }
 }