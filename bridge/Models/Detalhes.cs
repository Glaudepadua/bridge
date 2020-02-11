using System;
using System.Collections.Generic;

namespace bridge.Models
{
    public class Detalhes
    {
        public string Language { get; set; }
        public int Open_issues_count { get; set; }
        public int Stargazers_count { get; set; }
        public DateTime Created_at { get; set; }

        public List<Repositorio> RepositoriosRelacionados { get; set; }
    }
}