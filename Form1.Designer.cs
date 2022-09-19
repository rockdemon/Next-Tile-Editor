namespace Next_tile_editor
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
            this.TileEditor = new System.Windows.Forms.TabPage();
            this.panelParent = new System.Windows.Forms.Panel();
            this.pnlTileMap = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.tileEditor1 = new Next_tile_editor.TileEditor();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pnlPalettePicker = new System.Windows.Forms.Panel();
            this.pnlTilePalette = new System.Windows.Forms.Panel();
            this.btnSavePalette = new System.Windows.Forms.Button();
            this.btnSaveTiles = new System.Windows.Forms.Button();
            this.btnSaveTileMap = new System.Windows.Forms.Button();
            this.btnLoadPalette = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnLoadTileMap = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.TileEditor.SuspendLayout();
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
            this.NextPalette.Location = new System.Drawing.Point(1622, 41);
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
            this.tabControl1.Controls.Add(this.TileEditor);
            this.tabControl1.Location = new System.Drawing.Point(-2, 41);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(2140, 994);
            this.tabControl1.TabIndex = 7;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(2132, 961);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // TileEditor
            // 
            this.TileEditor.Controls.Add(this.panelParent);
            this.TileEditor.Controls.Add(this.button2);
            this.TileEditor.Controls.Add(this.numericUpDown1);
            this.TileEditor.Controls.Add(this.tileEditor1);
            this.TileEditor.Controls.Add(this.NextPalette);
            this.TileEditor.Controls.Add(this.panel3);
            this.TileEditor.Location = new System.Drawing.Point(4, 29);
            this.TileEditor.Name = "TileEditor";
            this.TileEditor.Padding = new System.Windows.Forms.Padding(3);
            this.TileEditor.Size = new System.Drawing.Size(2132, 961);
            this.TileEditor.TabIndex = 1;
            this.TileEditor.Text = "Tile Editor";
            this.TileEditor.UseVisualStyleBackColor = true;
            // 
            // panelParent
            // 
            this.panelParent.AutoScroll = true;
            this.panelParent.Controls.Add(this.pnlTileMap);
            this.panelParent.Location = new System.Drawing.Point(6, 41);
            this.panelParent.MaximumSize = new System.Drawing.Size(1320, 800);
            this.panelParent.Name = "panelParent";
            this.panelParent.Size = new System.Drawing.Size(1320, 800);
            this.panelParent.TabIndex = 6;
            // 
            // pnlTileMap
            // 
            this.pnlTileMap.Location = new System.Drawing.Point(0, 0);
            this.pnlTileMap.MaximumSize = new System.Drawing.Size(1280, 8192);
            this.pnlTileMap.Name = "pnlTileMap";
            this.pnlTileMap.Size = new System.Drawing.Size(1280, 8192);
            this.pnlTileMap.TabIndex = 4;
            this.pnlTileMap.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlTileMap_Paint);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1772, 429);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(91, 36);
            this.button2.TabIndex = 17;
            this.button2.Text = "SaveTile";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(1772, 367);
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
            this.tileEditor1.Location = new System.Drawing.Point(1772, 41);
            this.tileEditor1.Name = "tileEditor1";
            this.tileEditor1.palette = null;
            this.tileEditor1.PaletteOffset = 0;
            this.tileEditor1.Paper = null;
            this.tileEditor1.PaperVal = 0;
            this.tileEditor1.Size = new System.Drawing.Size(256, 320);
            this.tileEditor1.TabIndex = 13;
            this.tileEditor1.Tile = null;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Controls.Add(this.pnlPalettePicker);
            this.panel3.Controls.Add(this.pnlTilePalette);
            this.panel3.Location = new System.Drawing.Point(1332, 41);
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
            // btnSavePalette
            // 
            this.btnSavePalette.Location = new System.Drawing.Point(1479, 12);
            this.btnSavePalette.Name = "btnSavePalette";
            this.btnSavePalette.Size = new System.Drawing.Size(115, 29);
            this.btnSavePalette.TabIndex = 25;
            this.btnSavePalette.Text = "Save Palette";
            this.btnSavePalette.UseVisualStyleBackColor = true;
            this.btnSavePalette.Click += new System.EventHandler(this.btnSavePalette_Click);
            // 
            // btnSaveTiles
            // 
            this.btnSaveTiles.Location = new System.Drawing.Point(1353, 12);
            this.btnSaveTiles.Name = "btnSaveTiles";
            this.btnSaveTiles.Size = new System.Drawing.Size(115, 29);
            this.btnSaveTiles.TabIndex = 24;
            this.btnSaveTiles.Text = "Save Tiles";
            this.btnSaveTiles.UseVisualStyleBackColor = true;
            this.btnSaveTiles.Click += new System.EventHandler(this.btnSaveTiles_Click);
            // 
            // btnSaveTileMap
            // 
            this.btnSaveTileMap.Location = new System.Drawing.Point(1232, 12);
            this.btnSaveTileMap.Name = "btnSaveTileMap";
            this.btnSaveTileMap.Size = new System.Drawing.Size(115, 29);
            this.btnSaveTileMap.TabIndex = 23;
            this.btnSaveTileMap.Text = "SaveTileMap";
            this.btnSaveTileMap.UseVisualStyleBackColor = true;
            this.btnSaveTileMap.Click += new System.EventHandler(this.btnSaveTileMap_Click);
            // 
            // btnLoadPalette
            // 
            this.btnLoadPalette.Location = new System.Drawing.Point(1061, 12);
            this.btnLoadPalette.Name = "btnLoadPalette";
            this.btnLoadPalette.Size = new System.Drawing.Size(115, 29);
            this.btnLoadPalette.TabIndex = 22;
            this.btnLoadPalette.Text = "Load Palette";
            this.btnLoadPalette.UseVisualStyleBackColor = true;
            this.btnLoadPalette.Click += new System.EventHandler(this.btnLoadPalette_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(935, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(115, 29);
            this.button1.TabIndex = 20;
            this.button1.Text = "LoadTiles";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnLoadTiles_Click);
            // 
            // btnLoadTileMap
            // 
            this.btnLoadTileMap.Location = new System.Drawing.Point(814, 12);
            this.btnLoadTileMap.Name = "btnLoadTileMap";
            this.btnLoadTileMap.Size = new System.Drawing.Size(115, 29);
            this.btnLoadTileMap.TabIndex = 21;
            this.btnLoadTileMap.Text = "LoadTileMap";
            this.btnLoadTileMap.UseVisualStyleBackColor = true;
            this.btnLoadTileMap.Click += new System.EventHandler(this.btnLoadTileMap_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2140, 1033);
            this.Controls.Add(this.btnSavePalette);
            this.Controls.Add(this.btnSaveTiles);
            this.Controls.Add(this.btnSaveTileMap);
            this.Controls.Add(this.btnLoadPalette);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnLoadTileMap);
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
            this.TileEditor.ResumeLayout(false);
            this.panelParent.ResumeLayout(false);
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
        private TabPage TileEditor;
        private Panel panelParent;
        private Panel pnlTileMap;
        private Panel panel2;
        private Panel panel3;
        public Panel pnlPalettePicker;
        public Panel pnlTilePalette;
        private TileEditor tileEditor1;
        private NumericUpDown numericUpDown1;
        private Button button2;
        private Button btnSavePalette;
        private Button btnSaveTiles;
        private Button btnSaveTileMap;
        private Button btnLoadPalette;
        private Button button1;
        private Button btnLoadTileMap;
    }
}