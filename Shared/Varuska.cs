using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorVaruska.Shared
{
    public class Varuska
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Description { get; set; }
        public City City{ get; set; }

        //public byte[] ImageData { get; set; }
    }
}
