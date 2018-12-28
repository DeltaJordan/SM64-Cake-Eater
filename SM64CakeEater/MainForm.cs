using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using SM64CakeEater.Properties;

namespace SM64CakeEater
{
    public partial class MainForm : Form
    {
        private List<string> output = new List<string>();

        private string RomPath { get; set; }

        private string ImagePath { get; set; }

        private long Length { get; set; }

        public MainForm()
        {
            this.InitializeComponent();
        }

        public static Bitmap ResizeImage(Image image, int width, int height)
        {
            Rectangle destRect = new Rectangle(0, 0, width, height);
            Bitmap bitmap = new Bitmap(width, height);
            bitmap.SetResolution(image.HorizontalResolution, image.VerticalResolution);
            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                using (ImageAttributes imageAttr = new ImageAttributes())
                {
                    imageAttr.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, imageAttr);
                }
            }
            return bitmap;
        }

        private bool CheckIfJavaIsInstalled()
        {
            bool flag = false;
            Process process = new Process();
            try
            {
                process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                process.StartInfo.CreateNoWindow = true;
                process.StartInfo.FileName = "cmd.exe";
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.RedirectStandardError = true;
                process.StartInfo.Arguments = "/c \"java -version \"";
                process.OutputDataReceived += (s, e) =>
                {
                    if (e.Data == null)
                        return;
                    this.output.Add(e.Data);
                };
                process.ErrorDataReceived += (s, e) =>
                {
                    if (e.Data == null)
                        return;
                    this.output.Add(e.Data);
                };
                process.Start();
                process.BeginOutputReadLine();
                process.BeginErrorReadLine();
                process.WaitForExit();
                flag = process.ExitCode == 0;
            }
            catch (Exception exception)
            {
                this.rtbLog.AppendText($"Checking for java failed with exception:\n{exception}");
            }
            return flag;
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists("preview"))
            {
                Directory.CreateDirectory("preview");
                this.rtbLog.AppendText("Folder \"preview\" created.\n");
                this.rtbLog.ScrollToCaret();
            }

            if (this.RomPath == null)
            {
                MessageBox.Show("You must select a ROM!",
                    "Select A ROM", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int offset;

            switch (this.cbxRomType.SelectedIndex)
            {
                case 0:
                {
                    offset = 0x10BA69B;
                    break;
                }
                case 1:
                {
                    offset = 0x10BA810;
                    break;
                }
                case 2:
                {
                    offset = (int)this.nudOffset.Value;
                    break;
                }
                default:
                {
                    MessageBox.Show("You must select what type of ROM editor you extended your ROM with.",
                        "Select A ROM Type.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            Process process = new Process();
            ProcessStartInfo processStartInfo = new ProcessStartInfo
            {
                WindowStyle = ProcessWindowStyle.Hidden,
                FileName = "cmd.exe",
                Arguments = $"/C tools\\n64rawgfx -r \"{this.RomPath}\" -b preview/aa.bmp -m export -f RGBA -d 16 -a 0x{offset:X} -x 80 -y 20"
            };
            process.StartInfo = processStartInfo;
            process.Start();

            processStartInfo.Arguments = $"/C tools\\n64rawgfx -r \"{this.RomPath}\" -b preview/ba.bmp -m export -f RGBA -d 16 -a 0x{offset + 0xC80 * 1:X} -x 80 -y 20";
            process.StartInfo = processStartInfo;
            process.Start();

            processStartInfo.Arguments = $"/C tools\\n64rawgfx -r \"{this.RomPath}\" -b preview/ca.bmp -m export -f RGBA -d 16 -a 0x{offset + 0xC80 * 2:X} -x 80 -y 20";
            process.StartInfo = processStartInfo;
            process.Start();

            processStartInfo.Arguments = $"/C tools\\n64rawgfx -r \"{this.RomPath}\" -b preview/da.bmp -m export -f RGBA -d 16 -a 0x{offset + 0xC80 * 3:X} -x 80 -y 20";
            process.StartInfo = processStartInfo;
            process.Start();

            processStartInfo.Arguments = $"/C tools\\n64rawgfx -r \"{this.RomPath}\" -b preview/ab.bmp -m export -f RGBA -d 16 -a 0x{offset + 0xC80 * 4:X} -x 80 -y 20";
            process.StartInfo = processStartInfo;
            process.Start();

            processStartInfo.Arguments = $"/C tools\\n64rawgfx -r \"{this.RomPath}\" -b preview/bb.bmp -m export -f RGBA -d 16 -a 0x{offset + 0xC80 * 5:X} -x 80 -y 20";
            process.StartInfo = processStartInfo;
            process.Start();

            processStartInfo.Arguments = $"/C tools\\n64rawgfx -r \"{this.RomPath}\" -b preview/cb.bmp -m export -f RGBA -d 16 -a 0x{offset + 0xC80 * 6:X} -x 80 -y 20";
            process.StartInfo = processStartInfo;
            process.Start();

            processStartInfo.Arguments = $"/C tools\\n64rawgfx -r \"{this.RomPath}\" -b preview/db.bmp -m export -f RGBA -d 16 -a 0x{offset + 0xC80 * 7:X} -x 80 -y 20";
            process.StartInfo = processStartInfo;
            process.Start();

            processStartInfo.Arguments = $"/C tools\\n64rawgfx -r \"{this.RomPath}\" -b preview/ac.bmp -m export -f RGBA -d 16 -a 0x{offset + 0xC80 * 8:X} -x 80 -y 20";
            process.StartInfo = processStartInfo;
            process.Start();

            processStartInfo.Arguments = $"/C tools\\n64rawgfx -r \"{this.RomPath}\" -b preview/bc.bmp -m export -f RGBA -d 16 -a 0x{offset + 0xC80 * 9:X} -x 80 -y 20";
            process.StartInfo = processStartInfo;
            process.Start();

            processStartInfo.Arguments = $"/C tools\\n64rawgfx -r \"{this.RomPath}\" -b preview/cc.bmp -m export -f RGBA -d 16 -a 0x{offset + 0xC80 * 10:X} -x 80 -y 20";
            process.StartInfo = processStartInfo;
            process.Start();

            processStartInfo.Arguments = $"/C tools\\n64rawgfx -r \"{this.RomPath}\" -b preview/dc.bmp -m export -f RGBA -d 16 -a 0x{offset + 0xC80 * 11:X} -x 80 -y 20";
            process.StartInfo = processStartInfo;
            process.Start();

            processStartInfo.Arguments = $"/C tools\\n64rawgfx -r \"{this.RomPath}\" -b preview/ad.bmp -m export -f RGBA -d 16 -a 0x{offset + 0xC80 * 12:X} -x 80 -y 20";
            process.StartInfo = processStartInfo;
            process.Start();

            processStartInfo.Arguments = $"/C tools\\n64rawgfx -r \"{this.RomPath}\" -b preview/bd.bmp -m export -f RGBA -d 16 -a 0x{offset + 0xC80 * 13:X} -x 80 -y 20";
            process.StartInfo = processStartInfo;
            process.Start();

            processStartInfo.Arguments = $"/C tools\\n64rawgfx -r \"{this.RomPath}\" -b preview/cd.bmp -m export -f RGBA -d 16 -a 0x{offset + 0xC80 * 14:X} -x 80 -y 20";
            process.StartInfo = processStartInfo;
            process.Start();

            processStartInfo.Arguments = $"/C tools\\n64rawgfx -r \"{this.RomPath}\" -b preview/dd.bmp -m export -f RGBA -d 16 -a 0x{offset + 0xC80 * 15:X} -x 80 -y 20";
            process.StartInfo = processStartInfo;
            process.Start();

            processStartInfo.Arguments = $"/C tools\\n64rawgfx -r \"{this.RomPath}\" -b preview/ae.bmp -m export -f RGBA -d 16 -a 0x{offset + 0xC80 * 16:X} -x 80 -y 20";
            process.StartInfo = processStartInfo;
            process.Start();

            processStartInfo.Arguments = $"/C tools\\n64rawgfx -r \"{this.RomPath}\" -b preview/be.bmp -m export -f RGBA -d 16 -a 0x{offset + 0xC80 * 17:X} -x 80 -y 20";
            process.StartInfo = processStartInfo;
            process.Start();

            processStartInfo.Arguments = $"/C tools\\n64rawgfx -r \"{this.RomPath}\" -b preview/ce.bmp -m export -f RGBA -d 16 -a 0x{offset + 0xC80 * 18:X} -x 80 -y 20";
            process.StartInfo = processStartInfo;
            process.Start();

            processStartInfo.Arguments = $"/C tools\\n64rawgfx -r \"{this.RomPath}\" -b preview/de.bmp -m export -f RGBA -d 16 -a 0x{offset + 0xC80 * 19:X} -x 80 -y 20";
            process.StartInfo = processStartInfo;
            process.Start();

            processStartInfo.Arguments = $"/C tools\\n64rawgfx -r \"{this.RomPath}\" -b preview/af.bmp -m export -f RGBA -d 16 -a 0x{offset + 0xC80 * 20:X} -x 80 -y 20";
            process.StartInfo = processStartInfo;
            process.Start();

            processStartInfo.Arguments = $"/C tools\\n64rawgfx -r \"{this.RomPath}\" -b preview/bf.bmp -m export -f RGBA -d 16 -a 0x{offset + 0xC80 * 21:X} -x 80 -y 20";
            process.StartInfo = processStartInfo;
            process.Start();

            processStartInfo.Arguments = $"/C tools\\n64rawgfx -r \"{this.RomPath}\" -b preview/cf.bmp -m export -f RGBA -d 16 -a 0x{offset + 0xC80 * 22:X} -x 80 -y 20";
            process.StartInfo = processStartInfo;
            process.Start();

            processStartInfo.Arguments = $"/C tools\\n64rawgfx -r \"{this.RomPath}\" -b preview/df.bmp -m export -f RGBA -d 16 -a 0x{offset + 0xC80 * 23:X} -x 80 -y 20";
            process.StartInfo = processStartInfo;
            process.Start();
            processStartInfo.Arguments = $"/C tools\\n64rawgfx -r \"{this.RomPath}\" -b preview/ag.bmp -m export -f RGBA -d 16 -a 0x{offset + 0xC80 * 24:X} -x 80 -y 20";
            process.StartInfo = processStartInfo;
            process.Start();

            processStartInfo.Arguments = $"/C tools\\n64rawgfx -r \"{this.RomPath}\" -b preview/bg.bmp -m export -f RGBA -d 16 -a 0x{offset + 0xC80 * 25:X} -x 80 -y 20";
            process.StartInfo = processStartInfo;
            process.Start();

            processStartInfo.Arguments = $"/C tools\\n64rawgfx -r \"{this.RomPath}\" -b preview/cg.bmp -m export -f RGBA -d 16 -a 0x{offset + 0xC80 * 26:X} -x 80 -y 20";
            process.StartInfo = processStartInfo;
            process.Start();

            processStartInfo.Arguments = $"/C tools\\n64rawgfx -r \"{this.RomPath}\" -b preview/dg.bmp -m export -f RGBA -d 16 -a 0x{offset + 0xC80 * 27:X} -x 80 -y 20";
            process.StartInfo = processStartInfo;
            process.Start();

            processStartInfo.Arguments = $"/C tools\\n64rawgfx -r \"{this.RomPath}\" -b preview/ah.bmp -m export -f RGBA -d 16 -a 0x{offset + 0xC80 * 28:X} -x 80 -y 20";
            process.StartInfo = processStartInfo;
            process.Start();

            processStartInfo.Arguments = $"/C tools\\n64rawgfx -r \"{this.RomPath}\" -b preview/bh.bmp -m export -f RGBA -d 16 -a 0x{offset + 0xC80 * 29:X} -x 80 -y 20";
            process.StartInfo = processStartInfo;
            process.Start();

            processStartInfo.Arguments = $"/C tools\\n64rawgfx -r \"{this.RomPath}\" -b preview/ch.bmp -m export -f RGBA -d 16 -a 0x{offset + 0xC80 * 30:X} -x 80 -y 20";
            process.StartInfo = processStartInfo;
            process.Start();

            processStartInfo.Arguments = $"/C tools\\n64rawgfx -r \"{this.RomPath}\" -b preview/dh.bmp -m export -f RGBA -d 16 -a 0x{offset + 0xC80 * 31:X} -x 80 -y 20";
            process.StartInfo = processStartInfo;
            process.Start();

            processStartInfo.Arguments = $"/C tools\\n64rawgfx -r \"{this.RomPath}\" -b preview/ai.bmp -m export -f RGBA -d 16 -a 0x{offset + 0xC80 * 32:X} -x 80 -y 20";
            process.StartInfo = processStartInfo;
            process.Start();

            processStartInfo.Arguments = $"/C tools\\n64rawgfx -r \"{this.RomPath}\" -b preview/bi.bmp -m export -f RGBA -d 16 -a 0x{offset + 0xC80 * 33:X} -x 80 -y 20";
            process.StartInfo = processStartInfo;
            process.Start();

            processStartInfo.Arguments = $"/C tools\\n64rawgfx -r \"{this.RomPath}\" -b preview/ci.bmp -m export -f RGBA -d 16 -a 0x{offset + 0xC80 * 34:X} -x 80 -y 20";
            process.StartInfo = processStartInfo;
            process.Start();

            processStartInfo.Arguments = $"/C tools\\n64rawgfx -r \"{this.RomPath}\" -b preview/di.bmp -m export -f RGBA -d 16 -a 0x{offset + 0xC80 * 35:X} -x 80 -y 20";
            process.StartInfo = processStartInfo;
            process.Start();

            processStartInfo.Arguments = $"/C tools\\n64rawgfx -r \"{this.RomPath}\" -b preview/aj.bmp -m export -f RGBA -d 16 -a 0x{offset + 0xC80 * 36:X} -x 80 -y 20";
            process.StartInfo = processStartInfo;
            process.Start();

            processStartInfo.Arguments = $"/C tools\\n64rawgfx -r \"{this.RomPath}\" -b preview/bj.bmp -m export -f RGBA -d 16 -a 0x{offset + 0xC80 * 37:X} -x 80 -y 20";
            process.StartInfo = processStartInfo;
            process.Start();

            processStartInfo.Arguments = $"/C tools\\n64rawgfx -r \"{this.RomPath}\" -b preview/cj.bmp -m export -f RGBA -d 16 -a 0x{offset + 0xC80 * 38:X} -x 80 -y 20";
            process.StartInfo = processStartInfo;
            process.Start();

            processStartInfo.Arguments = $"/C tools\\n64rawgfx -r \"{this.RomPath}\" -b preview/dj.bmp -m export -f RGBA -d 16 -a 0x{offset + 0xC80 * 39:X} -x 80 -y 20";
            process.StartInfo = processStartInfo;
            process.Start();

            processStartInfo.Arguments = $"/C tools\\n64rawgfx -r \"{this.RomPath}\" -b preview/ak.bmp -m export -f RGBA -d 16 -a 0x{offset + 0xC80 * 40:X} -x 80 -y 20";
            process.StartInfo = processStartInfo;
            process.Start();

            processStartInfo.Arguments = $"/C tools\\n64rawgfx -r \"{this.RomPath}\" -b preview/bk.bmp -m export -f RGBA -d 16 -a 0x{offset + 0xC80 * 41:X} -x 80 -y 20";
            process.StartInfo = processStartInfo;
            process.Start();

            processStartInfo.Arguments = $"/C tools\\n64rawgfx -r \"{this.RomPath}\" -b preview/ck.bmp -m export -f RGBA -d 16 -a 0x{offset + 0xC80 * 42:X} -x 80 -y 20";
            process.StartInfo = processStartInfo;
            process.Start();

            processStartInfo.Arguments = $"/C tools\\n64rawgfx -r \"{this.RomPath}\" -b preview/dk.bmp -m export -f RGBA -d 16 -a 0x{offset + 0xC80 * 43:X} -x 80 -y 20";
            process.StartInfo = processStartInfo;
            process.Start();

            processStartInfo.Arguments = $"/C tools\\n64rawgfx -r \"{this.RomPath}\" -b preview/al.bmp -m export -f RGBA -d 16 -a 0x{offset + 0xC80 * 44:X} -x 80 -y 20";
            process.StartInfo = processStartInfo;
            process.Start();

            processStartInfo.Arguments = $"/C tools\\n64rawgfx -r \"{this.RomPath}\" -b preview/bl.bmp -m export -f RGBA -d 16 -a 0x{offset + 0xC80 * 45:X} -x 80 -y 20";
            process.StartInfo = processStartInfo;
            process.Start();

            processStartInfo.Arguments = $"/C tools\\n64rawgfx -r \"{this.RomPath}\" -b preview/cl.bmp -m export -f RGBA -d 16 -a 0x{offset + 0xC80 * 46:X} -x 80 -y 20";
            process.StartInfo = processStartInfo;
            process.Start();

            processStartInfo.Arguments = $"/C tools\\n64rawgfx -r \"{this.RomPath}\" -b preview/dl.bmp -m export -f RGBA -d 16 -a 0x{offset + 0xC80 * 47:X} -x 80 -y 20";
            process.StartInfo = processStartInfo;
            process.Start();

            this.rtbLog.AppendText("Exported 48 files.\n");
            this.rtbLog.ScrollToCaret();

            Application.DoEvents();
            Thread.Sleep(2000);

            Bitmap previewBmp = new Bitmap(320, 240);

            string[] indexedLetters = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l" };

            using (Graphics graphics = Graphics.FromImage(previewBmp))
            {
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 12; j++)
                    {
                        string file = Path.Combine(Application.StartupPath, "preview", $"{indexedLetters[i]}{indexedLetters[j]}.bmp");

                        using (Image currentImagePart = Image.FromFile(file))
                        {
                            graphics.DrawImage(currentImagePart, new Point(80 * i, 20 * j));
                        }

                        File.Delete(file);
                    }
                }
            }

            Image image = this.pbPreview.Image;
            image?.Dispose();
            this.pbPreview.Image = previewBmp;

            this.rtbLog.AppendText("Loaded 48 files.\n");
            this.rtbLog.ScrollToCaret();

            this.rtbLog.AppendText("Done!\n");
            this.rtbLog.ScrollToCaret();

            this.rtbLog.AppendText("PBs are now loading.\n");
            this.rtbLog.ScrollToCaret();
        }

        private void btnRomInfo_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Rom size: " + this.Length + " bytes.", "ROM Info", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            if (this.chkEndCakeStart.Checked)
            {
                this.rtbLog.AppendText("Loading files...\n");
                this.rtbLog.ScrollToCaret();

                new Process
                {
                    StartInfo = new ProcessStartInfo()
                    {
                        WindowStyle = ProcessWindowStyle.Hidden,
                        FileName = "cmd.exe",
                        Arguments = "/C tools\\ApplyPPF3 a \"" + this.RomPath + "\" tools\\patch.ppf"
                    }
                }.Start();

                this.rtbLog.AppendText("\"tools\\ApplyPPF3.exe\" started.\n");
                this.rtbLog.ScrollToCaret();

                Application.DoEvents();
                Thread.Sleep(1000);

                MessageBox.Show("Patch applied successfully!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.rtbLog.AppendText("Done.\n");
                this.rtbLog.ScrollToCaret();
            }
            else
            {
                MessageBox.Show("Nothing to patch!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show("By DeltaJordan." +
                            "\n" +
                            "\nCredits:" +
                            "\nOriginal tool/concept by RobiNERD." +
                            "\nKaze" +
                            "\n" +
                            "\nOther tools used:" +
                            "\nn64rawgfx" +
                            "\nnconvert", "About", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            if (!this.CheckIfJavaIsInstalled())
            {
                MessageBox.Show("Java is not installed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                this.rtbLog.AppendText("Failed importing.\n");
                this.rtbLog.ScrollToCaret();
            }
            else
            {
                if (this.ImagePath == null || this.RomPath == null)
                {
                    MessageBox.Show("You must select a ROM and an End Screen Image!",
                        "Select A ROM and/or Image.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                File.Copy(this.ImagePath, Directory.GetCurrentDirectory() + "/1.png");

                this.rtbLog.ScrollToCaret();
                this.rtbLog.AppendText("\"1.png\" loaded.\n");
                this.rtbLog.ScrollToCaret();

                Process process = new Process();
                ProcessStartInfo processStartInfo = new ProcessStartInfo
                {
                    WindowStyle = ProcessWindowStyle.Hidden,
                    FileName = "cmd.exe",
                    Arguments = "/C java -jar tools\\importer.jar"
                };
                process.StartInfo = processStartInfo;
                process.Start();

                this.rtbLog.AppendText("\"2.png\" generated.\n");
                this.rtbLog.ScrollToCaret();

                Application.DoEvents();

                while (!File.Exists("2.png") && !File.Exists("2.png"))
                {
                    Thread.Sleep(10);
                }

                File.Delete("1.png");

                this.rtbLog.AppendText("\"1.png\" deleted.\n");
                this.rtbLog.ScrollToCaret();

                processStartInfo.Arguments = "/C tools\\nconvert -out bmp 2.png";
                process.StartInfo = processStartInfo;
                process.Start();

                this.rtbLog.AppendText("\"2.png\" converted to BMP.\n");
                this.rtbLog.ScrollToCaret();

                Application.DoEvents();

                while (!File.Exists("2.bmp") && !File.Exists("2.bmp"))
                {
                    Thread.Sleep(10);
                }

                switch (this.cbxRomType.SelectedIndex)
                {
                    case 0:
                    {
                        processStartInfo.Arguments = $"/C tools\\n64rawgfx -r \"{this.RomPath}\" -b 2.bmp -m import -f RGBA -d 16 -a 0x10BA69B";
                        process.StartInfo = processStartInfo;
                        process.Start();
                        break;
                    }
                    case 1:
                    {
                        processStartInfo.Arguments = $"/C tools\\n64rawgfx -r \"{this.RomPath}\" -b 2.bmp -m import -f RGBA -d 16 -a 0x10BA810";
                        process.StartInfo = processStartInfo;
                        process.Start();
                        break;
                    }
                    case 2:
                    {
                        processStartInfo.Arguments = $"/C tools\\n64rawgfx -r \"{this.RomPath}\" -b 2.bmp -m import -f RGBA -d 16 -a 0x{(int)this.nudOffset.Value:X}";
                        process.StartInfo = processStartInfo;
                        process.Start();
                        break;
                    }
                    default:
                    {
                        MessageBox.Show("You must select what type of ROM editor you extended your ROM with.", 
                            "Select A ROM Type.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                Thread.Sleep(3000);

                this.rtbLog.AppendText("Imported successfully!\n");
                this.rtbLog.ScrollToCaret();

                File.Delete("2.bmp");
                this.rtbLog.AppendText("\"2.bmp\" deleted.\n");
                this.rtbLog.ScrollToCaret();

                File.Delete("2.png");
                this.rtbLog.AppendText("\"2.png\" deleted.\n");
                this.rtbLog.ScrollToCaret();

                this.rtbLog.AppendText("Done.\n");
                this.rtbLog.ScrollToCaret();
            }
        }

        private void btnRomBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog {Filter = "Z64 file (*.z64)|*.z64", FilterIndex = 1};

            if (openFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            this.RomPath = openFileDialog.FileName;
            this.tbRomPath.Text = this.RomPath;

            this.rtbLog.AppendText("ROM loaded.\n");
            this.rtbLog.ScrollToCaret();

            this.Length = new FileInfo(this.RomPath).Length;
            if (this.Length == 8388608L)
            {
                int num1 = (int)MessageBox.Show("Your rom will now be extended to 64MB", "Extending", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                this.rtbLog.AppendText("8MB ROM Detected.\n");
                this.rtbLog.ScrollToCaret();

                new Process
                {
                    StartInfo = new ProcessStartInfo()
                    {
                        WindowStyle = ProcessWindowStyle.Hidden,
                        FileName = "cmd.exe",
                        Arguments = $"/C tools\\sm64extend \"{this.RomPath}\" \"{this.RomPath}\""
                    }
                }.Start();

                this.rtbLog.AppendText("ROM Extended.\n");
                this.rtbLog.ScrollToCaret();

                Application.DoEvents();
                Thread.Sleep(2000);

                MessageBox.Show("ROM Successfully extended!", "Extending", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                this.cbxRomType.SelectedIndex = 0;
            }
        }

        private void btnImageBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "PNG file (*.png)|*.png";
            openFileDialog.FilterIndex = 1;
            if (openFileDialog.ShowDialog() != DialogResult.OK)
                return;
            Bitmap bitmap = new Bitmap(openFileDialog.FileName);
            int height = bitmap.Height;
            int width = bitmap.Width;
            this.ImagePath = openFileDialog.FileName;
            if (height != 240 && width != 320)
            {
                MessageBox.Show("The image you opened is not 320x240!\nIt will now be resized.", "Info.", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                ResizeImage(bitmap, 320, 240).Save("img.png", ImageFormat.Png);
                this.ImagePath = Directory.GetCurrentDirectory() + "/img.png";
                this.rtbLog.AppendText("Image resized.\n");
                this.rtbLog.ScrollToCaret();
            }
            this.tbImagePath.Text = this.ImagePath;
            this.rtbLog.AppendText("Image loaded.\n");
            this.rtbLog.ScrollToCaret();
        }

        private void cbxRomType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cbxRomType.SelectedIndex == 2)
            {
                this.nudOffset.Visible = this.lblOffset.Visible = true;
            }
            else
            {
                this.nudOffset.Visible = this.lblOffset.Visible = false;
            }
        }
    }
}
