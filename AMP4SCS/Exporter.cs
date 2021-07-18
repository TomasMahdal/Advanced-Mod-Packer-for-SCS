using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;
using System.Reflection;
using System.Globalization;
using System.Resources;

namespace AdvancedETS2Packer
{
    class Exporter
    {
        public List<Template> Templates { get; set; }
        private ResourceManager LocRM;

        // init class and load templates
        public Exporter()
        {
            // load translations
            LocRM = new ResourceManager("AdvancedETS2Packer.Languages.Export", typeof(Exporter).Assembly);

            Templates = new List<Template>();
            DirectoryInfo d = new DirectoryInfo(Environment.CurrentDirectory + "\\templates\\");
            foreach (var file in d.GetFiles("*.txt"))
            {
                Template temp = new Template();
                temp.LoadFromString(File.ReadAllText(file.FullName, Encoding.UTF8));

                if (temp.Error == false) {
                    Templates.Add(temp);
                }
            }
        }

        public void ExportMod(string templateName, bool silentPackaging = false)
        {
            // clear folder
            if (Directory.Exists(Environment.CurrentDirectory + "\\_cache\\")) {
                Directory.Delete(Environment.CurrentDirectory + "\\_cache\\", true);
            }
            DirectoryInfo dir = Directory.CreateDirectory(Environment.CurrentDirectory + "\\_cache\\");
            dir.Attributes = FileAttributes.Hidden;
            Directory.CreateDirectory(Environment.CurrentDirectory + "\\_cache\\data\\");

            // select template from templates
            Template template = null;
            foreach (Template temp in Templates)
            {
                if (temp.Name == templateName)
                {
                    template = temp;
                }
            }

            // verify, if template exists
            if (template != null)
            {
                // copy all folders
                foreach(string directory in template.CopyPaths)
                {
                    if (Directory.Exists(directory)) {
                        DirectoryCopy(directory, Environment.CurrentDirectory + "\\_cache\\data\\", true); 

                    } else
                    {
                        MessageBox.Show(LocRM.GetString("Folder") + " " + directory + " " + LocRM.GetString("NotFound") + "!", LocRM.GetString("FolderInTemplateNotExists"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                
                // export of Steam version
                if (Directory.Exists(template.SteamPath)) {
                    // vygeneruje bat soubor s příkazy pro export
                    Assembly assembly = Assembly.GetExecutingAssembly();
                    StreamReader reader = new StreamReader(assembly.GetManifestResourceStream("AdvancedETS2Packer.templateExportBat.txt"));
                    string bat = reader.ReadToEnd();
                    bat = bat.Replace("%cache%", Environment.CurrentDirectory + "\\_cache\\data\\");
                    bat = bat.Replace("%7z%", Properties.Settings.Default.SevenZip_path);
                    bat = bat.Replace("%export%", template.SteamPath + "\\" + template.ZipName + "_s.zip");
                    bat = bat.Replace("%steam%", "");
                    bat = bat.Replace("%logpath%", Environment.CurrentDirectory + "\\log_Steam.txt");
                    File.WriteAllText(Environment.CurrentDirectory + "\\_cache\\pack.bat", bat);

                    ProcessStartInfo procStartInfo = new ProcessStartInfo(Environment.CurrentDirectory + "\\_cache\\pack.bat");
                    procStartInfo.CreateNoWindow = true;

                    var proccess = Process.Start(procStartInfo);
                    proccess.WaitForExit();
                }

                // export of non Steam version (include in manifest)
                if (Directory.Exists(template.NonSteamPath))
                {
                    // do include in manifest
                    if (File.Exists(Environment.CurrentDirectory + "\\_cache\\data\\manifest.sii"))
                    {
                        string content = File.ReadAllText(Environment.CurrentDirectory + "\\_cache\\data\\manifest.sii");
                        content = content.Replace(template.Include_at, template.Include_in_manifest);
                        File.WriteAllText(Environment.CurrentDirectory + "\\_cache\\data\\manifest.sii", content);
                    } else
                    {
                        MessageBox.Show(LocRM.GetString("ManifestNotFound"), LocRM.GetString("ErrorInPackingNonSteam"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    // vygeneruje bat soubor s příkazy pro export
                    Assembly assembly = Assembly.GetExecutingAssembly();
                    StreamReader reader = new StreamReader(assembly.GetManifestResourceStream("AdvancedETS2Packer.templateExportBat.txt"));
                    string bat = reader.ReadToEnd();
                    bat = bat.Replace("%cache%", Environment.CurrentDirectory + "\\_cache\\data\\");
                    bat = bat.Replace("%7z%", Properties.Settings.Default.SevenZip_path);
                    bat = bat.Replace("%export%", template.NonSteamPath + "\\" + template.ZipName + ".zip");
                    bat = bat.Replace("%steam%", "non ");
                    bat = bat.Replace("%logpath%", Environment.CurrentDirectory + "\\log_nonSteam.txt");
                    File.WriteAllText(Environment.CurrentDirectory + "\\_cache\\pack.bat", bat);

                    ProcessStartInfo procStartInfo = new ProcessStartInfo(Environment.CurrentDirectory + "\\_cache\\pack.bat");
                    procStartInfo.CreateNoWindow = true;

                    var proccess = Process.Start(procStartInfo);
                    proccess.WaitForExit();
                }

                if (silentPackaging == false) {
                    MessageBox.Show(string.Format(LocRM.GetString("PackingCompleted2"), template.Name), LocRM.GetString("PackingCompleted"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        public void ExportGroup(string groupName)
        {
            foreach(Template temp in Templates)
            {
                if (temp.Group == groupName)
                {
                    ExportMod(temp.Name, true);
                }
            }

            MessageBox.Show(string.Format(LocRM.GetString("PackingGroupCompleted2"), groupName), LocRM.GetString("PackingGroupCompleted"), MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private static void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
        {
            // Get the subdirectories for the specified directory.
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);

            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: "
                    + sourceDirName);
            }

            DirectoryInfo[] dirs = dir.GetDirectories();

            // If the destination directory doesn't exist, create it.       
            Directory.CreateDirectory(destDirName);

            // Get the files in the directory and copy them to the new location.
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                string tempPath = Path.Combine(destDirName, file.Name);
                file.CopyTo(tempPath, false);
            }

            // If copying subdirectories, copy them and their contents to new location.
            if (copySubDirs)
            {
                foreach (DirectoryInfo subdir in dirs)
                {
                    string tempPath = Path.Combine(destDirName, subdir.Name);
                    DirectoryCopy(subdir.FullName, tempPath, copySubDirs);
                }
            }
        }

        private static string RemoveDiacritics(string text)
        {
            var normalizedString = text.Normalize(NormalizationForm.FormD);
            var stringBuilder = new StringBuilder();

            foreach (var c in normalizedString)
            {
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
        }

    }
}
 