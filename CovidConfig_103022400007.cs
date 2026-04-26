using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace TP_Modul9_103022400007
{
    class CovidConfig_103022400007
    {
        public string satuan_suhu { get; set; }
        public int batas_hari_demam { get; set; }
        public string pesan_ditolak { get; set; }
        public string pesan_diterima { get; set; }

        public void ReadJSON()
        {
            string filePath = "covid_config.json";
            string configJsonData = File.ReadAllText(filePath);
            CovidConfig_103022400007 data = JsonSerializer.Deserialize<CovidConfig_103022400007>(configJsonData);

            this.satuan_suhu = data.satuan_suhu;
            this.batas_hari_demam = data.batas_hari_demam;
            this.pesan_ditolak = data.pesan_ditolak;
            this.pesan_diterima = data.pesan_diterima;
        }

        public void UbahSatuan()
        {
            if (satuan_suhu == "celcius")
            {
                satuan_suhu = "fahrenheit";
            }
            else if (satuan_suhu == "fahrenheit")
            {
                satuan_suhu = "celcius";
            }

            string filePath = "covid_config.json";
            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                WriteIndented = true
            };
            string jsonString = JsonSerializer.Serialize(this, options);
            File.WriteAllText(filePath, jsonString);
        }
    }
}
