using DevelopersApi.Entities_Models;
using System;
using System.Collections.Generic;
using System.Net;

namespace DevelopersApi.DTO {

    public class ResultDTO {

        public HttpStatusCode httpStatusCode { get; set; }

        public string message { get; set; }
        public int IdGame { get; set; }
        public string Name { get; set; }

        public ICollection<DeveloperDTO> Developers { get; set; }

        public ResultDTO() {

            Developers = new HashSet<DeveloperDTO>();
        }
    }
}