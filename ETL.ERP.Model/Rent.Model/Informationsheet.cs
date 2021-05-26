using System;
using System.Collections.Generic;
using System.Text;

namespace ETL.ERP.Model.Rent.Model
{
   public class Informationsheet
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public string Title { get; set; }
        public string Contont { get; set; }
        public int Views { get; set; }
        public DateTime Releasetime { get; set; }
        public int Nid { get; set; }
        public string State { get; set; }
    }
}
