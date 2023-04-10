using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvertJson
{
    internal class Valuation
    {
        public Valuation()
        {
            ReportFile = new ReportFile();
            Identification = new Identification();
        }

        public ReportFile ReportFile { get; set; }
        public Identification Identification { get; set; }

    }

	class ReportFile
	{
        public string Id { get; set; }
        public string ReportId { get; set; }
    }

	class Identification
	{
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
