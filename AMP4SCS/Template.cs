using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdvancedETS2Packer
{
    class Template
    {
        public string Name { get; set; }
        public string Group { get; set; }

        public string ZipName { get; set; }

        public string SteamPath { get; set; }
        public string NonSteamPath { get; set; }

        public string Include_in_manifest { get; set; }
        public string Include_at { get; set; }

        public List<string> CopyPaths = new List<string>();

        public bool Error { get; set; }

        // create object from string
        public void LoadFromString(string content)
        {
            var lines = content.Split(Environment.NewLine);

            // read properties of template
            int paths = 1;
            bool readManifest = false;
            foreach(string line in lines)
            {
                if (line.Contains("=") && readManifest == false) {
                    var variable = line.Substring(0, line.IndexOf('='));

                    if (variable == "name")
                    {
                        Name = line.Replace("name=", "");
                        Name = Name.Substring(1, Name.LastIndexOf("\"") - 1);
                    }

                    if (variable == "group")
                    {
                        Group = line.Replace("group=", "");
                        Group = Group.Substring(1, Group.LastIndexOf("\"") - 1);
                    }

                    if (variable == "steam_path")
                    {
                        SteamPath = line.Replace("steam_path=", "");
                        SteamPath = SteamPath.Substring(1, SteamPath.LastIndexOf("\"") - 1);
                    }

                    if (variable == "nosteam_path")
                    {
                        NonSteamPath = line.Replace("nosteam_path=", "");
                        NonSteamPath = NonSteamPath.Substring(1, NonSteamPath.LastIndexOf("\"") - 1);
                    }

                    if (variable == "include_in_manifest")
                    {
                        Include_in_manifest = line.Replace("include_in_manifest=", "");
                        Include_in_manifest = Include_in_manifest.Substring(1, Include_in_manifest.LastIndexOf("\"") - 1);
                    }

                    if (variable == "include_at")
                    {
                        Include_at = line.Replace("include_at=", "");
                        Include_at = Include_at.Substring(1, Include_at.LastIndexOf("\"") - 1);
                    }

                    if (variable == "zip_name")
                    {
                        ZipName = line.Replace("zip_name=", "");
                        ZipName = ZipName.Substring(1, ZipName.LastIndexOf("\"") - 1);
                    }

                    if (variable == "path" + paths)
                    {
                        string text = line.Replace("path" + paths + "=", "");
                        text = text.Substring(1, text.LastIndexOf("\"") - 1);
                        CopyPaths.Add(text);
                        paths += 1;
                    }
                }

                // read multiline texts
                if (line == "[end]")
                {
                    readManifest = false;
                }

                if (readManifest)
                {
                    Include_in_manifest += line + Environment.NewLine;
                }

                if (line == "[include_in_manifest]")
                {
                    readManifest = true;
                }
            }
        }
    }
}
