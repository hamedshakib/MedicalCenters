using MedicalCenters.Identity.Models;
using System.Text;

namespace MedicalCenters.Identity.Basics
{
    internal class PeaperBasic
    {
        private static readonly Peaper[] _peapers = {
            new  Peaper() { Type =1 , Data = Encoding.ASCII.GetBytes(@"
6exTEO0KvbBGyK8rWYadhaksnkau6209fjo+kgv/3o9uLlOeOzBUguBCfeodufev
XbS3RIv3oqW3h9RUNtMXzzu89orDpCdUgtMuuTd0LNQRb2uLzBcKJc6ypVRzroTS
PWeKKNsgPI6Q4Q2iH7RkoyYMb0MUUlbur4SeQMWctnvVQvGOJt6lCfhOOxW/PGGj
1ZkCggEAD+TaobCELxgPf4yqlG8+fFUoggXn/jtgg3v1OwoB6b") }
        };
        internal static byte[] GetPeaperData(int Type) => _peapers[Type].Data;
    }
}
