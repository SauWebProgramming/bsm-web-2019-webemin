using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ogrenciyimProje.Models
{
    public class Sorular
    {
        public int ID { get; set; }
        public string Baslik { get; set; }
        public string Soru { get; set; }
        public byte[] Foto { get; set; }
    }
}
