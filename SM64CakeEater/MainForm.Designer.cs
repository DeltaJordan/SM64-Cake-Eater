using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace SM64CakeEater
{
    public partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = (IContainer) null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.rtbLog = new System.Windows.Forms.RichTextBox();
            this.pnlFilePickers = new System.Windows.Forms.Panel();
            this.tbImagePath = new System.Windows.Forms.TextBox();
            this.lblImage = new System.Windows.Forms.Label();
            this.btnImageBrowse = new System.Windows.Forms.Button();
            this.tbRomPath = new System.Windows.Forms.TextBox();
            this.lblRomFile = new System.Windows.Forms.Label();
            this.btnRomBrowse = new System.Windows.Forms.Button();
            this.pnlOther = new System.Windows.Forms.Panel();
            this.lblOther = new System.Windows.Forms.Label();
            this.btnRomInfo = new System.Windows.Forms.Button();
            this.pnlDebug = new System.Windows.Forms.Panel();
            this.lblDebug = new System.Windows.Forms.Label();
            this.pnlPreview = new System.Windows.Forms.Panel();
            this.pbPreview = new System.Windows.Forms.PictureBox();
            this.pnlExtendedOptions = new System.Windows.Forms.Panel();
            this.cbxRomType = new System.Windows.Forms.ComboBox();
            this.lblRomType = new System.Windows.Forms.Label();
            this.nudOffset = new System.Windows.Forms.NumericUpDown();
            this.lblOffset = new System.Windows.Forms.Label();
            this.btnPreview = new System.Windows.Forms.Button();
            this.pnlPatches = new System.Windows.Forms.Panel();
            this.btnApply = new System.Windows.Forms.Button();
            this.lblPatches = new System.Windows.Forms.Label();
            this.chkEndCakeStart = new System.Windows.Forms.CheckBox();
            this.btnImport = new System.Windows.Forms.Button();
            this.btnAbout = new System.Windows.Forms.Button();
            this.pnlFilePickers.SuspendLayout();
            this.pnlOther.SuspendLayout();
            this.pnlDebug.SuspendLayout();
            this.pnlPreview.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPreview)).BeginInit();
            this.pnlExtendedOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudOffset)).BeginInit();
            this.pnlPatches.SuspendLayout();
            this.SuspendLayout();
            // 
            // rtbLog
            // 
            this.rtbLog.Location = new System.Drawing.Point(6, 25);
            this.rtbLog.Name = "rtbLog";
            this.rtbLog.Size = new System.Drawing.Size(663, 94);
            this.rtbLog.TabIndex = 0;
            this.rtbLog.Text = "";
            // 
            // pnlFilePickers
            // 
            this.pnlFilePickers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFilePickers.Controls.Add(this.btnRomBrowse);
            this.pnlFilePickers.Controls.Add(this.btnImageBrowse);
            this.pnlFilePickers.Controls.Add(this.lblRomFile);
            this.pnlFilePickers.Controls.Add(this.lblImage);
            this.pnlFilePickers.Controls.Add(this.tbRomPath);
            this.pnlFilePickers.Controls.Add(this.tbImagePath);
            this.pnlFilePickers.Location = new System.Drawing.Point(12, 58);
            this.pnlFilePickers.Name = "pnlFilePickers";
            this.pnlFilePickers.Size = new System.Drawing.Size(135, 160);
            this.pnlFilePickers.TabIndex = 1;
            // 
            // tbImagePath
            // 
            this.tbImagePath.Location = new System.Drawing.Point(3, 26);
            this.tbImagePath.Name = "tbImagePath";
            this.tbImagePath.ReadOnly = true;
            this.tbImagePath.Size = new System.Drawing.Size(127, 20);
            this.tbImagePath.TabIndex = 2;
            // 
            // lblImage
            // 
            this.lblImage.Location = new System.Drawing.Point(3, 6);
            this.lblImage.Name = "lblImage";
            this.lblImage.Size = new System.Drawing.Size(127, 17);
            this.lblImage.TabIndex = 2;
            this.lblImage.Text = "Image";
            // 
            // btnImageBrowse
            // 
            this.btnImageBrowse.Location = new System.Drawing.Point(3, 52);
            this.btnImageBrowse.Name = "btnImageBrowse";
            this.btnImageBrowse.Size = new System.Drawing.Size(127, 23);
            this.btnImageBrowse.TabIndex = 2;
            this.btnImageBrowse.Text = "Browse";
            this.btnImageBrowse.UseVisualStyleBackColor = true;
            this.btnImageBrowse.Click += new System.EventHandler(this.btnImageBrowse_Click);
            // 
            // tbRomPath
            // 
            this.tbRomPath.Location = new System.Drawing.Point(3, 101);
            this.tbRomPath.Name = "tbRomPath";
            this.tbRomPath.ReadOnly = true;
            this.tbRomPath.Size = new System.Drawing.Size(127, 20);
            this.tbRomPath.TabIndex = 2;
            // 
            // lblRomFile
            // 
            this.lblRomFile.Location = new System.Drawing.Point(3, 81);
            this.lblRomFile.Name = "lblRomFile";
            this.lblRomFile.Size = new System.Drawing.Size(127, 13);
            this.lblRomFile.TabIndex = 2;
            this.lblRomFile.Text = "ROM File";
            // 
            // btnRomBrowse
            // 
            this.btnRomBrowse.Location = new System.Drawing.Point(3, 127);
            this.btnRomBrowse.Name = "btnRomBrowse";
            this.btnRomBrowse.Size = new System.Drawing.Size(127, 23);
            this.btnRomBrowse.TabIndex = 2;
            this.btnRomBrowse.Text = "Browse";
            this.btnRomBrowse.UseVisualStyleBackColor = true;
            this.btnRomBrowse.Click += new System.EventHandler(this.btnRomBrowse_Click);
            // 
            // pnlOther
            // 
            this.pnlOther.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlOther.Controls.Add(this.btnRomInfo);
            this.pnlOther.Controls.Add(this.lblOther);
            this.pnlOther.Location = new System.Drawing.Point(12, 224);
            this.pnlOther.Name = "pnlOther";
            this.pnlOther.Size = new System.Drawing.Size(135, 59);
            this.pnlOther.TabIndex = 2;
            // 
            // lblOther
            // 
            this.lblOther.Location = new System.Drawing.Point(3, 4);
            this.lblOther.Name = "lblOther";
            this.lblOther.Size = new System.Drawing.Size(127, 17);
            this.lblOther.TabIndex = 3;
            this.lblOther.Text = "Other";
            // 
            // btnRomInfo
            // 
            this.btnRomInfo.Location = new System.Drawing.Point(3, 24);
            this.btnRomInfo.Name = "btnRomInfo";
            this.btnRomInfo.Size = new System.Drawing.Size(127, 23);
            this.btnRomInfo.TabIndex = 3;
            this.btnRomInfo.Text = "ROM Info";
            this.btnRomInfo.UseVisualStyleBackColor = true;
            this.btnRomInfo.Click += new System.EventHandler(this.btnRomInfo_Click);
            // 
            // pnlDebug
            // 
            this.pnlDebug.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDebug.Controls.Add(this.lblDebug);
            this.pnlDebug.Controls.Add(this.rtbLog);
            this.pnlDebug.Location = new System.Drawing.Point(12, 344);
            this.pnlDebug.Name = "pnlDebug";
            this.pnlDebug.Size = new System.Drawing.Size(674, 124);
            this.pnlDebug.TabIndex = 3;
            // 
            // lblDebug
            // 
            this.lblDebug.AutoSize = true;
            this.lblDebug.Location = new System.Drawing.Point(4, 5);
            this.lblDebug.Name = "lblDebug";
            this.lblDebug.Size = new System.Drawing.Size(60, 13);
            this.lblDebug.TabIndex = 1;
            this.lblDebug.Text = "Debug Log";
            // 
            // pnlPreview
            // 
            this.pnlPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPreview.Controls.Add(this.pbPreview);
            this.pnlPreview.Location = new System.Drawing.Point(194, 58);
            this.pnlPreview.Name = "pnlPreview";
            this.pnlPreview.Size = new System.Drawing.Size(330, 251);
            this.pnlPreview.TabIndex = 4;
            // 
            // pbPreview
            // 
            this.pbPreview.Location = new System.Drawing.Point(3, 3);
            this.pbPreview.Name = "pbPreview";
            this.pbPreview.Size = new System.Drawing.Size(320, 240);
            this.pbPreview.TabIndex = 0;
            this.pbPreview.TabStop = false;
            // 
            // pnlExtendedOptions
            // 
            this.pnlExtendedOptions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlExtendedOptions.Controls.Add(this.lblOffset);
            this.pnlExtendedOptions.Controls.Add(this.nudOffset);
            this.pnlExtendedOptions.Controls.Add(this.lblRomType);
            this.pnlExtendedOptions.Controls.Add(this.cbxRomType);
            this.pnlExtendedOptions.Location = new System.Drawing.Point(12, 12);
            this.pnlExtendedOptions.Name = "pnlExtendedOptions";
            this.pnlExtendedOptions.Size = new System.Drawing.Size(674, 30);
            this.pnlExtendedOptions.TabIndex = 5;
            // 
            // cbxRomType
            // 
            this.cbxRomType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxRomType.FormattingEnabled = true;
            this.cbxRomType.Items.AddRange(new object[] {
            "SM64 Editor by Skelux",
            "ROM Manager by Pilzinsel64",
            "Custom Offset..."});
            this.cbxRomType.Location = new System.Drawing.Point(242, 3);
            this.cbxRomType.Name = "cbxRomType";
            this.cbxRomType.Size = new System.Drawing.Size(153, 21);
            this.cbxRomType.TabIndex = 0;
            this.cbxRomType.SelectedIndexChanged += new System.EventHandler(this.cbxRomType_SelectedIndexChanged);
            // 
            // lblRomType
            // 
            this.lblRomType.AutoSize = true;
            this.lblRomType.Location = new System.Drawing.Point(4, 6);
            this.lblRomType.Name = "lblRomType";
            this.lblRomType.Size = new System.Drawing.Size(231, 13);
            this.lblRomType.TabIndex = 1;
            this.lblRomType.Text = "Select the ROM Editing program you are using: ";
            // 
            // nudOffset
            // 
            this.nudOffset.Hexadecimal = true;
            this.nudOffset.Location = new System.Drawing.Point(486, 4);
            this.nudOffset.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.nudOffset.Name = "nudOffset";
            this.nudOffset.Size = new System.Drawing.Size(183, 20);
            this.nudOffset.TabIndex = 2;
            this.nudOffset.Visible = false;
            // 
            // lblOffset
            // 
            this.lblOffset.AutoSize = true;
            this.lblOffset.Location = new System.Drawing.Point(401, 6);
            this.lblOffset.Name = "lblOffset";
            this.lblOffset.Size = new System.Drawing.Size(79, 13);
            this.lblOffset.TabIndex = 3;
            this.lblOffset.Text = "Custom Offset: ";
            this.lblOffset.Visible = false;
            // 
            // btnPreview
            // 
            this.btnPreview.Location = new System.Drawing.Point(194, 315);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(330, 23);
            this.btnPreview.TabIndex = 6;
            this.btnPreview.Text = "Preview Current End Screen";
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // pnlPatches
            // 
            this.pnlPatches.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPatches.Controls.Add(this.chkEndCakeStart);
            this.pnlPatches.Controls.Add(this.btnApply);
            this.pnlPatches.Controls.Add(this.lblPatches);
            this.pnlPatches.Location = new System.Drawing.Point(530, 58);
            this.pnlPatches.Name = "pnlPatches";
            this.pnlPatches.Size = new System.Drawing.Size(156, 76);
            this.pnlPatches.TabIndex = 1;
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(3, 48);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(148, 23);
            this.btnApply.TabIndex = 2;
            this.btnApply.Text = "Apply to ROM";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // lblPatches
            // 
            this.lblPatches.Location = new System.Drawing.Point(3, 3);
            this.lblPatches.Name = "lblPatches";
            this.lblPatches.Size = new System.Drawing.Size(148, 20);
            this.lblPatches.TabIndex = 2;
            this.lblPatches.Text = "Patches";
            // 
            // chkEndCakeStart
            // 
            this.chkEndCakeStart.AutoSize = true;
            this.chkEndCakeStart.Location = new System.Drawing.Point(6, 26);
            this.chkEndCakeStart.Name = "chkEndCakeStart";
            this.chkEndCakeStart.Size = new System.Drawing.Size(146, 17);
            this.chkEndCakeStart.TabIndex = 3;
            this.chkEndCakeStart.Text = "End screen on ROM start";
            this.chkEndCakeStart.UseVisualStyleBackColor = true;
            // 
            // btnImport
            // 
            this.btnImport.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImport.Location = new System.Drawing.Point(12, 289);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(135, 23);
            this.btnImport.TabIndex = 7;
            this.btnImport.Text = "Import";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnAbout
            // 
            this.btnAbout.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAbout.Location = new System.Drawing.Point(534, 140);
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(148, 23);
            this.btnAbout.TabIndex = 7;
            this.btnAbout.Text = "About";
            this.btnAbout.UseVisualStyleBackColor = true;
            this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(698, 481);
            this.Controls.Add(this.btnAbout);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.btnPreview);
            this.Controls.Add(this.pnlExtendedOptions);
            this.Controls.Add(this.pnlPreview);
            this.Controls.Add(this.pnlDebug);
            this.Controls.Add(this.pnlOther);
            this.Controls.Add(this.pnlPatches);
            this.Controls.Add(this.pnlFilePickers);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Super Mario 64 End Cake Eater";
            this.pnlFilePickers.ResumeLayout(false);
            this.pnlFilePickers.PerformLayout();
            this.pnlOther.ResumeLayout(false);
            this.pnlDebug.ResumeLayout(false);
            this.pnlDebug.PerformLayout();
            this.pnlPreview.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbPreview)).EndInit();
            this.pnlExtendedOptions.ResumeLayout(false);
            this.pnlExtendedOptions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudOffset)).EndInit();
            this.pnlPatches.ResumeLayout(false);
            this.pnlPatches.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private RichTextBox rtbLog;
        private Panel pnlFilePickers;
        private Button btnRomBrowse;
        private Button btnImageBrowse;
        private Label lblRomFile;
        private Label lblImage;
        private TextBox tbRomPath;
        private TextBox tbImagePath;
        private Panel pnlOther;
        private Button btnRomInfo;
        private Label lblOther;
        private Panel pnlDebug;
        private Label lblDebug;
        private Panel pnlPreview;
        private PictureBox pbPreview;
        private Panel pnlExtendedOptions;
        private Label lblOffset;
        private NumericUpDown nudOffset;
        private Label lblRomType;
        private ComboBox cbxRomType;
        private Button btnPreview;
        private Panel pnlPatches;
        private CheckBox chkEndCakeStart;
        private Button btnApply;
        private Label lblPatches;
        private Button btnImport;
        private Button btnAbout;
    }
}