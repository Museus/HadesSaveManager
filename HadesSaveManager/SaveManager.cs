using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HadesSaveManager {
    public partial class SaveManager : Form {
        private int profileNum;
        private string saveFolder, routeFolder;
        private readonly Dictionary<string, string> fileMap;
        private bool confirmLoad;

        /// <summary>
        /// Initialize the SaveManager state.
        /// </summary>
        public SaveManager() {
            profileNum = 1;
            saveFolder = "";
            routeFolder = "";
            confirmLoad = true;

            fileMap = new Dictionary<string, string> {
                ["profile"] = "Profile{0}.sav",
                ["run"] = "Profile{0}_Temp.sav",
                ["settings"] = "Profile{0}.sjson",
                ["controls"] = "Profile{0}.ctrls",
                ["v"] = "Profile{0}.v.sav",
            };

            InitializeComponent();

            LoadState();

            if (saveFolder != "" && saveFolder != null)
                lblSaveFolderPath.Text = saveFolder;

            if (routeFolder != "" && saveFolder != null)
                lblRouteFolderPath.Text = routeFolder;

            switch (profileNum) {
                case 1:
                    radioProfile1.Checked = true;
                    break;
                case 2:
                    radioProfile2.Checked = true;
                    break;
                case 3:
                    radioProfile3.Checked = true;
                    break;
                case 4:
                    radioProfile4.Checked = true;
                    break;
                default:
                    profileNum = 1;
                    radioProfile1.Checked = true;
                    break;
            }
        }

        /// <summary>
        /// LinkChangePath_LinkClicked calls ChangeSelectedFolder on the
        /// correct global string and label based on the clicked link.
        /// </summary>
        /// <param name="sender">The clicked (Change) link object</param>
        /// <param name="e">Args passed by the LinkClicked event</param>
        private void LinkChangePath_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            if (sender.Equals(linkChangeSavePath)) {
                ChangeSelectedFolder(ref saveFolder, lblSaveFolderPath);
            } else if (sender.Equals(linkChangeRoutePath)) {
                ChangeSelectedFolder(ref routeFolder, lblRouteFolderPath);
            }
        }

        /// <summary>
        /// LinkOpenFolder_LinkClicked calls OpenSelectedFolder on the correct
        /// folder based on the clicked link.
        /// </summary>
        /// <param name="sender">The clicked (Open) link object</param>
        /// <param name="e">Args passed by the LinkClicked event</param>
        private void LinkOpenFolder_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            string targetFolder;
            if (sender.Equals(linkOpenSaveFolder)) {
                targetFolder = saveFolder;
            } else if (sender.Equals(linkOpenRouteFolder)) {
                targetFolder = routeFolder;
            } else {
                return;
            }

            OpenSelectedFolder(targetFolder);
        }

        /// <summary>
        /// BtnCreateSnapshot_Click creates a snapshot from the currently
        /// selected save folder and profile.
        /// </summary>
        /// <param name="sender">btnCreateSnapshot</param>
        /// <param name="e">EventArgs from the click event</param>
        private void BtnCreateSnapshot_Click(object sender, EventArgs e) {
            string snapshotName = txtNewSnapshot.Text.Trim();
            if (snapshotName == "") {
                MessageBox.Show("Please enter a name for the snapshot.", "Unnamed Snapshot", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            IEnumerable<char> invalidChars = from invalidChar in snapshotName.Intersect(Path.GetInvalidFileNameChars()) select invalidChar;
            if (invalidChars.Count() > 0) {
                MessageBox.Show(
                    String.Format("Snapshot name contains invalid characters: {0}", string.Join(" ", invalidChars)),
                    "Invalid Name",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }

            if (!FoldersInitialized()) return;

            Dictionary<string, string> paths = GetPaths(snapshotName);

            if (!File.Exists(paths["profile"])) {
                MessageBox.Show(
                    String.Format("Profile {0} does not exist.", profileNum),
                    "No Profile",
                    MessageBoxButtons.OK, MessageBoxIcon.Error
                );
                return;
            }

            if (File.Exists(paths["routeProfile"]) && !FileCompare(paths["profile"], paths["routeProfile"])) {
                DialogResult overwriteSeed = MessageBox.Show(
                    String.Format("A different seed already exists for this route. Would you like to overwrite this route?"),
                    "Overwrite Seed?",
                    MessageBoxButtons.YesNo
                );

                if (overwriteSeed != DialogResult.Yes) return;
            }

            if (File.Exists(paths["snapshot"])) {
                // If the snapshot is the same, don't bother replacing it.
                if (FileCompare(paths["snapshot"], paths["run"])) return;

                DialogResult overwriteSnapshot = MessageBox.Show(
                    String.Format("A snapshot named {0} already exists. Would you like to overwrite this snapshot?", snapshotName),
                    "Overwrite Snapshot?",
                    MessageBoxButtons.YesNo
                );

                if (overwriteSnapshot != DialogResult.Yes) return;
            }

            File.Copy(paths["profile"], paths["routeProfile"], true);
            File.Copy(paths["run"], paths["snapshot"], true);

            if (!File.Exists(paths["routeSettings"])) {
                File.Copy(paths["settings"], paths["routeSettings"], true);
            }

            ReloadSnapshots();
        }

        /// <summary>
        /// BtnLoadSnapshot_Click loads the selected snapshot from
        /// the route folder to the save folder, prompting the user
        /// if this will overwrite the selected profile.
        /// </summary>
        /// <param name="sender">btnLoadSnapshot</param>
        /// <param name="e">EventArgs from the click event</param>
        private void BtnLoadSnapshot_Click(object sender, EventArgs e) {
            string snapshotName = cboxLoadSnapshot.Text.Trim();
            if (snapshotName == "") {
                MessageBox.Show("Please choose a snapshot to load.", "No Snapshot Chosen", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!FoldersInitialized())
                return;

            Dictionary<string, string> paths = GetPaths(snapshotName);

            if (File.Exists(paths["routeProfile"])) {
                if (confirmLoad && (File.Exists(paths["profile"]) || File.Exists(paths["run"]))) {
                    DialogResult overwriteRun = MessageBox.Show(
                       String.Format("This will overwrite profile {0}. Are you sure you want to do this?", profileNum),
                       "Overwrite Run?",
                       MessageBoxButtons.YesNo
                    );

                    if (overwriteRun != DialogResult.Yes) return;

                    // Once they've confirmed once for this profile, don't ask again
                    confirmLoad = false;
                }

                File.Delete(paths["runBackup"]);
                File.Delete(paths["settingsBackup"]);
                File.Delete(paths["profile"]);
                File.Delete(paths["run"]);

                MakeValidCheckpoint();

                File.Copy(paths["routeProfile"], paths["profile"], true);
                File.Copy(paths["snapshot"], paths["run"], true);
            }
        }

        /// <summary>
        /// Load the Profile for the selected Route, but no run
        /// </summary>
        /// <param name="sender">Button that was clicked</param>
        /// <param name="e">EventArgs for the click</param>
        private void BtnLoadSeed_Click(object sender, EventArgs e) {

            string currentRunFile = String.Format(fileMap["run"], profileNum.ToString());
            string profileFile = String.Format(fileMap["profile"], profileNum.ToString());
            string settingsFile = String.Format(fileMap["settings"], profileNum.ToString());

            Dictionary<string, string> paths = new Dictionary<string, string> {
                ["run"] = Path.Combine(saveFolder, currentRunFile),
                ["profile"] = Path.Combine(saveFolder, profileFile),
                ["settings"] = Path.Combine(saveFolder, settingsFile),
                ["routeProfile"] = Path.Combine(routeFolder, @"Profile.sav"),
                ["routeSettings"] = Path.Combine(routeFolder, @"Profile.sjson"),
            };

            paths["runBackup"] = paths["run"] + ".bak";
            paths["settingsBackup"] = paths["settings"] + ".bak";

            if (!FoldersInitialized())
                return;

            if (File.Exists(paths["routeProfile"])) {
                if (confirmLoad && (File.Exists(paths["profile"]) || File.Exists(paths["run"]))) {
                    DialogResult overwriteRun = MessageBox.Show(
                       String.Format("This will overwrite profile {0}. Are you sure you want to do this?", profileNum),
                       "Overwrite Run?",
                       MessageBoxButtons.YesNo
                    );

                    if (overwriteRun != DialogResult.Yes) return;

                    // Once they've confirmed once for this profile, don't ask again
                    confirmLoad = false;
                }

                File.Delete(paths["runBackup"]);
                File.Delete(paths["settingsBackup"]);
                File.Delete(paths["profile"]);
                File.Delete(paths["run"]);

                MakeValidCheckpoint();

                File.Copy(paths["routeProfile"], paths["profile"], true);
            }
        }

        /// <summary>
        /// BtnDeleteSnapshot_Click deletes the selected snapshot from
        /// the route folder after prompting the user to confirm.
        /// </summary>
        /// <param name="sender">btnDeleteSnapshot</param>
        /// <param name="e">EventArgs from the click event</param>
        private void BtnDeleteSnapshot_Click(object sender, EventArgs e) {
            string snapshotName = cboxLoadSnapshot.Text.Trim();
            if (snapshotName == "") {
                MessageBox.Show("Please choose a snapshot to delete.", "No Snapshot Chosen", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!FoldersInitialized())
                return;

            string snapshotPath = Path.Combine(routeFolder, snapshotName + ".hsm");
            if (File.Exists(snapshotPath)) {
                DialogResult deleteSnapshot = MessageBox.Show(
                    String.Format("YOU ARE DELETING {0}. Are you sure you want to do this?", snapshotName),
                    "Delete Snapshot?",
                    MessageBoxButtons.YesNo
                );

                if (deleteSnapshot != DialogResult.Yes) return;
            } else {
                MessageBox.Show("Chosen snapshot does not exist.", "Snapshot Does Not Exist", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            File.Delete(snapshotPath);
            cboxLoadSnapshot.Text = "";
            ReloadSnapshots();
        }

        /// <summary>
        /// CboxLoadSnapshot reloads the snapshot list when cboxLoadSnapshot
        /// is clicked.
        /// </summary>
        /// <param name="sender">cboxLoadSnapshot object</param>
        /// <param name="e">EventArgs from the click event</param>
        private void CboxLoadSnapshot_Click(object sender, EventArgs e) {
            ReloadSnapshots();
        }

        /// <summary>
        /// RadioProfile_CheckedChanges updates the profileNum variable based
        /// on which radio button was clicked.
        /// </summary>
        /// <param name="sender">RadioButton object that was clicked</param>
        /// <param name="e">EventArgs from the click event</param>
        private void RadioProfile_CheckedChanged(object sender, EventArgs e) {
            // Make sure they're prompted next time they load a snapshot
            confirmLoad = true;
            profileNum = int.Parse((sender as RadioButton).Tag.ToString());
            SaveState();
        }

        /// <summary>
        /// ReloadSnapshots checks the provided routeFolder for .hsm files and
        /// updates cboxLoadSnapshot with the list of snapshots.
        /// </summary>
        private void ReloadSnapshots() {
            if (routeFolder == "") return;

            cboxLoadSnapshot.Items.Clear();
            foreach (string routeFile in Directory.GetFiles(routeFolder)) {
                if (Path.GetExtension(routeFile) == ".hsm") {
                    cboxLoadSnapshot.Items.Add(Path.GetFileNameWithoutExtension(routeFile));
                }
            }
        }

        /// <summary>
        /// FoldersInitialized checks the global paths to make sure they have been initialized
        /// </summary>
        /// <returns>true if both folders are initialized</returns>
        private bool FoldersInitialized() {
            if (saveFolder == "") {
                MessageBox.Show("Please select a save folder.", "Unknown Save Folder", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (routeFolder == "") {
                MessageBox.Show("Please select a route folder.", "Unknown Route Folder", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        /// <summary>
        /// GetPaths uses your selected profile to build the paths for all relevant save files
        /// </summary>
        /// <returns>Dictionary of strings containing all paths</returns>
        private Dictionary<string, string> GetPaths(string snapshotName) {
            string currentRunFile = String.Format(fileMap["run"], profileNum.ToString());
            string profileFile = String.Format(fileMap["profile"], profileNum.ToString());
            string settingsFile = String.Format(fileMap["settings"], profileNum.ToString());

            Dictionary<string, string> paths = new Dictionary<string, string> {
                ["snapshot"] = Path.Combine(routeFolder, snapshotName + ".hsm"),
                ["run"] = Path.Combine(saveFolder, currentRunFile),
                ["profile"] = Path.Combine(saveFolder, profileFile),
                ["settings"] = Path.Combine(saveFolder, settingsFile),
                ["routeProfile"] = Path.Combine(routeFolder, @"Profile.sav"),
                ["routeSettings"] = Path.Combine(routeFolder, @"Profile.sjson"),
            };

            paths["runBackup"] = paths["run"] + ".bak";
            paths["settingsBackup"] = paths["settings"] + ".bak";

            return paths;
        }

        /// <summary>
        /// Hades uses a flag in the Profile.sjson file to determine whether to load _Temp.
        /// MakeValidCheckpoint modifies the .sjson to enable _Temp loading. 
        /// </summary>
        /// <returns>true if successfully enabled _Temp loading</returns>
        private bool MakeValidCheckpoint() {
            string settingsFormatted = String.Format(fileMap["settings"], profileNum.ToString());
            string profileSettingsFile = Path.Combine(saveFolder, settingsFormatted);
            string routeSettingsFile = Path.Combine(routeFolder, @"Profile.sjson");

            if (!File.Exists(profileSettingsFile)) {
                if (!File.Exists(routeSettingsFile))
                    return false;

                File.Copy(routeSettingsFile, profileSettingsFile);
            }

            string tempFile = Path.GetTempFileName();

            using (var settingsReader = new StreamReader(profileSettingsFile))
            using (var tempWriter = new StreamWriter(tempFile)) {
                string line;

                while ((line = settingsReader.ReadLine()) != null) {
                    if (line.Trim() != "ValidCheckpoint = false")
                        tempWriter.WriteLine(line);
                }
            }

            File.Delete(profileSettingsFile);
            File.Move(tempFile, profileSettingsFile);
            return SetValidFlag();
        }

        /// <summary>
        /// SaveState writes the Save/Route paths and chosen profile to the settings.conf file.
        /// </summary>
        private void SaveState() {
            string stateFile = Path.Combine(Application.StartupPath, @"settings.conf");
            string tempFile = Path.GetTempFileName();

            Dictionary<string, string> stateSettings = new Dictionary<string, string> {
                ["saveFolder"] = saveFolder,
                ["routeFolder"] = routeFolder,
                ["profileNum"] = profileNum.ToString(),
            };

            using (var tempWriter = new StreamWriter(tempFile)) {
                foreach (KeyValuePair<string, string> entry in stateSettings) {
                    tempWriter.WriteLine(String.Format("{0}={1}", entry.Key, entry.Value));
                }
            }

            File.Delete(stateFile);
            File.Move(tempFile, stateFile);
        }

        /// <summary>
        /// LoadState reads the settings.conf file to load Save/Route paths, and chosen profile.
        /// </summary>
        private void LoadState() {
            string stateFile = Path.Combine(Application.StartupPath, @"settings.conf");
            Dictionary<string, string> stateSettings = new Dictionary<string, string>();

            if (File.Exists(stateFile)) {
                using StreamReader settingsReader = new StreamReader(stateFile);
                string line;
                while ((line = settingsReader.ReadLine()) != null) {
                    string[] setting = line.Split("=");
                    stateSettings[setting[0]] = setting[1];
                }
            }

            stateSettings.TryGetValue("saveFolder", out string tempSaveFolder);
            if (tempSaveFolder != null && tempSaveFolder != "" && Directory.Exists(tempSaveFolder))
                saveFolder = tempSaveFolder;

            stateSettings.TryGetValue("routeFolder", out string tempRouteFolder);
            if (tempRouteFolder != null && tempRouteFolder != "" && Directory.Exists(tempRouteFolder))
                routeFolder = tempRouteFolder;

            stateSettings.TryGetValue("profileNum", out string profileStr);
            if (profileStr != null)
                profileNum = int.Parse(profileStr);
        }

        /// <summary>
        /// ChangeSelectedFolder allows the user to select a folder using
        /// File Explorer, and updates the provided global variable and label.
        /// </summary>
        /// <param name="targetVar">global variable to update</param>
        /// <param name="targetLbl">label to update</param>
        private void ChangeSelectedFolder(ref string targetVar, Label targetLbl) {
            using FolderBrowserDialog folderDialog = new FolderBrowserDialog {
                SelectedPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments)
            };

            if (folderDialog.ShowDialog() == DialogResult.OK) {
                //Get the path of specified file
                targetVar = folderDialog.SelectedPath;
                targetLbl.Text = targetVar;
                SaveState();
            }
        }

        /// <summary>
        /// OpenSelectedFolder opens File Explorer on the provided path.
        /// </summary>
        /// <param name="folderPath">The path to open File Explorer on</param>
        private void OpenSelectedFolder(string folderPath) {
            if (!Directory.Exists(folderPath))
                return;

            ProcessStartInfo startInfo = new ProcessStartInfo {
                Arguments = folderPath,
                FileName = "explorer.exe",
            };

            Process.Start(startInfo);
        }

        /// <summary>
        /// FileCompare accepts two paths as strings, and returns 0 if the
        /// contents are the same.
        /// </summary>
        /// <param name="file1">Path for File 1 as a string</param>
        /// <param name="file2">Path for File 2 as a string</param>
        /// <returns>0 if File 1 and File 2 are the same.</returns>
        private bool FileCompare(string file1, string file2) {
            int file1byte, file2byte;

            // Determine if the same file was referenced two times.
            if (file1 == file2) return true;

            // Open the two files.
            using FileStream fs1 = new FileStream(file1, FileMode.Open);
            using FileStream fs2 = new FileStream(file2, FileMode.Open);

            // If the file sizes are not the same, the files are not the same.
            if (fs1.Length != fs2.Length) return false;

            // Read and compare a byte from each file until either a
            // non-matching set of bytes is found or until the end of
            // file1 is reached.
            do {
                // Read one byte from each file.
                file1byte = fs1.ReadByte();
                file2byte = fs2.ReadByte();
            }
            while ((file1byte == file2byte) && (file1byte != -1));

            // Return the success of the comparison. "file1byte" is
            // equal to "file2byte" at this point only if the files are
            // the same.
            return ((file1byte - file2byte) == 0);
        }

        /// <summary>
        /// Version 1.0 of Hades added a file that tracks the validity of a
        /// checkpoint. This means we have to modify that file when loading a
        /// snapshot, in order to tell the game to grab it.
        /// </summary>
        /// <returns>true if successfully set valid flag</returns>
        private bool SetValidFlag() {
            string validFormatted = String.Format(fileMap["v"], profileNum.ToString());
            string profileValidFile = Path.Combine(saveFolder, validFormatted);

            if (!File.Exists(profileValidFile)) {
                return true;
            }

            Byte[] byte_array;
            using (var validReader = new BinaryReader(File.Open(profileValidFile, FileMode.Open)))
                byte_array = validReader.ReadBytes(9);
                byte_array[8] = 1;

            string tempFile = Path.GetTempFileName();
            using (var validWriter = new BinaryWriter(File.Open(tempFile, FileMode.Create)))
                validWriter.Write(byte_array);

            File.Delete(profileValidFile);
            File.Move(tempFile, profileValidFile);
            return true;
        }
    }
}