﻿using SoulsFormats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MapBuddy.Info
{
    internal class InfoConnectCollision
    {
        Logger logger = new Logger();

        string output_dir = "";
        string header = "";
        string combined_file_name = "Global_ConnectCollision";
        string file_format = "csv";

        public InfoConnectCollision(string path, Dictionary<string, string> mapDict, bool splitByMap)
        {
            output_dir = Path.Combine(logger.GetLogDir(), "Part", "ConnectCollision");

            header = $"Name;" +
                    $"ModelName;" +
                    $"Unk08;" +
                    $"SibPath;" +
                    $"Position;" +
                    $"Rotation;" +
                    $"Scale;" +
                    $"Unk44;" +
                    $"MapStudioLayer;" +
                    $"EntityID;" +
                    $"UnkE04;" +
                    $"LodParamID;" +
                    $"UnkE09;" +
                    $"IsPointLightShadowSrc;" +
                    $"UnkE0B;" +
                    $"IsShadowSrc;" +
                    $"IsStaticShadowSrc;" +
                    $"IsCascade3ShadowSrc;" +
                    $"UnkE0F;" +
                    $"UnkE10;" +
                    $"IsShadowDest;" +
                    $"IsShadowOnly;" +
                    $"DrawByReflectCam;" +
                    $"DrawOnlyReflectCam;" +
                    $"EnableOnAboveShadow;" +
                    $"DisablePointLightEffect;" +
                    $"UnkE17;" +
                    $"UnkE18;" +
                    $"EntityGroupIDs[0];" +
                    $"EntityGroupIDs[1];" +
                    $"EntityGroupIDs[2];" +
                    $"EntityGroupIDs[3];" +
                    $"EntityGroupIDs[4];" +
                    $"EntityGroupIDs[5];" +
                    $"EntityGroupIDs[6];" +
                    $"EntityGroupIDs[7];" +
                    $"UnkE3C;" +
                    $"UnkE3E;" +

                    $"Unk1.DisplayGroups[0];" +
                    $"Unk1.DisplayGroups[1];" +
                    $"Unk1.DisplayGroups[2];" +
                    $"Unk1.DisplayGroups[3];" +
                    $"Unk1.DisplayGroups[4];" +
                    $"Unk1.DisplayGroups[5];" +
                    $"Unk1.DisplayGroups[6];" +
                    $"Unk1.DisplayGroups[7];" +
                    $"Unk1.DrawGroups[0];" +
                    $"Unk1.DrawGroups[1];" +
                    $"Unk1.DrawGroups[2];" +
                    $"Unk1.DrawGroups[3];" +
                    $"Unk1.DrawGroups[4];" +
                    $"Unk1.DrawGroups[5];" +
                    $"Unk1.DrawGroups[6];" +
                    $"Unk1.DrawGroups[7];" +
                    $"Unk1.CollisionMask[0];" +
                    $"Unk1.CollisionMask[1];" +
                    $"Unk1.CollisionMask[2];" +
                    $"Unk1.CollisionMask[3];" +
                    $"Unk1.CollisionMask[4];" +
                    $"Unk1.CollisionMask[5];" +
                    $"Unk1.CollisionMask[6];" +
                    $"Unk1.CollisionMask[7];" +
                    $"Unk1.CollisionMask[8];" +
                    $"Unk1.CollisionMask[9];" +
                    $"Unk1.CollisionMask[10];" +
                    $"Unk1.CollisionMask[11];" +
                    $"Unk1.CollisionMask[12];" +
                    $"Unk1.CollisionMask[13];" +
                    $"Unk1.CollisionMask[14];" +
                    $"Unk1.CollisionMask[15];" +
                    $"Unk1.CollisionMask[16];" +
                    $"Unk1.CollisionMask[17];" +
                    $"Unk1.CollisionMask[18];" +
                    $"Unk1.CollisionMask[19];" +
                    $"Unk1.CollisionMask[20];" +
                    $"Unk1.CollisionMask[21];" +
                    $"Unk1.CollisionMask[22];" +
                    $"Unk1.CollisionMask[23];" +
                    $"Unk1.CollisionMask[24];" +
                    $"Unk1.CollisionMask[25];" +
                    $"Unk1.CollisionMask[26];" +
                    $"Unk1.CollisionMask[27];" +
                    $"Unk1.CollisionMask[28];" +
                    $"Unk1.CollisionMask[29];" +
                    $"Unk1.CollisionMask[30];" +
                    $"Unk1.CollisionMask[31];" +
                    $"Unk1.Condition1;" +
                    $"Unk1.Condition2;" +
                    $"Unk1.UnkC2;" +
                    $"Unk1.UnkC3;" +
                    $"Unk1.UnkC4;" +
                    $"Unk1.UnkC6;" +

                    $"Unk2.Condition;" +
                    $"Unk2.DispGroups[0];" +
                    $"Unk2.DispGroups[1];" +
                    $"Unk2.DispGroups[2];" +
                    $"Unk2.DispGroups[3];" +
                    $"Unk2.DispGroups[4];" +
                    $"Unk2.DispGroups[5];" +
                    $"Unk2.DispGroups[6];" +
                    $"Unk2.DispGroups[7];" +
                    $"Unk2.Unk24;" +
                    $"Unk2.Unk26;" +

                    $"Unk8.Unk00;" +

                    $"Unk10.MapID;" +
                    $"Unk10.Unk04;" +
                    $"Unk10.Unk0C;" +
                    $"Unk10.Unk10;" +
                    $"Unk10.Unk14;" +

                    $"Unk11.Unk00;" +
                    $"Unk11.Unk04;" +

                    $"CollisionName;" +
                    $"MapID[0];" +
                    $"MapID[1];" +
                    $"MapID[2];" +
                    $"MapID[3];" +
                    $"UnkT08;" +
                    $"UnkT09;" +
                    $"UnkT0A;" +
                    $"UnkT0B;" +

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

            logger.AddToLog($"Written ConnectCollision data to {output_dir}");
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

            foreach (MSBE.Part.ConnectCollision entity in msb.Parts.ConnectCollisions)
            {
                string line = "";

                // Combined: add MapID column
                if (!outputByMap)
                {
                    line = line +
                        $"{map_name};";
                }

                line = line +
                    $"{entity.Name};" +
                    $"{entity.ModelName};" +
                    $"{entity.Unk08};" +
                    $"{entity.SibPath};" +
                    $"{entity.Position};" +
                    $"{entity.Rotation};" +
                    $"{entity.Scale};" +
                    $"{entity.Unk44};" +
                    $"{entity.MapStudioLayer};" +
                    $"{entity.EntityID};" +
                    $"{entity.UnkE04};" +
                    $"{entity.LodParamID};" +
                    $"{entity.UnkE09};" +
                    $"{entity.IsPointLightShadowSrc};" +
                    $"{entity.UnkE0B};" +
                    $"{entity.IsShadowSrc};" +
                    $"{entity.IsStaticShadowSrc};" +
                    $"{entity.IsCascade3ShadowSrc};" +
                    $"{entity.UnkE0F};" +
                    $"{entity.UnkE10};" +
                    $"{entity.IsShadowDest};" +
                    $"{entity.IsShadowOnly};" +
                    $"{entity.DrawByReflectCam};" +
                    $"{entity.DrawOnlyReflectCam};" +
                    $"{entity.EnableOnAboveShadow};" +
                    $"{entity.DisablePointLightEffect};" +
                    $"{entity.UnkE17};" +
                    $"{entity.UnkE18};" +
                    $"{entity.EntityGroupIDs[0]};" +
                    $"{entity.EntityGroupIDs[1]};" +
                    $"{entity.EntityGroupIDs[2]};" +
                    $"{entity.EntityGroupIDs[3]};" +
                    $"{entity.EntityGroupIDs[4]};" +
                    $"{entity.EntityGroupIDs[5]};" +
                    $"{entity.EntityGroupIDs[6]};" +
                    $"{entity.EntityGroupIDs[7]};" +
                    $"{entity.UnkE3C};" +
                    $"{entity.UnkE3E};" +

                    $"{entity.Unk1.DisplayGroups[0]};" +
                    $"{entity.Unk1.DisplayGroups[1]};" +
                    $"{entity.Unk1.DisplayGroups[2]};" +
                    $"{entity.Unk1.DisplayGroups[3]};" +
                    $"{entity.Unk1.DisplayGroups[4]};" +
                    $"{entity.Unk1.DisplayGroups[5]};" +
                    $"{entity.Unk1.DisplayGroups[6]};" +
                    $"{entity.Unk1.DisplayGroups[7]};" +
                    $"{entity.Unk1.DrawGroups[0]};" +
                    $"{entity.Unk1.DrawGroups[1]};" +
                    $"{entity.Unk1.DrawGroups[2]};" +
                    $"{entity.Unk1.DrawGroups[3]};" +
                    $"{entity.Unk1.DrawGroups[4]};" +
                    $"{entity.Unk1.DrawGroups[5]};" +
                    $"{entity.Unk1.DrawGroups[6]};" +
                    $"{entity.Unk1.DrawGroups[7]};" +
                    $"{entity.Unk1.CollisionMask[0]};" +
                    $"{entity.Unk1.CollisionMask[1]};" +
                    $"{entity.Unk1.CollisionMask[2]};" +
                    $"{entity.Unk1.CollisionMask[3]};" +
                    $"{entity.Unk1.CollisionMask[4]};" +
                    $"{entity.Unk1.CollisionMask[5]};" +
                    $"{entity.Unk1.CollisionMask[6]};" +
                    $"{entity.Unk1.CollisionMask[7]};" +
                    $"{entity.Unk1.CollisionMask[8]};" +
                    $"{entity.Unk1.CollisionMask[9]};" +
                    $"{entity.Unk1.CollisionMask[10]};" +
                    $"{entity.Unk1.CollisionMask[11]};" +
                    $"{entity.Unk1.CollisionMask[12]};" +
                    $"{entity.Unk1.CollisionMask[13]};" +
                    $"{entity.Unk1.CollisionMask[14]};" +
                    $"{entity.Unk1.CollisionMask[15]};" +
                    $"{entity.Unk1.CollisionMask[16]};" +
                    $"{entity.Unk1.CollisionMask[17]};" +
                    $"{entity.Unk1.CollisionMask[18]};" +
                    $"{entity.Unk1.CollisionMask[19]};" +
                    $"{entity.Unk1.CollisionMask[20]};" +
                    $"{entity.Unk1.CollisionMask[21]};" +
                    $"{entity.Unk1.CollisionMask[22]};" +
                    $"{entity.Unk1.CollisionMask[23]};" +
                    $"{entity.Unk1.CollisionMask[24]};" +
                    $"{entity.Unk1.CollisionMask[25]};" +
                    $"{entity.Unk1.CollisionMask[26]};" +
                    $"{entity.Unk1.CollisionMask[27]};" +
                    $"{entity.Unk1.CollisionMask[28]};" +
                    $"{entity.Unk1.CollisionMask[29]};" +
                    $"{entity.Unk1.CollisionMask[30]};" +
                    $"{entity.Unk1.CollisionMask[31]};" +
                    $"{entity.Unk1.Condition1};" +
                    $"{entity.Unk1.Condition2};" +
                    $"{entity.Unk1.UnkC2};" +
                    $"{entity.Unk1.UnkC3};" +
                    $"{entity.Unk1.UnkC4};" +
                    $"{entity.Unk1.UnkC6};" +

                    $"{entity.Unk2.Condition};" +
                    $"{entity.Unk2.DispGroups[0]};" +
                    $"{entity.Unk2.DispGroups[1]};" +
                    $"{entity.Unk2.DispGroups[2]};" +
                    $"{entity.Unk2.DispGroups[3]};" +
                    $"{entity.Unk2.DispGroups[4]};" +
                    $"{entity.Unk2.DispGroups[5]};" +
                    $"{entity.Unk2.DispGroups[6]};" +
                    $"{entity.Unk2.DispGroups[7]};" +
                    $"{entity.Unk2.Unk24};" +
                    $"{entity.Unk2.Unk26};" +

                    $"{entity.Unk8.Unk00};" +

                    $"{entity.Unk10.MapID};" +
                    $"{entity.Unk10.Unk04};" +
                    $"{entity.Unk10.Unk0C};" +
                    $"{entity.Unk10.Unk10};" +
                    $"{entity.Unk10.Unk14};" +

                    $"{entity.Unk11.Unk00};" +
                    $"{entity.Unk11.Unk04};" +

                    $"{entity.CollisionName};" +
                    $"{entity.MapID[0]};" +
                    $"{entity.MapID[1]};" +
                    $"{entity.MapID[2]};" +
                    $"{entity.MapID[3]};" +
                    $"{entity.UnkT08};" +
                    $"{entity.UnkT09};" +
                    $"{entity.UnkT0A};" +
                    $"{entity.UnkT0B};" +

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
