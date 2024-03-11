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
            pct_OriginalTileBitmap = new PictureBox();
            btnExportTile_32_Tile_8 = new Button();
            pnl_32_32_tiles = new DBPanel();
            pnl_QuantizedColour = new DBPanel();
            pnl_CommonTiles = new DBPanel();
            pnl_fromActualTilemap = new DBPanel();
            pnl_32_32_TilePalette = new DBPanel();
            panel3 = new Panel();
            pnl_32x32_gauntletMap = new DBPanel();
            panel1 = new Panel();
            label2 = new Label();
            label1 = new Label();
            numMapHeight = new NumericUpDown();
            numMapWidth = new NumericUpDown();
            btnRightTile = new Button();
            btnTileLeft = new Button();
            DropDown_SuperTileSize = new ComboBox();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pct_OriginalTileBitmap).BeginInit();
            panel3.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numMapHeight).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numMapWidth).BeginInit();
            SuspendLayout();
            // 
            // btnLoadImage
            // 
            btnLoadImage.Location = new Point(0, 0);
            btnLoadImage.Name = "btnLoadImage";
            btnLoadImage.Size = new Size(94, 29);
            btnLoadImage.TabIndex = 0;
            btnLoadImage.Text = "Open image File";
            btnLoadImage.UseVisualStyleBackColor = true;
            btnLoadImage.Click += btnLoadImage_Click;
            // 
            // btn_cutIntoTiles
            // 
            btn_cutIntoTiles.Location = new Point(252, 2);
            btn_cutIntoTiles.Name = "btn_cutIntoTiles";
            btn_cutIntoTiles.Size = new Size(141, 29);
            btn_cutIntoTiles.TabIndex = 2;
            btn_cutIntoTiles.Text = "Cut Into SuperTiles";
            btn_cutIntoTiles.UseVisualStyleBackColor = true;
            btn_cutIntoTiles.Click += btn_CutIntoTiles_Click;
            // 
            // btnQuantizeColours
            // 
            btnQuantizeColours.Location = new Point(558, 6);
            btnQuantizeColours.Name = "btnQuantizeColours";
            btnQuantizeColours.Size = new Size(294, 29);
            btnQuantizeColours.TabIndex = 3;
            btnQuantizeColours.Text = "Quantize images";
            btnQuantizeColours.UseVisualStyleBackColor = true;
            btnQuantizeColours.Click += btnQuantizeColours_Click;
            // 
            // btn_CommonTileCheck
            // 
            btn_CommonTileCheck.Location = new Point(889, 6);
            btn_CommonTileCheck.Name = "btn_CommonTileCheck";
            btn_CommonTileCheck.Size = new Size(193, 29);
            btn_CommonTileCheck.TabIndex = 4;
            btn_CommonTileCheck.Text = "Common tile check";
            btn_CommonTileCheck.UseVisualStyleBackColor = true;
            btn_CommonTileCheck.Click += btn_CommonTileCheck_Click;
            // 
            // btn_CreateTilesAndMapping8_8_Map
            // 
            btn_CreateTilesAndMapping8_8_Map.Location = new Point(1210, 6);
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
            panel2.Controls.Add(pct_OriginalTileBitmap);
            panel2.Controls.Add(btnExportTile_32_Tile_8);
            panel2.Location = new Point(1, 4);
            panel2.Name = "panel2";
            panel2.Size = new Size(250, 771);
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
            btnLoad_32_32_px_tilemap.Location = new Point(23, 312);
            btnLoad_32_32_px_tilemap.Name = "btnLoad_32_32_px_tilemap";
            btnLoad_32_32_px_tilemap.Size = new Size(189, 73);
            btnLoad_32_32_px_tilemap.TabIndex = 4;
            btnLoad_32_32_px_tilemap.Text = "Load 32_32_px_tilemap";
            btnLoad_32_32_px_tilemap.UseVisualStyleBackColor = true;
            btnLoad_32_32_px_tilemap.Click += btnLoad_32_32_px_tilemap_Click;
            // 
            // button3
            // 
            button3.Location = new Point(23, 190);
            button3.Name = "button3";
            button3.Size = new Size(163, 99);
            button3.TabIndex = 1;
            button3.Text = "Load defs";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.Location = new Point(23, 584);
            button2.Name = "button2";
            button2.Size = new Size(189, 110);
            button2.TabIndex = 9;
            button2.Text = "Save_32_32px tilemap";
            button2.UseVisualStyleBackColor = true;
            button2.Click += btn_Save32_32px_tilemap;
            // 
            // pct_OriginalTileBitmap
            // 
            pct_OriginalTileBitmap.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pct_OriginalTileBitmap.Location = new Point(2, 1);
            pct_OriginalTileBitmap.Name = "pct_OriginalTileBitmap";
            pct_OriginalTileBitmap.Size = new Size(245, 138);
            pct_OriginalTileBitmap.TabIndex = 0;
            pct_OriginalTileBitmap.TabStop = false;
            // 
            // btnExportTile_32_Tile_8
            // 
            btnExportTile_32_Tile_8.Enabled = false;
            btnExportTile_32_Tile_8.Location = new Point(23, 457);
            btnExportTile_32_Tile_8.Name = "btnExportTile_32_Tile_8";
            btnExportTile_32_Tile_8.Size = new Size(189, 121);
            btnExportTile_32_Tile_8.TabIndex = 7;
            btnExportTile_32_Tile_8.Text = "Export Maps and palette";
            btnExportTile_32_Tile_8.UseVisualStyleBackColor = true;
            btnExportTile_32_Tile_8.Click += btnExportTile_32_Tile_8_Click;
            // 
            // pnl_32_32_tiles
            // 
            pnl_32_32_tiles.Location = new Point(251, 3);
            pnl_32_32_tiles.Name = "pnl_32_32_tiles";
            pnl_32_32_tiles.Size = new Size(298, 140);
            pnl_32_32_tiles.TabIndex = 1;
            pnl_32_32_tiles.Paint += pnl_32_32_tiles_Paint;
            // 
            // pnl_QuantizedColour
            // 
            pnl_QuantizedColour.Location = new Point(555, 5);
            pnl_QuantizedColour.Name = "pnl_QuantizedColour";
            pnl_QuantizedColour.Size = new Size(323, 138);
            pnl_QuantizedColour.TabIndex = 2;
            pnl_QuantizedColour.Paint += pnl_QuantizedColour_Paint;
            // 
            // pnl_CommonTiles
            // 
            pnl_CommonTiles.Location = new Point(884, 5);
            pnl_CommonTiles.Name = "pnl_CommonTiles";
            pnl_CommonTiles.Size = new Size(323, 138);
            pnl_CommonTiles.TabIndex = 3;
            pnl_CommonTiles.Paint += pnl_CommonTiles_Paint;
            // 
            // pnl_fromActualTilemap
            // 
            pnl_fromActualTilemap.Location = new Point(1208, 4);
            pnl_fromActualTilemap.Name = "pnl_fromActualTilemap";
            pnl_fromActualTilemap.Size = new Size(323, 138);
            pnl_fromActualTilemap.TabIndex = 5;
            pnl_fromActualTilemap.Paint += pnl_fromActualTilemap_Paint;
            // 
            // pnl_32_32_TilePalette
            // 
            pnl_32_32_TilePalette.Location = new Point(1061, 161);
            pnl_32_32_TilePalette.Name = "pnl_32_32_TilePalette";
            pnl_32_32_TilePalette.Size = new Size(629, 505);
            pnl_32_32_TilePalette.TabIndex = 7;
            pnl_32_32_TilePalette.Paint += pnl_32_32_TilePalette_Paint;
            pnl_32_32_TilePalette.MouseDown += pnl_32_32_TilePalette_MouseDown;
            // 
            // panel3
            // 
            panel3.AutoScroll = true;
            panel3.Controls.Add(pnl_32x32_gauntletMap);
            panel3.Location = new Point(257, 147);
            panel3.Name = "panel3";
            panel3.Size = new Size(807, 568);
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
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(numMapHeight);
            panel1.Controls.Add(numMapWidth);
            panel1.Controls.Add(btnRightTile);
            panel1.Controls.Add(btnTileLeft);
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(pnl_32_32_TilePalette);
            panel1.Controls.Add(pnl_fromActualTilemap);
            panel1.Controls.Add(pnl_CommonTiles);
            panel1.Controls.Add(pnl_QuantizedColour);
            panel1.Controls.Add(pnl_32_32_tiles);
            panel1.Controls.Add(panel2);
            panel1.Location = new Point(2, 34);
            panel1.Name = "panel1";
            panel1.Size = new Size(1693, 778);
            panel1.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(1303, 682);
            label2.Name = "label2";
            label2.Size = new Size(54, 20);
            label2.TabIndex = 13;
            label2.Text = "Height";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(1158, 682);
            label1.Name = "label1";
            label1.Size = new Size(49, 20);
            label1.TabIndex = 13;
            label1.Text = "Width";
            // 
            // numMapHeight
            // 
            numMapHeight.Location = new Point(1363, 676);
            numMapHeight.Maximum = new decimal(new int[] { 4096, 0, 0, 0 });
            numMapHeight.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numMapHeight.Name = "numMapHeight";
            numMapHeight.Size = new Size(88, 27);
            numMapHeight.TabIndex = 12;
            numMapHeight.Value = new decimal(new int[] { 64, 0, 0, 0 });
            // 
            // numMapWidth
            // 
            numMapWidth.Location = new Point(1213, 676);
            numMapWidth.Maximum = new decimal(new int[] { 1024, 0, 0, 0 });
            numMapWidth.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numMapWidth.Name = "numMapWidth";
            numMapWidth.Size = new Size(88, 27);
            numMapWidth.TabIndex = 12;
            numMapWidth.Value = new decimal(new int[] { 64, 0, 0, 0 });
            // 
            // btnRightTile
            // 
            btnRightTile.Location = new Point(1577, 679);
            btnRightTile.Name = "btnRightTile";
            btnRightTile.Size = new Size(94, 37);
            btnRightTile.TabIndex = 11;
            btnRightTile.Text = ">>";
            btnRightTile.UseVisualStyleBackColor = true;
            btnRightTile.Click += btnRightTile_Click;
            // 
            // btnTileLeft
            // 
            btnTileLeft.Location = new Point(1457, 672);
            btnTileLeft.Name = "btnTileLeft";
            btnTileLeft.Size = new Size(97, 41);
            btnTileLeft.TabIndex = 10;
            btnTileLeft.Text = "<<";
            btnTileLeft.UseVisualStyleBackColor = true;
            btnTileLeft.Click += btnTileLeft_Click;
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
            Controls.Add(btn_CreateTilesAndMapping8_8_Map);
            Controls.Add(btn_CommonTileCheck);
            Controls.Add(btnQuantizeColours);
            Controls.Add(btn_cutIntoTiles);
            Controls.Add(panel1);
            Controls.Add(btnLoadImage);
            Name = "tile32PixImport";
            Size = new Size(1698, 749);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pct_OriginalTileBitmap).EndInit();
            panel3.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
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
    }
}
