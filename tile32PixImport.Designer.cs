namespace Next_tile_editor
{
    partial class tile32PixImport
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnLoadImage = new Button();
            btn_cutIntoTiles = new Button();
            btnQuantizeColours = new Button();
            btn_CommonTileCheck = new Button();
            btn_CreateTilesAndMapping8_8_Map = new Button();
            panel2 = new DBPanel();
            chknumbers = new CheckBox();
            checkBox1 = new CheckBox();
            label3 = new Label();
            btnLoad_32_32_px_tilemap = new Button();
            button3 = new Button();
            button2 = new Button();
            btnExportTile_32_Tile_8 = new Button();
            pct_OriginalTileBitmap = new PictureBox();
            pnl_32_32_tiles = new DBPanel();
            pnl_QuantizedColour = new DBPanel();
            pnl_CommonTiles = new DBPanel();
            pnl_fromActualTilemap = new DBPanel();
            pnlUserTileMap = new Panel();
            pnl_32x32_gauntletMap = new DBPanel();
            panel1 = new Panel();
            panel3 = new Panel();
            lblImportAndPalette = new Label();
            tabTileControlAndImport = new TabControl();
            tabOpenTileBMP = new TabPage();
            tabCutIntoSuperTiles = new TabPage();
            tabQuantizeImages = new TabPage();
            tabCommonTileCheck = new TabPage();
            rtbTileStats = new RichTextBox();
            tabCreateFinalTileToolbox = new TabPage();
            tabTileToolbox = new TabPage();
            dbPanel1 = new Panel();
            pnl_32_32_TilePalette = new DBPanel();
            btnRightTile = new Button();
            numMapHeight = new NumericUpDown();
            btnTileLeft = new Button();
            label2 = new Label();
            numMapWidth = new NumericUpDown();
            label1 = new Label();
            DropDown_SuperTileSize = new ComboBox();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pct_OriginalTileBitmap).BeginInit();
            pnlUserTileMap.SuspendLayout();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            tabTileControlAndImport.SuspendLayout();
            tabOpenTileBMP.SuspendLayout();
            tabCutIntoSuperTiles.SuspendLayout();
            tabQuantizeImages.SuspendLayout();
            tabCommonTileCheck.SuspendLayout();
            tabCreateFinalTileToolbox.SuspendLayout();
            tabTileToolbox.SuspendLayout();
            dbPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numMapHeight).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numMapWidth).BeginInit();
            SuspendLayout();
            // 
            // btnLoadImage
            // 
            btnLoadImage.Location = new Point(18, 6);
            btnLoadImage.Name = "btnLoadImage";
            btnLoadImage.Size = new Size(94, 29);
            btnLoadImage.TabIndex = 0;
            btnLoadImage.Text = "Open image File";
            btnLoadImage.UseVisualStyleBackColor = true;
            btnLoadImage.Click += btnLoadImage_Click;
            // 
            // btn_cutIntoTiles
            // 
            btn_cutIntoTiles.Location = new Point(20, 21);
            btn_cutIntoTiles.Name = "btn_cutIntoTiles";
            btn_cutIntoTiles.Size = new Size(141, 29);
            btn_cutIntoTiles.TabIndex = 2;
            btn_cutIntoTiles.Text = "Cut Into SuperTiles";
            btn_cutIntoTiles.UseVisualStyleBackColor = true;
            btn_cutIntoTiles.Click += btn_CutIntoTiles_Click;
            // 
            // btnQuantizeColours
            // 
            btnQuantizeColours.Location = new Point(6, 6);
            btnQuantizeColours.Name = "btnQuantizeColours";
            btnQuantizeColours.Size = new Size(294, 29);
            btnQuantizeColours.TabIndex = 3;
            btnQuantizeColours.Text = "Quantize images";
            btnQuantizeColours.UseVisualStyleBackColor = true;
            btnQuantizeColours.Click += btnQuantizeColours_Click;
            // 
            // btn_CommonTileCheck
            // 
            btn_CommonTileCheck.Location = new Point(6, 6);
            btn_CommonTileCheck.Name = "btn_CommonTileCheck";
            btn_CommonTileCheck.Size = new Size(193, 29);
            btn_CommonTileCheck.TabIndex = 4;
            btn_CommonTileCheck.Text = "Common tile check";
            btn_CommonTileCheck.UseVisualStyleBackColor = true;
            btn_CommonTileCheck.Click += btn_CommonTileCheck_Click;
            // 
            // btn_CreateTilesAndMapping8_8_Map
            // 
            btn_CreateTilesAndMapping8_8_Map.Location = new Point(6, 26);
            btn_CreateTilesAndMapping8_8_Map.Name = "btn_CreateTilesAndMapping8_8_Map";
            btn_CreateTilesAndMapping8_8_Map.Size = new Size(193, 29);
            btn_CreateTilesAndMapping8_8_Map.TabIndex = 7;
            btn_CreateTilesAndMapping8_8_Map.Text = "Make Tiles and map of original map";
            btn_CreateTilesAndMapping8_8_Map.UseVisualStyleBackColor = true;
            btn_CreateTilesAndMapping8_8_Map.Click += btnCreateTileToolboxandMap_Click;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            panel2.Controls.Add(chknumbers);
            panel2.Controls.Add(checkBox1);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(btnLoad_32_32_px_tilemap);
            panel2.Controls.Add(button3);
            panel2.Controls.Add(button2);
            panel2.Controls.Add(btnExportTile_32_Tile_8);
            panel2.Location = new Point(1, 4);
            panel2.Name = "panel2";
            panel2.Size = new Size(156, 814);
            panel2.TabIndex = 0;
            // 
            // chknumbers
            // 
            chknumbers.AutoSize = true;
            chknumbers.Checked = true;
            chknumbers.CheckState = CheckState.Checked;
            chknumbers.Location = new Point(11, 50);
            chknumbers.Name = "chknumbers";
            chknumbers.Size = new Size(126, 24);
            chknumbers.TabIndex = 12;
            chknumbers.Text = "show numbers";
            chknumbers.UseVisualStyleBackColor = true;
            chknumbers.CheckedChanged += chknumbers_CheckedChanged;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(11, 20);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(133, 24);
            checkBox1.TabIndex = 11;
            checkBox1.Text = "Show map Grid";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            checkBox1.Click += checkBox1_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(26, 427);
            label3.Name = "label3";
            label3.Size = new Size(56, 20);
            label3.TabIndex = 10;
            label3.Text = "TILES:#";
            // 
            // btnLoad_32_32_px_tilemap
            // 
            btnLoad_32_32_px_tilemap.Location = new Point(23, 238);
            btnLoad_32_32_px_tilemap.Name = "btnLoad_32_32_px_tilemap";
            btnLoad_32_32_px_tilemap.Size = new Size(102, 79);
            btnLoad_32_32_px_tilemap.TabIndex = 4;
            btnLoad_32_32_px_tilemap.Text = "Load 32_32_px_tilemap";
            btnLoad_32_32_px_tilemap.UseVisualStyleBackColor = true;
            btnLoad_32_32_px_tilemap.Click += btnLoad_32_32_px_tilemap_Click;
            // 
            // button3
            // 
            button3.Location = new Point(23, 190);
            button3.Name = "button3";
            button3.Size = new Size(102, 42);
            button3.TabIndex = 1;
            button3.Text = "Load defs";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.Location = new Point(23, 584);
            button2.Name = "button2";
            button2.Size = new Size(84, 110);
            button2.TabIndex = 9;
            button2.Text = "Save_32_32px tilemap";
            button2.UseVisualStyleBackColor = true;
            button2.Click += btn_Save32_32px_tilemap;
            // 
            // btnExportTile_32_Tile_8
            // 
            btnExportTile_32_Tile_8.Location = new Point(23, 457);
            btnExportTile_32_Tile_8.Name = "btnExportTile_32_Tile_8";
            btnExportTile_32_Tile_8.Size = new Size(84, 121);
            btnExportTile_32_Tile_8.TabIndex = 7;
            btnExportTile_32_Tile_8.Text = "Export Maps and palette";
            btnExportTile_32_Tile_8.UseVisualStyleBackColor = true;
            btnExportTile_32_Tile_8.Click += btnExportTile_32_Tile_8_Click;
            // 
            // pct_OriginalTileBitmap
            // 
            pct_OriginalTileBitmap.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pct_OriginalTileBitmap.Location = new Point(6, 59);
            pct_OriginalTileBitmap.Name = "pct_OriginalTileBitmap";
            pct_OriginalTileBitmap.Size = new Size(848, 662);
            pct_OriginalTileBitmap.TabIndex = 0;
            pct_OriginalTileBitmap.TabStop = false;
            // 
            // pnl_32_32_tiles
            // 
            pnl_32_32_tiles.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnl_32_32_tiles.Location = new Point(6, 56);
            pnl_32_32_tiles.Name = "pnl_32_32_tiles";
            pnl_32_32_tiles.Size = new Size(848, 642);
            pnl_32_32_tiles.TabIndex = 1;
            pnl_32_32_tiles.Paint += pnl_32_32_tiles_Paint;
            // 
            // pnl_QuantizedColour
            // 
            pnl_QuantizedColour.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnl_QuantizedColour.Location = new Point(6, 41);
            pnl_QuantizedColour.Name = "pnl_QuantizedColour";
            pnl_QuantizedColour.Size = new Size(848, 657);
            pnl_QuantizedColour.TabIndex = 2;
            pnl_QuantizedColour.Paint += pnl_QuantizedColour_Paint;
            // 
            // pnl_CommonTiles
            // 
            pnl_CommonTiles.Location = new Point(12, 41);
            pnl_CommonTiles.Name = "pnl_CommonTiles";
            pnl_CommonTiles.Size = new Size(842, 578);
            pnl_CommonTiles.TabIndex = 3;
            pnl_CommonTiles.Paint += pnl_CommonTiles_Paint;
            // 
            // pnl_fromActualTilemap
            // 
            pnl_fromActualTilemap.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnl_fromActualTilemap.Location = new Point(6, 61);
            pnl_fromActualTilemap.Name = "pnl_fromActualTilemap";
            pnl_fromActualTilemap.Size = new Size(892, 637);
            pnl_fromActualTilemap.TabIndex = 5;
            pnl_fromActualTilemap.Paint += pnl_fromActualTilemap_Paint;
            // 
            // pnlUserTileMap
            // 
            pnlUserTileMap.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlUserTileMap.AutoScroll = true;
            pnlUserTileMap.Controls.Add(pnl_32x32_gauntletMap);
            pnlUserTileMap.Location = new Point(163, 3);
            pnlUserTileMap.Name = "pnlUserTileMap";
            pnlUserTileMap.Size = new Size(794, 811);
            pnlUserTileMap.TabIndex = 8;
            // 
            // pnl_32x32_gauntletMap
            // 
            pnl_32x32_gauntletMap.BorderStyle = BorderStyle.FixedSingle;
            pnl_32x32_gauntletMap.CausesValidation = false;
            pnl_32x32_gauntletMap.Location = new Point(3, 14);
            pnl_32x32_gauntletMap.Name = "pnl_32x32_gauntletMap";
            pnl_32x32_gauntletMap.Size = new Size(2048, 2048);
            pnl_32x32_gauntletMap.TabIndex = 7;
            pnl_32x32_gauntletMap.Paint += pnl_gauntletMap_Paint;
            pnl_32x32_gauntletMap.MouseDown += panel7_MouseDown;
            pnl_32x32_gauntletMap.MouseMove += panel7_MouseMove;
            pnl_32x32_gauntletMap.MouseUp += panel7_MouseUp;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(pnlUserTileMap);
            panel1.Controls.Add(panel2);
            panel1.Location = new Point(2, 34);
            panel1.Name = "panel1";
            panel1.Size = new Size(1855, 821);
            panel1.TabIndex = 1;
            // 
            // panel3
            // 
            panel3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            panel3.Controls.Add(lblImportAndPalette);
            panel3.Controls.Add(tabTileControlAndImport);
            panel3.Location = new Point(963, 13);
            panel3.Name = "panel3";
            panel3.Size = new Size(889, 801);
            panel3.TabIndex = 16;
            // 
            // lblImportAndPalette
            // 
            lblImportAndPalette.AllowDrop = true;
            lblImportAndPalette.AutoSize = true;
            lblImportAndPalette.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            lblImportAndPalette.Location = new Point(3, -1);
            lblImportAndPalette.Name = "lblImportAndPalette";
            lblImportAndPalette.Size = new Size(149, 25);
            lblImportAndPalette.TabIndex = 15;
            lblImportAndPalette.Text = "Import and Tiles";
            // 
            // tabTileControlAndImport
            // 
            tabTileControlAndImport.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabTileControlAndImport.Appearance = TabAppearance.FlatButtons;
            tabTileControlAndImport.Controls.Add(tabOpenTileBMP);
            tabTileControlAndImport.Controls.Add(tabCutIntoSuperTiles);
            tabTileControlAndImport.Controls.Add(tabQuantizeImages);
            tabTileControlAndImport.Controls.Add(tabCommonTileCheck);
            tabTileControlAndImport.Controls.Add(tabCreateFinalTileToolbox);
            tabTileControlAndImport.Controls.Add(tabTileToolbox);
            tabTileControlAndImport.Location = new Point(3, 27);
            tabTileControlAndImport.Name = "tabTileControlAndImport";
            tabTileControlAndImport.SelectedIndex = 0;
            tabTileControlAndImport.Size = new Size(868, 762);
            tabTileControlAndImport.TabIndex = 14;
            // 
            // tabOpenTileBMP
            // 
            tabOpenTileBMP.BackColor = SystemColors.ButtonFace;
            tabOpenTileBMP.Controls.Add(btnLoadImage);
            tabOpenTileBMP.Controls.Add(pct_OriginalTileBitmap);
            tabOpenTileBMP.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            tabOpenTileBMP.Location = new Point(4, 32);
            tabOpenTileBMP.Name = "tabOpenTileBMP";
            tabOpenTileBMP.Padding = new Padding(3);
            tabOpenTileBMP.Size = new Size(860, 726);
            tabOpenTileBMP.TabIndex = 0;
            tabOpenTileBMP.Text = "LoadTileBMP/PNG";
            // 
            // tabCutIntoSuperTiles
            // 
            tabCutIntoSuperTiles.Controls.Add(pnl_32_32_tiles);
            tabCutIntoSuperTiles.Controls.Add(btn_cutIntoTiles);
            tabCutIntoSuperTiles.Location = new Point(4, 32);
            tabCutIntoSuperTiles.Name = "tabCutIntoSuperTiles";
            tabCutIntoSuperTiles.Padding = new Padding(3);
            tabCutIntoSuperTiles.Size = new Size(860, 726);
            tabCutIntoSuperTiles.TabIndex = 1;
            tabCutIntoSuperTiles.Text = "tabCutIntoSuperTiles";
            tabCutIntoSuperTiles.UseVisualStyleBackColor = true;
            tabCutIntoSuperTiles.Click += tabPage2_Click;
            // 
            // tabQuantizeImages
            // 
            tabQuantizeImages.Controls.Add(btnQuantizeColours);
            tabQuantizeImages.Controls.Add(pnl_QuantizedColour);
            tabQuantizeImages.Location = new Point(4, 32);
            tabQuantizeImages.Name = "tabQuantizeImages";
            tabQuantizeImages.Padding = new Padding(3);
            tabQuantizeImages.Size = new Size(860, 726);
            tabQuantizeImages.TabIndex = 2;
            tabQuantizeImages.Text = "Quantize Images";
            tabQuantizeImages.UseVisualStyleBackColor = true;
            // 
            // tabCommonTileCheck
            // 
            tabCommonTileCheck.Controls.Add(rtbTileStats);
            tabCommonTileCheck.Controls.Add(btn_CommonTileCheck);
            tabCommonTileCheck.Controls.Add(pnl_CommonTiles);
            tabCommonTileCheck.Location = new Point(4, 32);
            tabCommonTileCheck.Name = "tabCommonTileCheck";
            tabCommonTileCheck.Padding = new Padding(3);
            tabCommonTileCheck.Size = new Size(860, 726);
            tabCommonTileCheck.TabIndex = 3;
            tabCommonTileCheck.Text = "CommonTileCheck";
            tabCommonTileCheck.UseVisualStyleBackColor = true;
            // 
            // rtbTileStats
            // 
            rtbTileStats.Location = new Point(17, 631);
            rtbTileStats.Name = "rtbTileStats";
            rtbTileStats.ReadOnly = true;
            rtbTileStats.Size = new Size(827, 92);
            rtbTileStats.TabIndex = 5;
            rtbTileStats.Text = "";
            // 
            // tabCreateFinalTileToolbox
            // 
            tabCreateFinalTileToolbox.Controls.Add(btn_CreateTilesAndMapping8_8_Map);
            tabCreateFinalTileToolbox.Controls.Add(pnl_fromActualTilemap);
            tabCreateFinalTileToolbox.Location = new Point(4, 32);
            tabCreateFinalTileToolbox.Name = "tabCreateFinalTileToolbox";
            tabCreateFinalTileToolbox.Padding = new Padding(3);
            tabCreateFinalTileToolbox.Size = new Size(860, 726);
            tabCreateFinalTileToolbox.TabIndex = 4;
            tabCreateFinalTileToolbox.Text = "Create TileToolbox+Map";
            tabCreateFinalTileToolbox.UseVisualStyleBackColor = true;
            // 
            // tabTileToolbox
            // 
            tabTileToolbox.Controls.Add(dbPanel1);
            tabTileToolbox.Controls.Add(btnRightTile);
            tabTileToolbox.Controls.Add(numMapHeight);
            tabTileToolbox.Controls.Add(btnTileLeft);
            tabTileToolbox.Controls.Add(label2);
            tabTileToolbox.Controls.Add(numMapWidth);
            tabTileToolbox.Controls.Add(label1);
            tabTileToolbox.Location = new Point(4, 32);
            tabTileToolbox.Name = "tabTileToolbox";
            tabTileToolbox.Padding = new Padding(3);
            tabTileToolbox.Size = new Size(860, 726);
            tabTileToolbox.TabIndex = 5;
            tabTileToolbox.Text = "Toolbox";
            tabTileToolbox.UseVisualStyleBackColor = true;
            // 
            // dbPanel1
            // 
            dbPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dbPanel1.AutoScroll = true;
            dbPanel1.Controls.Add(pnl_32_32_TilePalette);
            dbPanel1.Location = new Point(6, 6);
            dbPanel1.Name = "dbPanel1";
            dbPanel1.Size = new Size(848, 565);
            dbPanel1.TabIndex = 14;
            // 
            // pnl_32_32_TilePalette
            // 
            pnl_32_32_TilePalette.AutoScroll = true;
            pnl_32_32_TilePalette.AutoScrollMargin = new Size(8, 8);
            pnl_32_32_TilePalette.AutoSize = true;
            pnl_32_32_TilePalette.CausesValidation = false;
            pnl_32_32_TilePalette.Location = new Point(0, 0);
            pnl_32_32_TilePalette.Name = "pnl_32_32_TilePalette";
            pnl_32_32_TilePalette.Size = new Size(900, 559);
            pnl_32_32_TilePalette.TabIndex = 8;
            pnl_32_32_TilePalette.Paint += pnl_32_32_TilePalette_Paint;
            pnl_32_32_TilePalette.MouseDown += pnl_32_32_TilePalette_MouseDown;
            // 
            // btnRightTile
            // 
            btnRightTile.Location = new Point(382, 605);
            btnRightTile.Name = "btnRightTile";
            btnRightTile.Size = new Size(94, 37);
            btnRightTile.TabIndex = 11;
            btnRightTile.Text = ">>";
            btnRightTile.UseVisualStyleBackColor = true;
            btnRightTile.Click += btnRightTile_Click;
            // 
            // numMapHeight
            // 
            numMapHeight.Location = new Point(100, 617);
            numMapHeight.Maximum = new decimal(new int[] { 4096, 0, 0, 0 });
            numMapHeight.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numMapHeight.Name = "numMapHeight";
            numMapHeight.Size = new Size(88, 27);
            numMapHeight.TabIndex = 12;
            numMapHeight.Value = new decimal(new int[] { 64, 0, 0, 0 });
            numMapHeight.ValueChanged += numMapHeight_ValueChanged;
            // 
            // btnTileLeft
            // 
            btnTileLeft.Location = new Point(279, 603);
            btnTileLeft.Name = "btnTileLeft";
            btnTileLeft.Size = new Size(97, 41);
            btnTileLeft.TabIndex = 10;
            btnTileLeft.Text = "<<";
            btnTileLeft.UseVisualStyleBackColor = true;
            btnTileLeft.Click += btnTileLeft_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(113, 594);
            label2.Name = "label2";
            label2.Size = new Size(54, 20);
            label2.TabIndex = 13;
            label2.Text = "Height";
            // 
            // numMapWidth
            // 
            numMapWidth.Location = new Point(6, 617);
            numMapWidth.Maximum = new decimal(new int[] { 1024, 0, 0, 0 });
            numMapWidth.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numMapWidth.Name = "numMapWidth";
            numMapWidth.Size = new Size(88, 27);
            numMapWidth.TabIndex = 12;
            numMapWidth.Value = new decimal(new int[] { 32, 0, 0, 0 });
            numMapWidth.ValueChanged += numMapWidth_ValueChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 594);
            label1.Name = "label1";
            label1.Size = new Size(49, 20);
            label1.TabIndex = 13;
            label1.Text = "Width";
            // 
            // DropDown_SuperTileSize
            // 
            DropDown_SuperTileSize.FormattingEnabled = true;
            DropDown_SuperTileSize.Items.AddRange(new object[] { "1x1 (8x8px)", "2x2 (16x16px)", "4x4 (32x32px)" });
            DropDown_SuperTileSize.Location = new Point(399, 2);
            DropDown_SuperTileSize.Name = "DropDown_SuperTileSize";
            DropDown_SuperTileSize.Size = new Size(151, 28);
            DropDown_SuperTileSize.TabIndex = 8;
            DropDown_SuperTileSize.SelectedIndexChanged += DropDown_SuperTileSize_ValueChanged;
            // 
            // tile32PixImport
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkGray;
            Controls.Add(DropDown_SuperTileSize);
            Controls.Add(panel1);
            Name = "tile32PixImport";
            Size = new Size(1876, 882);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pct_OriginalTileBitmap).EndInit();
            pnlUserTileMap.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            tabTileControlAndImport.ResumeLayout(false);
            tabOpenTileBMP.ResumeLayout(false);
            tabCutIntoSuperTiles.ResumeLayout(false);
            tabQuantizeImages.ResumeLayout(false);
            tabCommonTileCheck.ResumeLayout(false);
            tabCreateFinalTileToolbox.ResumeLayout(false);
            tabTileToolbox.ResumeLayout(false);
            tabTileToolbox.PerformLayout();
            dbPanel1.ResumeLayout(false);
            dbPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numMapHeight).EndInit();
            ((System.ComponentModel.ISupportInitialize)numMapWidth).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnLoadImage;
        private Button btn_cutIntoTiles;
        private PictureBox pbTemp;
        private Button btnQuantizeColours;
        private Button btn_CommonTileCheck;
        private Button btn_CreateTilesAndMapping8_8_Map;
        private DBPanel panel2;
        private PictureBox pct_OriginalTileBitmap;
        private DBPanel pnl_32_32_tiles;
        private DBPanel pnl_QuantizedColour;
        private DBPanel pnl_CommonTiles;
        private DBPanel pnl_fromActualTilemap;
        private Button btnExportTile_32_Tile_8;
        private Panel pnlUserTileMap;
        private DBPanel pnl_32x32_gauntletMap;
        private Panel panel1;
        private Button button2;
        private Button btnLoad_32_32_px_tilemap;
        private Button button3;
        private Button btnRightTile;
        private Button btnTileLeft;
        private ComboBox DropDown_SuperTileSize;
        private Label label1;
        private NumericUpDown numMapHeight;
        private NumericUpDown numMapWidth;
        private Label label3;
        private Label label2;
        private TabControl tabTileControlAndImport;
        private TabPage tabOpenTileBMP;
        private TabPage tabCutIntoSuperTiles;
        private TabPage tabQuantizeImages;
        private TabPage tabCommonTileCheck;
        private TabPage tabCreateFinalTileToolbox;
        private TabPage tabTileToolbox;
        private Label lblImportAndPalette;
        private Panel panel3;
        private RichTextBox rtbTileStats;
        private Panel dbPanel1;
        private DBPanel pnl_32_32_TilePalette;
        private CheckBox checkBox1;
        private CheckBox chknumbers;
    }
}
