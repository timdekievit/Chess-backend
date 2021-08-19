using System;
using System.Collections.Generic;

namespace Domain
{
    public class Match
    {
        public Guid Id { get; set; }
        public string White { get; set; }
        public string Black { get; set; }
        public string Event { get; set; }
        public string Site { get; set; }
        public string Date { get; set; }
        public string Round { get; set; }
        public string Result { get; set; }
        public string[] Pgn { get; set; }
    }
}