using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using CsvHelper.Configuration;

namespace HomeBanking.classes
{

    class ImporterINGB
    {
        public class csvRecord
        {
            public String Datum { get; set; }
            public String Omschrijving { get; set; }
            public String Rekening { get; set; }
            public String Tegenrekenening { get; set; }
            public String Code { get; set; }
            public String AfBij { get; set; }
            public String Bedrag { get; set; }
            public String MutatieSoort { get; set; }
            public String Mededelingen { get; set; }
        }

        public sealed class Mapper : CsvClassMap<csvRecord>
        {
            public Mapper()
            {
                Map(m => m.Datum ).Name("Datum");
                Map(m => m.Omschrijving).Name("Naam / Omschrijving");
                Map(m => m.Rekening).Name("Rekening");
                Map(m => m.Tegenrekenening).Name("Tegenrekening");
                Map(m => m.Code).Name("Code");
                Map(m => m.AfBij).Name("Af Bij");
                Map(m => m.Bedrag).Name("Bedrag (EUR)");
                Map(m => m.MutatieSoort).Name("MutatieSoort");
                Map(m => m.Mededelingen).Name("Mededelingen");
            }
        }


    }
}
