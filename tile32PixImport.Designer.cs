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
            button1 = new Button();
            btnQuantizeColours = new Button();
            btn_CommonTileCheck = new Button();
            btn_CreateTilesAndMapping8_8_Map = new Button();
            panel2 = new DBPanel();
            btnLoad_32_32_px_tilemap = new Button();
            button3 = new Button();
            pct_OriginalTileBitmap = new PictureBox();
            pnl_32_32_tiles = new DBPanel();
            pnl_QuantizedColour = new DBPanel();
            pnl_CommonTiles = new DBPanel();
            pnl_fromActualTilemap = new DBPanel();
            btnExportTile_32_Tile_8 = new Button();
            pnl_32_32_TilePalette = new DBPanel();
            panel3 = new Panel();
            pnl_32x32_gauntletMap = new DBPanel();
            panel1 = new Panel();
            btnRightTile = new Button();
            btnTileLeft = new Button();
            button2 = new Button();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pct_OriginalTileBitmap).BeginInit();
            panel3.SuspendLayout();
            panel1.SuspendLayout();
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
            // button1
            // 
            button1.Location = new Point(252, 2);
            button1.Name = "button1";
            button1.Size = new Size(141, 29);
            button1.TabIndex = 2;
            button1.Text = "Cut Into 32x32";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
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
            panel2.Controls.Add(btnLoad_32_32_px_tilemap);
            panel2.Controls.Add(button3);
            panel2.Controls.Add(pct_OriginalTileBitmap);
            panel2.Location = new Point(1, 4);
            panel2.Name = "panel2";
            panel2.Size = new Size(250, 705);
            panel2.TabIndex = 0;
            // 
            // btnLoad_32_32_px_tilemap
            // 
            btnLoad_32_32_px_tilemap.Location = new Point(28, 537);
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
            // pct_OriginalTileBitmap
            // 
            pct_OriginalTileBitmap.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pct_OriginalTileBitmap.Location = new Point(2, 1);
            pct_OriginalTileBitmap.Name = "pct_OriginalTileBitmap";
            pct_OriginalTileBitmap.Size = new Size(245, 138);
            pct_OriginalTileBitmap.TabIndex = 0;
            pct_OriginalTileBitmap.TabStop = false;
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
            // btnExportTile_32_Tile_8
            // 
            btnExportTile_32_Tile_8.Enabled = false;
            btnExportTile_32_Tile_8.Location = new Point(1070, 453);
            btnExportTile_32_Tile_8.Name = "btnExportTile_32_Tile_8";
            btnExportTile_32_Tile_8.Size = new Size(280, 121);
            btnExportTile_32_Tile_8.TabIndex = 7;
            btnExportTile_32_Tile_8.Text = "Export Maps and palette";
            btnExportTile_32_Tile_8.UseVisualStyleBackColor = true;
            btnExportTile_32_Tile_8.Click += btnExportTile_32_Tile_8_Click;
            // 
            // pnl_32_32_TilePalette
            // 
            pnl_32_32_TilePalette.Location = new Point(1061, 161);
            pnl_32_32_TilePalette.Name = "pnl_32_32_TilePalette";
            pnl_32_32_TilePalette.Size = new Size(629, 286);
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
            pnl_32x32_gauntletMap.Paint += pnl_32x32_gauntletMap_Paint;
            pnl_32x32_gauntletMap.MouseDown += panel7_MouseDown;
            pnl_32x32_gauntletMap.MouseMove += panel7_MouseMove;
            pnl_32x32_gauntletMap.MouseUp += panel7_MouseUp;
            // 
            // panel1
            // 
            panel1.Controls.Add(btnRightTile);
            panel1.Controls.Add(btnTileLeft);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(pnl_32_32_TilePalette);
            panel1.Controls.Add(btnExportTile_32_Tile_8);
            panel1.Controls.Add(pnl_fromActualTilemap);
            panel1.Controls.Add(pnl_CommonTiles);
            panel1.Controls.Add(pnl_QuantizedColour);
            panel1.Controls.Add(pnl_32_32_tiles);
            panel1.Controls.Add(panel2);
            panel1.Location = new Point(2, 34);
            panel1.Name = "panel1";
            panel1.Size = new Size(1693, 712);
            panel1.TabIndex = 1;
            // 
            // btnRightTile
            // 
            btnRightTile.Location = new Point(1490, 472);
            btnRightTile.Name = "btnRightTile";
            btnRightTile.Size = new Size(94, 91);
            btnRightTile.TabIndex = 11;
            btnRightTile.Text = ">>";
            btnRightTile.UseVisualStyleBackColor = true;
            btnRightTile.Click += btnRightTile_Click;
            // 
            // btnTileLeft
            // 
            btnTileLeft.Location = new Point(1370, 472);
            btnTileLeft.Name = "btnTileLeft";
            btnTileLeft.Size = new Size(97, 91);
            btnTileLeft.TabIndex = 10;
            btnTileLeft.Text = "<<";
            btnTileLeft.UseVisualStyleBackColor = true;
            btnTileLeft.Click += btnTileLeft_Click;
            // 
            // button2
            // 
            button2.Location = new Point(1070, 580);
            button2.Name = "button2";
            button2.Size = new Size(280, 110);
            button2.TabIndex = 9;
            button2.Text = "Save_32_32px tilemap";
            button2.UseVisualStyleBackColor = true;
            button2.Click += btn_Save32_32px_tilemap;
            // 
            // tile32PixImport
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btn_CreateTilesAndMapping8_8_Map);
            Controls.Add(btn_CommonTileCheck);
            Controls.Add(btnQuantizeColours);
            Controls.Add(button1);
            Controls.Add(panel1);
            Controls.Add(btnLoadImage);
            Name = "tile32PixImport";
            Size = new Size(1698, 749);
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pct_OriginalTileBitmap).EndInit();
            panel3.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Button btnLoadImage;
        private Button button1;
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
    }
}
