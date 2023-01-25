using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ogrenci4.src.Models
{
  public  class ActiveSession
    {
        public ActiveSession()
        {
            TopicList = new List<SeciliKonu>();
        }

        public string Id { get; set; }

        public string Type { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int  CurrentSecond { get; set; }

        public int DurationMinutes { get; set; }

        public string Status { get; set; }  
        public List<SeciliKonu> TopicList { get; set; }
    }
}
