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
using System.Threading;

namespace AdvancedETS2Packer
{
    /// <summary>
    /// This class is responsible for loading and exporting templates
    /// </summary>
    class Exporter
    {
        public List<Template> Templates { get; set; }
        private ResourceManager LocRM;

        /// <summary>
        /// It loads translations for exporter and it loads templates from directory.
        /// </summary>
        // init class and load templates
        public Exporter()
        {
            // load translations
            LocRM = new ResourceManager("AdvancedETS2Packer.Languages.Export", typeof(Exporter).Assembly);

            Templates = new List<Template>();
            DirectoryInfo d = new DirectoryInfo(Environment.CurrentDirectory + "\\templates\\");
            if (d.Exists) {
                // if directory exists, load mods
                foreach (var file in d.GetFiles("*.txt"))
                {
                    // load template string from file
                    string content = "\r\n" + File.ReadAllText(file.FullName, Encoding.UTF8);

                    // verify, if it is template
                    if (content.Contains("\r\n[pack_thingamajig]")) { 
                        // split it to more templates, if are there more templates in file
                        List<string> templates = content.Split("\r\n[pack_thingamajig]").ToList();

                        // clean empty templates
                        for (int i = templates.Count - 1; i > -1; i--)
                        {
                            bool isEmpty = true;
                            var lines = templates[i].Split(Environment.NewLine);
                            foreach (string line in lines)
                            {
                                if (line.Length > 0)
                                {
                                    isEmpty = false;
                                }
                            }

                            if (isEmpty)
                            {
                                templates.RemoveAt(i);
                            }

                            if (!templates[i].Contains("\r\nname=\""))
                            {
                                templates.RemoveAt(i);
                            }
                        }

                        // load templates
                        foreach (string template in templates)
                        {
                            Template temp = new Template();
                            temp.LoadFromString(template);

                            if (temp.Error == false)
                            {
                                Templates.Add(temp);
                            }
                        }
                    }
                }
            } else
            {
                // if directory does not exists, create it
                d.Create();
            }
        }

        /// <summary>
        /// It pack mod and copy it to selected location (location in template)
        /// </summary>
        /// <param name="templateName">Name of template from which this method reads other informations, like path, name, ...</param>
        /// <param name="silentPackaging">If is silent packaging active, user does not see any success dialog boxes, it is used when user is packing whole group.</param>
        public void ExportMod(string templateName, bool silentPackaging = false)
        {
            // display information about packing
            PackingDialog pd = new PackingDialog();

            // if there is no path, then inform user, that tool will pack nothing
            MessageBox.Show(string.Format(LocRM.GetString("PackageWillBeEmpty"), templateName), LocRM.GetString("ProblemWithPackaging"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
            new Thread(() =>
            {
                // clear folder
                pd.UpdateStatus("dialog_Cleanup");

                if (Directory.Exists(Environment.CurrentDirectory + "\\_cache\\"))
                {
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
                    pd.UpdateStatus("dialog_Copyiing");
                    foreach (string directory in template.CopyPaths)
                    {
                        if (Directory.Exists(directory))
                        {
                            DirectoryCopy(directory, Environment.CurrentDirectory + "\\_cache\\data\\", true);

                        }
                        else
                        {
                            MessageBox.Show(LocRM.GetString("Folder") + " " + directory + " " + LocRM.GetString("NotFound") + "!", LocRM.GetString("FolderInTemplateNotExists"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    // export of Steam version
                    if (Directory.Exists(template.SteamPath))
                    {
                        // vygeneruje bat soubor s příkazy pro export
                        pd.UpdateStatus("dialog_PackagingSteam");
                        Assembly assembly = Assembly.GetExecutingAssembly();
                        StreamReader reader = new StreamReader(assembly.GetManifestResourceStream("AdvancedETS2Packer.templateExportBat.txt"));
                        string bat = reader.ReadToEnd();
                        bat = bat.Replace("%cache%", Environment.CurrentDirectory + "\\_cache\\data\\");
                        bat = bat.Replace("%7z%", Properties.Settings.Default.SevenZip_path);
                        bat = bat.Replace("%export%", template.SteamPath + "\\" + template.ZipName + "_s.zip");
                        bat = bat.Replace("%modname%", template.Name);
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
                        pd.UpdateStatus("dialog_PackagingNonSteam");
                        // do include in manifest
                        if (File.Exists(Environment.CurrentDirectory + "\\_cache\\data\\manifest.sii"))
                        {
                            string content = File.ReadAllText(Environment.CurrentDirectory + "\\_cache\\data\\manifest.sii");
                            content = content.Replace(template.Include_at, template.Include_in_manifest);
                            File.WriteAllText(Environment.CurrentDirectory + "\\_cache\\data\\manifest.sii", content);
                        }
                        else
                        {
                            MessageBox.Show(LocRM.GetString("ManifestNotFound"), LocRM.GetString("ErrorInPackingNonSteam"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }

                        // generate bat file with commands for export
                        Assembly assembly = Assembly.GetExecutingAssembly();
                        StreamReader reader = new StreamReader(assembly.GetManifestResourceStream("AdvancedETS2Packer.templateExportBat.txt"));
                        string bat = reader.ReadToEnd();
                        bat = bat.Replace("%cache%", Environment.CurrentDirectory + "\\_cache\\data\\");
                        bat = bat.Replace("%7z%", Properties.Settings.Default.SevenZip_path);
                        bat = bat.Replace("%export%", template.NonSteamPath + "\\" + template.ZipName + ".zip");
                        bat = bat.Replace("%modname%", template.Name);
                        bat = bat.Replace("%steam%", "non ");
                        bat = bat.Replace("%logpath%", Environment.CurrentDirectory + "\\log_nonSteam.txt");
                        File.WriteAllText(Environment.CurrentDirectory + "\\_cache\\pack.bat", bat);

                        ProcessStartInfo procStartInfo = new ProcessStartInfo(Environment.CurrentDirectory + "\\_cache\\pack.bat");
                        procStartInfo.CreateNoWindow = true;

                        var proccess = Process.Start(procStartInfo);
                        proccess.WaitForExit();
                    }

                    // show information about successfull packing
                    if (silentPackaging == false)
                    {
                        MessageBox.Show(string.Format(LocRM.GetString("PackingCompleted2"), template.Name), LocRM.GetString("PackingCompleted"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    // close "Packing..." dialog
                    if (pd.Visible) {
                        pd.Invoke((MethodInvoker)delegate
                        {
                            pd.Close();
                        });
                    }
                }
            }).Start();

            // display dialog about that app is working
            pd.ShowDialog();
        }

        /// <summary>
        /// Pack group of mods
        /// </summary>
        /// <param name="groupName">Name of group, which will be packet.</param>
        /// <remarks>
        /// It selects ale templates with selected groupName and individually export (pack) them.
        /// </remarks>
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

        /// <summary>
        /// This function is used to copy whole directory with it content
        /// </summary>
        /// <param name="sourceDirName">Path to source directory to copy.</param>
        /// <param name="destDirName">Path, where will be source directory copied.</param>
        /// <param name="copySubDirs">Do you want copy recursively?</param>
        // https://docs.microsoft.com/cs-cz/dotnet/standard/io/how-to-copy-directories
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

        /// <summary>
        /// This method delete logs, it they exists
        /// </summary>
        /// <remarks>It is used when packing of new mod start. So that 7zip write log to empty file.</remarks>
        public void ClearLogs()
        {
            // remove Steam logs
            if (File.Exists(Environment.CurrentDirectory + "\\log_Steam.txt"))
            {
                File.Delete(Environment.CurrentDirectory + "\\log_Steam.txt");
            }

            // remove non Steam logs
            if (File.Exists(Environment.CurrentDirectory + "\\log_nonSteam.txt"))
            {
                File.Delete(Environment.CurrentDirectory + "\\log_nonSteam.txt");
            }
        }
    }
}
 