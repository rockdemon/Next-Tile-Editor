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
            pnl_32_32_TilePalette = new DBPanel();
            panel3 = new Panel();
            pnl_32x32_gauntletMap = new DBPanel();
            panel1 = new Panel();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            tabPage2 = new TabPage();
            tabPage3 = new TabPage();
            tabPage4 = new TabPage();
            tabPage5 = new TabPage();
            tabPage6 = new TabPage();
            btnRightTile = new Button();
            numMapHeight = new NumericUpDown();
            btnTileLeft = new Button();
            label2 = new Label();
            numMapWidth = new NumericUpDown();
            label1 = new Label();
            DropDown_SuperTileSize = new ComboBox();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pct_OriginalTileBitmap).BeginInit();
            panel3.SuspendLayout();
            panel1.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            tabPage3.SuspendLayout();
            tabPage4.SuspendLayout();
            tabPage5.SuspendLayout();
            tabPage6.SuspendLayout();
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
            btn_CreateTilesAndMapping8_8_Map.Click += button4_Click;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            panel2.Controls.Add(label3);
            panel2.Controls.Add(btnLoad_32_32_px_tilemap);
            panel2.Controls.Add(button3);
            panel2.Controls.Add(button2);
            panel2.Controls.Add(btnExportTile_32_Tile_8);
            panel2.Location = new Point(1, 4);
            panel2.Name = "panel2";
            panel2.Size = new Size(156, 771);
            panel2.TabIndex = 0;
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
            btnExportTile_32_Tile_8.Enabled = false;
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
            pct_OriginalTileBitmap.Size = new Size(869, 662);
            pct_OriginalTileBitmap.TabIndex = 0;
            pct_OriginalTileBitmap.TabStop = false;
            // 
            // pnl_32_32_tiles
            // 
            pnl_32_32_tiles.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnl_32_32_tiles.Location = new Point(6, 56);
            pnl_32_32_tiles.Name = "pnl_32_32_tiles";
            pnl_32_32_tiles.Size = new Size(910, 665);
            pnl_32_32_tiles.TabIndex = 1;
            pnl_32_32_tiles.Paint += pnl_32_32_tiles_Paint;
            // 
            // pnl_QuantizedColour
            // 
            pnl_QuantizedColour.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnl_QuantizedColour.Location = new Point(6, 41);
            pnl_QuantizedColour.Name = "pnl_QuantizedColour";
            pnl_QuantizedColour.Size = new Size(910, 680);
            pnl_QuantizedColour.TabIndex = 2;
            pnl_QuantizedColour.Paint += pnl_QuantizedColour_Paint;
            // 
            // pnl_CommonTiles
            // 
            pnl_CommonTiles.Location = new Point(12, 41);
            pnl_CommonTiles.Name = "pnl_CommonTiles";
            pnl_CommonTiles.Size = new Size(323, 138);
            pnl_CommonTiles.TabIndex = 3;
            pnl_CommonTiles.Paint += pnl_CommonTiles_Paint;
            // 
            // pnl_fromActualTilemap
            // 
            pnl_fromActualTilemap.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnl_fromActualTilemap.Location = new Point(6, 61);
            pnl_fromActualTilemap.Name = "pnl_fromActualTilemap";
            pnl_fromActualTilemap.Size = new Size(913, 660);
            pnl_fromActualTilemap.TabIndex = 5;
            pnl_fromActualTilemap.Paint += pnl_fromActualTilemap_Paint;
            // 
            // pnl_32_32_TilePalette
            // 
            pnl_32_32_TilePalette.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnl_32_32_TilePalette.Location = new Point(6, 6);
            pnl_32_32_TilePalette.Name = "pnl_32_32_TilePalette";
            pnl_32_32_TilePalette.Size = new Size(910, 585);
            pnl_32_32_TilePalette.TabIndex = 7;
            pnl_32_32_TilePalette.Paint += pnl_32_32_TilePalette_Paint;
            pnl_32_32_TilePalette.MouseDown += pnl_32_32_TilePalette_MouseDown;
            // 
            // panel3
            // 
            panel3.AutoScroll = true;
            panel3.Controls.Add(pnl_32x32_gauntletMap);
            panel3.Location = new Point(163, 3);
            panel3.Name = "panel3";
            panel3.Size = new Size(794, 772);
            panel3.TabIndex = 8;
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
            panel1.Controls.Add(tabControl1);
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(panel2);
            panel1.Location = new Point(2, 34);
            panel1.Name = "panel1";
            panel1.Size = new Size(1855, 778);
            panel1.TabIndex = 1;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Controls.Add(tabPage4);
            tabControl1.Controls.Add(tabPage5);
            tabControl1.Controls.Add(tabPage6);
            tabControl1.Location = new Point(963, 15);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(889, 760);
            tabControl1.TabIndex = 14;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(btnLoadImage);
            tabPage1.Controls.Add(pct_OriginalTileBitmap);
            tabPage1.Location = new Point(4, 29);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(881, 727);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "tabPage1";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(pnl_32_32_tiles);
            tabPage2.Controls.Add(btn_cutIntoTiles);
            tabPage2.Location = new Point(4, 29);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(922, 727);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "tabPage2";
            tabPage2.UseVisualStyleBackColor = true;
            tabPage2.Click += tabPage2_Click;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(btnQuantizeColours);
            tabPage3.Controls.Add(pnl_QuantizedColour);
            tabPage3.Location = new Point(4, 29);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(922, 727);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "tabPage3";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            tabPage4.Controls.Add(btn_CommonTileCheck);
            tabPage4.Controls.Add(pnl_CommonTiles);
            tabPage4.Location = new Point(4, 29);
            tabPage4.Name = "tabPage4";
            tabPage4.Padding = new Padding(3);
            tabPage4.Size = new Size(922, 727);
            tabPage4.TabIndex = 3;
            tabPage4.Text = "tabPage4";
            tabPage4.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            tabPage5.Controls.Add(btn_CreateTilesAndMapping8_8_Map);
            tabPage5.Controls.Add(pnl_fromActualTilemap);
            tabPage5.Location = new Point(4, 29);
            tabPage5.Name = "tabPage5";
            tabPage5.Padding = new Padding(3);
            tabPage5.Size = new Size(922, 727);
            tabPage5.TabIndex = 4;
            tabPage5.Text = "tabPage5";
            tabPage5.UseVisualStyleBackColor = true;
            // 
            // tabPage6
            // 
            tabPage6.Controls.Add(pnl_32_32_TilePalette);
            tabPage6.Controls.Add(btnRightTile);
            tabPage6.Controls.Add(numMapHeight);
            tabPage6.Controls.Add(btnTileLeft);
            tabPage6.Controls.Add(label2);
            tabPage6.Controls.Add(numMapWidth);
            tabPage6.Controls.Add(label1);
            tabPage6.Location = new Point(4, 29);
            tabPage6.Name = "tabPage6";
            tabPage6.Padding = new Padding(3);
            tabPage6.Size = new Size(922, 727);
            tabPage6.TabIndex = 5;
            tabPage6.Text = "tabPage6";
            tabPage6.UseVisualStyleBackColor = true;
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
            numMapWidth.Value = new decimal(new int[] { 64, 0, 0, 0 });
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
            Controls.Add(DropDown_SuperTileSize);
            Controls.Add(panel1);
            Name = "tile32PixImport";
            Size = new Size(1876, 882);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pct_OriginalTileBitmap).EndInit();
            panel3.ResumeLayout(false);
            panel1.ResumeLayout(false);
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            tabPage3.ResumeLayout(false);
            tabPage4.ResumeLayout(false);
            tabPage5.ResumeLayout(false);
            tabPage6.ResumeLayout(false);
            tabPage6.PerformLayout();
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
        private DBPanel pnl_32_32_TilePalette;
        private Panel panel3;
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
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private TabPage tabPage4;
        private TabPage tabPage5;
        private TabPage tabPage6;
    }
}
