using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdvancedETS2Packer
{
    /// <summary>
    /// To this class, Exporter loads templates. It has all atributtes that template could have.
    /// </summary>
    class Template
    {
        /// <summary>
        /// Name of mod
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Group of which the mode is a member
        /// </summary>
        public string Group { get; set; }

        /// <summary>
        /// Name of zip file
        /// </summary>
        public string ZipName { get; set; }

        /// <summary>
        /// Path, where will app export Steam version of mod.
        /// </summary>
        public string SteamPath { get; set; }

        /// <summary>
        /// Path, where will app export non Steam version of mod.
        /// </summary>
        public string NonSteamPath { get; set; }

        /// <summary>
        /// In non Steam version, manifest must contain some strings... This is it, it copies itself to manifest.
        /// </summary>
        public string Include_in_manifest { get; set; }

        /// <summary>
        /// Where can Include_in_manifest add string?
        /// </summary>
        /// <remarks>Most of time, it is #, or other char.</remarks>
        public string Include_at { get; set; }

        public List<string> CopyPaths = new List<string>();

        public bool Error { get; set; }

        /// <summary>
        /// This method load all parameters of template from string.
        /// </summary>
        /// <param name="content">String with parameters of template.</param>
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
