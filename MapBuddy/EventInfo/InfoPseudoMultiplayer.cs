﻿using SoulsFormats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MapBuddy.EventInfo
{
    internal class InfoPseudoMultiplayer
    {
        Logger logger = new Logger();

        string output_dir = "";
        string header = "";
        string combined_file_name = "Global_PseudoMultiplayer";
        string file_format = "csv";

        public InfoPseudoMultiplayer(string path, Dictionary<string, string> mapDict, bool splitByMap)
        {
            output_dir = Path.Combine(logger.GetLogDir(), "Event", "PsuedoMultiplayer");

            header = $"EventID;" +
                    $"PartName;" +
                    $"RegionName;" +
                    $"EntityID;" +
                    $"Unk14;" +
                    $"MapID;" +
                    $"UnkE0C;" +
                    $"UnkS04;" +
                    $"UnkS08;" +
                    $"UnkS0C;" +
                    $"Name;" +
                    $"HostEntityID;" +
                    $"EventFlagID;" +
                    $"ActivateGoodsID;" +
                    $"UnkT0C;" +
                    $"UnkT10;" +
                    $"UnkT14;" +
                    $"UnkT18;" +
                    $"UnkT1C;" +

                    $"\n";

            bool exists = Directory.Exists(output_dir);

            if (!exists)
            {
                Directory.CreateDirectory(output_dir);
            }

            // Combined: write header here
            if (!splitByMap)
            {
                header = $"MapID;" + header; // Add MapID column for combined file

                File.WriteAllText(output_dir + $"{combined_file_name}.{file_format}", header);
            }

            foreach (KeyValuePair<string, string> entry in mapDict)
            {
                string map_name = entry.Key.Replace(".msb", "");
                string map_path = entry.Value;

                string[] map_indexes = map_name.Replace("m", "").Split("_");

                MSBE msb = MSBE.Read(map_path);

                WriteCSV(msb, map_name, splitByMap);
            }

            logger.AddToLog($"Written PseudoMultiplayer data to {output_dir}");
            logger.WriteLog();
        }

        public void WriteCSV(MSBE msb, string map_name, bool outputByMap)
        {

            string text = "";

            // By Map: write header here
            if (outputByMap)
            {
                File.WriteAllText(output_dir + $"{map_name}.{file_format}", header);
            }

            foreach (MSBE.Event.PseudoMultiplayer entry in msb.Events.PseudoMultiplayers)
            {
                string line = "";

                // Combined: add MapID column
                if (!outputByMap)
                {
                    line = line +
                        $"{map_name};";
                }

                line = line +
                    $"{entry.EventID};" +
                    $"{entry.PartName};" +
                    $"{entry.RegionName};" +
                    $"{entry.EntityID};" +
                    $"{entry.Unk14};" +
                    $"{entry.MapID};" +
                    $"{entry.UnkE0C};" +
                    $"{entry.UnkS04};" +
                    $"{entry.UnkS08};" +
                    $"{entry.UnkS0C};" +
                    $"{entry.Name};" +
                    $"{entry.HostEntityID};" +
                    $"{entry.EventFlagID};" +
                    $"{entry.ActivateGoodsID};" +
                    $"{entry.UnkT0C};" +
                    $"{entry.UnkT10};" +
                    $"{entry.UnkT14};" +
                    $"{entry.UnkT18};" +
                    $"{entry.UnkT1C};" +

                    $"\n";

                text = text + line;
            }

            // By Map
            if (outputByMap)
            {
                File.AppendAllText(output_dir + $"{map_name}.{file_format}", text);
            }
            // Combined
            else
            {
                File.AppendAllText(output_dir + $"{combined_file_name}.{file_format}", text);
            }
        }
    }
}

