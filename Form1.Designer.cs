﻿namespace Next_tile_editor
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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

        NextPaletteColourPicker NextPalette;

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Next_tile_editor.paletteValue9bit paletteValue9bit1 = new Next_tile_editor.paletteValue9bit();
            Next_tile_editor.paletteValue9bit paletteValue9bit2 = new Next_tile_editor.paletteValue9bit();
            this.NextPalette = new Next_tile_editor.NextPaletteColourPicker();
            this.btnImportFromPNG = new System.Windows.Forms.Button();
            this.btnImportFromNext = new System.Windows.Forms.Button();
            this.btnSaveAsPNG = new System.Windows.Forms.Button();
            this.btnSaveAsNextFormat = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnQuantizeImages = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panelParent = new System.Windows.Forms.Panel();
            this.pnlTileMap = new System.Windows.Forms.Panel();
            this.panelScrolly = new System.Windows.Forms.Panel();
            this.btnSavePalette = new System.Windows.Forms.Button();
            this.btnSaveTiles = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.tileEditor1 = new Next_tile_editor.TileEditor();
            this.btnSaveTileMap = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pnlPalettePicker = new System.Windows.Forms.Panel();
            this.pnlTilePalette = new System.Windows.Forms.Panel();
            this.btnLoadPalette = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnLoadTileMap = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panelParent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // NextPalette
            // 
            this.NextPalette.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            paletteValue9bit1.Blue = ((byte)(0));
            paletteValue9bit1.Green = ((byte)(0));
            paletteValue9bit1.Red = ((byte)(0));
            this.NextPalette.Ink9bit = paletteValue9bit1;
            this.NextPalette.InkIndex = 0;
            this.NextPalette.Location = new System.Drawing.Point(1595, 41);
            this.NextPalette.Name = "NextPalette";
            this.NextPalette.Palette = null;
            paletteValue9bit2.Blue = ((byte)(7));
            paletteValue9bit2.Green = ((byte)(7));
            paletteValue9bit2.Red = ((byte)(7));
            this.NextPalette.Paper9bit = paletteValue9bit2;
            this.NextPalette.PaperIndex = 0;
            this.NextPalette.ScaleVal = 0;
            this.NextPalette.Size = new System.Drawing.Size(128, 696);
            this.NextPalette.TabIndex = 12;
            // 
            // btnImportFromPNG
            // 
            this.btnImportFromPNG.Location = new System.Drawing.Point(3, 3);
            this.btnImportFromPNG.Name = "btnImportFromPNG";
            this.btnImportFromPNG.Size = new System.Drawing.Size(121, 29);
            this.btnImportFromPNG.TabIndex = 0;
            this.btnImportFromPNG.Text = "PNG Import";
            this.btnImportFromPNG.UseVisualStyleBackColor = true;
            this.btnImportFromPNG.Click += new System.EventHandler(this.btnImportFromPNG_Click);
            // 
            // btnImportFromNext
            // 
            this.btnImportFromNext.Location = new System.Drawing.Point(149, 3);
            this.btnImportFromNext.Name = "btnImportFromNext";
            this.btnImportFromNext.Size = new System.Drawing.Size(115, 29);
            this.btnImportFromNext.TabIndex = 1;
            this.btnImportFromNext.Text = "Next Import";
            this.btnImportFromNext.UseVisualStyleBackColor = true;
            this.btnImportFromNext.Click += new System.EventHandler(this.btnImportFromNext_Click);
            // 
            // btnSaveAsPNG
            // 
            this.btnSaveAsPNG.Location = new System.Drawing.Point(604, 3);
            this.btnSaveAsPNG.Name = "btnSaveAsPNG";
            this.btnSaveAsPNG.Size = new System.Drawing.Size(94, 29);
            this.btnSaveAsPNG.TabIndex = 2;
            this.btnSaveAsPNG.Text = "PNG Save";
            this.btnSaveAsPNG.UseVisualStyleBackColor = true;
            // 
            // btnSaveAsNextFormat
            // 
            this.btnSaveAsNextFormat.Location = new System.Drawing.Point(704, 3);
            this.btnSaveAsNextFormat.Name = "btnSaveAsNextFormat";
            this.btnSaveAsNextFormat.Size = new System.Drawing.Size(94, 29);
            this.btnSaveAsNextFormat.TabIndex = 3;
            this.btnSaveAsNextFormat.Text = "Next Save";
            this.btnSaveAsNextFormat.UseVisualStyleBackColor = true;
            this.btnSaveAsNextFormat.Click += new System.EventHandler(this.btnSaveAsNextFormat_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(324, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "label1";
            // 
            // btnQuantizeImages
            // 
            this.btnQuantizeImages.Location = new System.Drawing.Point(479, 9);
            this.btnQuantizeImages.Name = "btnQuantizeImages";
            this.btnQuantizeImages.Size = new System.Drawing.Size(94, 29);
            this.btnQuantizeImages.TabIndex = 6;
            this.btnQuantizeImages.Text = "Quantize";
            this.btnQuantizeImages.UseVisualStyleBackColor = true;
            this.btnQuantizeImages.Click += new System.EventHandler(this.btnQuantizeImages_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(-2, 41);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(2140, 776);
            this.tabControl1.TabIndex = 7;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(2132, 743);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 29);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(2132, 743);
            this.tabPage3.TabIndex = 2;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.panelParent);
            this.tabPage2.Controls.Add(this.btnSavePalette);
            this.tabPage2.Controls.Add(this.btnSaveTiles);
            this.tabPage2.Controls.Add(this.button2);
            this.tabPage2.Controls.Add(this.numericUpDown1);
            this.tabPage2.Controls.Add(this.tileEditor1);
            this.tabPage2.Controls.Add(this.NextPalette);
            this.tabPage2.Controls.Add(this.btnSaveTileMap);
            this.tabPage2.Controls.Add(this.panel3);
            this.tabPage2.Controls.Add(this.btnLoadPalette);
            this.tabPage2.Controls.Add(this.button1);
            this.tabPage2.Controls.Add(this.btnLoadTileMap);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(2132, 743);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // panelParent
            // 
            this.panelParent.Controls.Add(this.pnlTileMap);
            this.panelParent.Controls.Add(this.panelScrolly);
            this.panelParent.Location = new System.Drawing.Point(6, 41);
            this.panelParent.Name = "panelParent";
            this.panelParent.Size = new System.Drawing.Size(1280, 737);
            this.panelParent.TabIndex = 6;
            // 
            // pnlTileMap
            // 
            this.pnlTileMap.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlTileMap.AutoScroll = true;
            this.pnlTileMap.AutoSize = true;
            this.pnlTileMap.Location = new System.Drawing.Point(4, 10);
            this.pnlTileMap.Name = "pnlTileMap";
            this.pnlTileMap.Size = new System.Drawing.Size(1280, 696);
            this.pnlTileMap.TabIndex = 4;
            // 
            // panelScrolly
            // 
            this.panelScrolly.AutoScroll = true;
            this.panelScrolly.Location = new System.Drawing.Point(3, 47);
            this.panelScrolly.Name = "panelScrolly";
            this.panelScrolly.Size = new System.Drawing.Size(1280, 800);
            this.panelScrolly.TabIndex = 6;
            // 
            // btnSavePalette
            // 
            this.btnSavePalette.Location = new System.Drawing.Point(675, 6);
            this.btnSavePalette.Name = "btnSavePalette";
            this.btnSavePalette.Size = new System.Drawing.Size(115, 29);
            this.btnSavePalette.TabIndex = 19;
            this.btnSavePalette.Text = "Save Palette";
            this.btnSavePalette.UseVisualStyleBackColor = true;
            this.btnSavePalette.Click += new System.EventHandler(this.btnSavePalette_Click);
            // 
            // btnSaveTiles
            // 
            this.btnSaveTiles.Location = new System.Drawing.Point(549, 6);
            this.btnSaveTiles.Name = "btnSaveTiles";
            this.btnSaveTiles.Size = new System.Drawing.Size(115, 29);
            this.btnSaveTiles.TabIndex = 18;
            this.btnSaveTiles.Text = "Save Tiles";
            this.btnSaveTiles.UseVisualStyleBackColor = true;
            this.btnSaveTiles.Click += new System.EventHandler(this.btnSaveTiles_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1745, 429);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(91, 36);
            this.button2.TabIndex = 17;
            this.button2.Text = "SaveTile";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(1745, 367);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 27);
            this.numericUpDown1.TabIndex = 15;
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // tileEditor1
            // 
            this.tileEditor1.Ink = null;
            this.tileEditor1.InkVal = 0;
            this.tileEditor1.Location = new System.Drawing.Point(1745, 41);
            this.tileEditor1.Name = "tileEditor1";
            this.tileEditor1.palette = null;
            this.tileEditor1.PaletteOffset = 0;
            this.tileEditor1.Paper = null;
            this.tileEditor1.PaperVal = 0;
            this.tileEditor1.Size = new System.Drawing.Size(256, 320);
            this.tileEditor1.TabIndex = 13;
            this.tileEditor1.Tile = null;
            // 
            // btnSaveTileMap
            // 
            this.btnSaveTileMap.Location = new System.Drawing.Point(428, 6);
            this.btnSaveTileMap.Name = "btnSaveTileMap";
            this.btnSaveTileMap.Size = new System.Drawing.Size(115, 29);
            this.btnSaveTileMap.TabIndex = 11;
            this.btnSaveTileMap.Text = "SaveTileMap";
            this.btnSaveTileMap.UseVisualStyleBackColor = true;
            this.btnSaveTileMap.Click += new System.EventHandler(this.btnSaveTileMap_Click);
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Controls.Add(this.pnlPalettePicker);
            this.panel3.Controls.Add(this.pnlTilePalette);
            this.panel3.Location = new System.Drawing.Point(1305, 41);
            this.panel3.MaximumSize = new System.Drawing.Size(272, 696);
            this.panel3.MinimumSize = new System.Drawing.Size(272, 696);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(272, 696);
            this.panel3.TabIndex = 10;
            // 
            // pnlPalettePicker
            // 
            this.pnlPalettePicker.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlPalettePicker.BackColor = System.Drawing.Color.RosyBrown;
            this.pnlPalettePicker.Location = new System.Drawing.Point(143, 0);
            this.pnlPalettePicker.Name = "pnlPalettePicker";
            this.pnlPalettePicker.Size = new System.Drawing.Size(128, 696);
            this.pnlPalettePicker.TabIndex = 10;
            // 
            // pnlTilePalette
            // 
            this.pnlTilePalette.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlTilePalette.BackColor = System.Drawing.Color.LightGray;
            this.pnlTilePalette.Location = new System.Drawing.Point(0, 0);
            this.pnlTilePalette.Name = "pnlTilePalette";
            this.pnlTilePalette.Size = new System.Drawing.Size(128, 696);
            this.pnlTilePalette.TabIndex = 9;
            // 
            // btnLoadPalette
            // 
            this.btnLoadPalette.Location = new System.Drawing.Point(257, 6);
            this.btnLoadPalette.Name = "btnLoadPalette";
            this.btnLoadPalette.Size = new System.Drawing.Size(115, 29);
            this.btnLoadPalette.TabIndex = 5;
            this.btnLoadPalette.Text = "Load Palette";
            this.btnLoadPalette.UseVisualStyleBackColor = true;
            this.btnLoadPalette.Click += new System.EventHandler(this.btnLoadPalette_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(131, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(115, 29);
            this.button1.TabIndex = 2;
            this.button1.Text = "LoadTiles";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnLoadTiles_Click);
            // 
            // btnLoadTileMap
            // 
            this.btnLoadTileMap.Location = new System.Drawing.Point(10, 6);
            this.btnLoadTileMap.Name = "btnLoadTileMap";
            this.btnLoadTileMap.Size = new System.Drawing.Size(115, 29);
            this.btnLoadTileMap.TabIndex = 2;
            this.btnLoadTileMap.Text = "LoadTileMap";
            this.btnLoadTileMap.UseVisualStyleBackColor = true;
            this.btnLoadTileMap.Click += new System.EventHandler(this.btnLoadTileMap_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2140, 815);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnQuantizeImages);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSaveAsNextFormat);
            this.Controls.Add(this.btnSaveAsPNG);
            this.Controls.Add(this.btnImportFromNext);
            this.Controls.Add(this.btnImportFromPNG);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.panelParent.ResumeLayout(false);
            this.panelParent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnImportFromPNG;
        private Button btnImportFromNext;
        private Button btnSaveAsPNG;
        private Button btnSaveAsNextFormat;
        private Label label1;
        private Button btnQuantizeImages;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
    //    private Panel panel1;
        private Panel panelScrolly;
        private Panel panelParent;
        private Button btnLoadTileMap;
        private Panel pnlTileMap;
        private Button button1;
        private Button btnLoadPalette;
        private TabPage tabPage3;
        private Panel panel2;
        private Panel panel3;
        public Panel pnlPalettePicker;
        public Panel pnlTilePalette;
        private Button btnSaveTileMap;
        private TileEditor tileEditor1;
        private NumericUpDown numericUpDown1;
        private Button button2;
        private Button btnSavePalette;
        private Button btnSaveTiles;
    }
}