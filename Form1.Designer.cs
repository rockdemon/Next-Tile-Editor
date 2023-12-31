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
            paletteValue9bit paletteValue9bit1 = new paletteValue9bit();
            paletteValue9bit paletteValue9bit2 = new paletteValue9bit();
            NextPalette = new NextPaletteColourPicker();
            tab32pixtileImport = new TabControl();
            tabPage1 = new TabPage();
            panel1 = new Panel();
            button4 = new Button();
            btnQuantizeImages = new Button();
            label1 = new Label();
            btnSaveAsNextFormat = new Button();
            btnSaveAsPNG = new Button();
            btnImportFromNext = new Button();
            btnImportFromPNG = new Button();
            numSpritePaletteOffset = new NumericUpDown();
            SpritePaletteInkAndPaperPicker = new PalettePicker();
            btnWriteToSprite = new Button();
            numSpriteNum = new NumericUpDown();
            spriteEditor1 = new SpriteEditor();
            pnlSprites = new Panel();
            TileEditor = new TabPage();
            button6 = new Button();
            button3 = new Button();
            label3 = new Label();
            label2 = new Label();
            numHeight = new NumericUpDown();
            numWidth = new NumericUpDown();
            btnSavePalette = new Button();
            btnSaveTiles = new Button();
            btnSaveTileMap = new Button();
            btnLoadPalette = new Button();
            button1 = new Button();
            btnLoadTileMap = new Button();
            panelParent = new Panel();
            pnlTileMap = new Panel();
            button2 = new Button();
            numericUpDown1 = new NumericUpDown();
            tileEditor1 = new TileEditor();
            panel3 = new Panel();
            TilemapPaletteInkAndPaperPicker = new PalettePicker();
            pnlTilePalette = new Panel();
            tabPage2 = new TabPage();
            tile32PixImport1 = new tile32PixImport();
            tab32pixtileImport.SuspendLayout();
            tabPage1.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numSpritePaletteOffset).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numSpriteNum).BeginInit();
            TileEditor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numHeight).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numWidth).BeginInit();
            panelParent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            panel3.SuspendLayout();
            tabPage2.SuspendLayout();
            SuspendLayout();
            // 
            // NextPalette
            // 
            NextPalette.BorderStyle = BorderStyle.FixedSingle;
            paletteValue9bit1.Blue = 0;
            paletteValue9bit1.Green = 0;
            paletteValue9bit1.Red = 0;
            NextPalette.Ink9bit = paletteValue9bit1;
            NextPalette.InkIndex = 0;
            NextPalette.Location = new Point(1428, 41);
            NextPalette.Name = "NextPalette";
            NextPalette.Palette = null;
            paletteValue9bit2.Blue = 7;
            paletteValue9bit2.Green = 7;
            paletteValue9bit2.Red = 7;
            NextPalette.Paper9bit = paletteValue9bit2;
            NextPalette.PaperIndex = 0;
            NextPalette.ScaleVal = 0;
            NextPalette.Size = new Size(128, 696);
            NextPalette.TabIndex = 12;
            // 
            // tab32pixtileImport
            // 
            tab32pixtileImport.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tab32pixtileImport.Controls.Add(tabPage1);
            tab32pixtileImport.Controls.Add(TileEditor);
            tab32pixtileImport.Controls.Add(tabPage2);
            tab32pixtileImport.Location = new Point(2, 27);
            tab32pixtileImport.Name = "tab32pixtileImport";
            tab32pixtileImport.SelectedIndex = 0;
            tab32pixtileImport.Size = new Size(1809, 994);
            tab32pixtileImport.TabIndex = 7;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(panel1);
            tabPage1.Controls.Add(numSpritePaletteOffset);
            tabPage1.Controls.Add(SpritePaletteInkAndPaperPicker);
            tabPage1.Controls.Add(btnWriteToSprite);
            tabPage1.Controls.Add(numSpriteNum);
            tabPage1.Controls.Add(spriteEditor1);
            tabPage1.Controls.Add(pnlSprites);
            tabPage1.Location = new Point(4, 29);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1801, 961);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Sprite Import";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.Controls.Add(button4);
            panel1.Controls.Add(btnQuantizeImages);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(btnSaveAsNextFormat);
            panel1.Controls.Add(btnSaveAsPNG);
            panel1.Controls.Add(btnImportFromNext);
            panel1.Controls.Add(btnImportFromPNG);
            panel1.Location = new Point(488, 835);
            panel1.Name = "panel1";
            panel1.Size = new Size(965, 37);
            panel1.TabIndex = 6;
            // 
            // button4
            // 
            button4.Location = new Point(735, 4);
            button4.Name = "button4";
            button4.Size = new Size(99, 29);
            button4.TabIndex = 38;
            button4.Text = "Load Palette";
            button4.UseVisualStyleBackColor = true;
            button4.Click += btnLoadSpritePalette_Click;
            // 
            // btnQuantizeImages
            // 
            btnQuantizeImages.Location = new Point(435, 5);
            btnQuantizeImages.Name = "btnQuantizeImages";
            btnQuantizeImages.Size = new Size(94, 29);
            btnQuantizeImages.TabIndex = 37;
            btnQuantizeImages.Text = "Quantize";
            btnQuantizeImages.UseVisualStyleBackColor = true;
            btnQuantizeImages.Click += btnQuantizeImages_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(378, 8);
            label1.Name = "label1";
            label1.Size = new Size(50, 20);
            label1.TabIndex = 36;
            label1.Text = "label1";
            // 
            // btnSaveAsNextFormat
            // 
            btnSaveAsNextFormat.Location = new Point(635, 2);
            btnSaveAsNextFormat.Name = "btnSaveAsNextFormat";
            btnSaveAsNextFormat.Size = new Size(94, 29);
            btnSaveAsNextFormat.TabIndex = 35;
            btnSaveAsNextFormat.Text = "Next Save";
            btnSaveAsNextFormat.UseVisualStyleBackColor = true;
            btnSaveAsNextFormat.Click += btnSaveAsNextFormat_Click;
            // 
            // btnSaveAsPNG
            // 
            btnSaveAsPNG.Location = new Point(535, 2);
            btnSaveAsPNG.Name = "btnSaveAsPNG";
            btnSaveAsPNG.Size = new Size(94, 29);
            btnSaveAsPNG.TabIndex = 34;
            btnSaveAsPNG.Text = "PNG Save";
            btnSaveAsPNG.UseVisualStyleBackColor = true;
            btnSaveAsPNG.Click += btnSaveAsPNG_Click;
            // 
            // btnImportFromNext
            // 
            btnImportFromNext.Location = new Point(257, 2);
            btnImportFromNext.Name = "btnImportFromNext";
            btnImportFromNext.Size = new Size(115, 29);
            btnImportFromNext.TabIndex = 33;
            btnImportFromNext.Text = "Next Import";
            btnImportFromNext.UseVisualStyleBackColor = true;
            btnImportFromNext.Click += btnImportFromNext_Click;
            // 
            // btnImportFromPNG
            // 
            btnImportFromPNG.Location = new Point(130, 2);
            btnImportFromPNG.Name = "btnImportFromPNG";
            btnImportFromPNG.Size = new Size(121, 29);
            btnImportFromPNG.TabIndex = 32;
            btnImportFromPNG.Text = "PNG Import";
            btnImportFromPNG.UseVisualStyleBackColor = true;
            btnImportFromPNG.Click += btnImportFromPNG_Click;
            // 
            // numSpritePaletteOffset
            // 
            numSpritePaletteOffset.Location = new Point(332, 835);
            numSpritePaletteOffset.Name = "numSpritePaletteOffset";
            numSpritePaletteOffset.Size = new Size(150, 27);
            numSpritePaletteOffset.TabIndex = 5;
            numSpritePaletteOffset.ValueChanged += numSpritePaletteOffset_ValueChanged;
            // 
            // SpritePaletteInkAndPaperPicker
            // 
            SpritePaletteInkAndPaperPicker.Location = new Point(333, 479);
            SpritePaletteInkAndPaperPicker.Name = "SpritePaletteInkAndPaperPicker";
            SpritePaletteInkAndPaperPicker.pal = null;
            SpritePaletteInkAndPaperPicker.Size = new Size(433, 348);
            SpritePaletteInkAndPaperPicker.TabIndex = 4;
            SpritePaletteInkAndPaperPicker.InkColourChanged += SpritePaletteInkAndPaperPicker_InkColourChanged;
            SpritePaletteInkAndPaperPicker.PaperColourChanged += SpritePaletteInkAndPaperPicker_PaperColourChanged;
            // 
            // btnWriteToSprite
            // 
            btnWriteToSprite.Location = new Point(1531, 562);
            btnWriteToSprite.Name = "btnWriteToSprite";
            btnWriteToSprite.Size = new Size(168, 88);
            btnWriteToSprite.TabIndex = 3;
            btnWriteToSprite.Text = "^\r\n||\r\nWrite To Sprite\r\n";
            btnWriteToSprite.UseVisualStyleBackColor = true;
            btnWriteToSprite.Click += btnWriteToSprite_Click;
            // 
            // numSpriteNum
            // 
            numSpriteNum.Location = new Point(1531, 656);
            numSpriteNum.Name = "numSpriteNum";
            numSpriteNum.Size = new Size(150, 27);
            numSpriteNum.TabIndex = 2;
            // 
            // spriteEditor1
            // 
            spriteEditor1.InkIdx = 0;
            spriteEditor1.Location = new Point(10, 482);
            spriteEditor1.Name = "spriteEditor1";
            spriteEditor1.Palette = null;
            spriteEditor1.PaperIdx = 15;
            spriteEditor1.Size = new Size(304, 300);
            spriteEditor1.Sprite = null;
            spriteEditor1.TabIndex = 1;
            // 
            // pnlSprites
            // 
            pnlSprites.Location = new Point(0, 3);
            pnlSprites.Name = "pnlSprites";
            pnlSprites.Size = new Size(1798, 470);
            pnlSprites.TabIndex = 0;
            // 
            // TileEditor
            // 
            TileEditor.Controls.Add(button6);
            TileEditor.Controls.Add(button3);
            TileEditor.Controls.Add(label3);
            TileEditor.Controls.Add(label2);
            TileEditor.Controls.Add(numHeight);
            TileEditor.Controls.Add(numWidth);
            TileEditor.Controls.Add(btnSavePalette);
            TileEditor.Controls.Add(btnSaveTiles);
            TileEditor.Controls.Add(btnSaveTileMap);
            TileEditor.Controls.Add(btnLoadPalette);
            TileEditor.Controls.Add(button1);
            TileEditor.Controls.Add(btnLoadTileMap);
            TileEditor.Controls.Add(panelParent);
            TileEditor.Controls.Add(button2);
            TileEditor.Controls.Add(numericUpDown1);
            TileEditor.Controls.Add(tileEditor1);
            TileEditor.Controls.Add(NextPalette);
            TileEditor.Controls.Add(panel3);
            TileEditor.Location = new Point(4, 29);
            TileEditor.Name = "TileEditor";
            TileEditor.Padding = new Padding(3);
            TileEditor.Size = new Size(1801, 961);
            TileEditor.TabIndex = 1;
            TileEditor.Text = "Tile Editor";
            TileEditor.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            button6.Location = new Point(9, 6);
            button6.Name = "button6";
            button6.Size = new Size(311, 29);
            button6.TabIndex = 42;
            button6.Text = "LoadTileMap";
            button6.UseVisualStyleBackColor = true;
            button6.Click += btn_ImportImageAndCreateTiles;
            // 
            // button3
            // 
            button3.Location = new Point(658, 0);
            button3.Name = "button3";
            button3.Size = new Size(58, 29);
            button3.TabIndex = 41;
            button3.Text = "New";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(540, 4);
            label3.Name = "label3";
            label3.Size = new Size(54, 20);
            label3.TabIndex = 40;
            label3.Text = "Height";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(424, 3);
            label2.Name = "label2";
            label2.Size = new Size(46, 20);
            label2.TabIndex = 39;
            label2.Text = "width";
            // 
            // numHeight
            // 
            numHeight.Location = new Point(592, 0);
            numHeight.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numHeight.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numHeight.Name = "numHeight";
            numHeight.Size = new Size(63, 27);
            numHeight.TabIndex = 38;
            numHeight.Value = new decimal(new int[] { 32, 0, 0, 0 });
            // 
            // numWidth
            // 
            numWidth.Location = new Point(476, 0);
            numWidth.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numWidth.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numWidth.Name = "numWidth";
            numWidth.Size = new Size(63, 27);
            numWidth.TabIndex = 37;
            numWidth.Value = new decimal(new int[] { 40, 0, 0, 0 });
            // 
            // btnSavePalette
            // 
            btnSavePalette.Location = new Point(1210, 0);
            btnSavePalette.Name = "btnSavePalette";
            btnSavePalette.Size = new Size(97, 29);
            btnSavePalette.TabIndex = 36;
            btnSavePalette.Text = "Save Palette";
            btnSavePalette.UseVisualStyleBackColor = true;
            btnSavePalette.Click += btnSavePalette_Click;
            // 
            // btnSaveTiles
            // 
            btnSaveTiles.Location = new Point(1124, 0);
            btnSaveTiles.Name = "btnSaveTiles";
            btnSaveTiles.Size = new Size(84, 29);
            btnSaveTiles.TabIndex = 35;
            btnSaveTiles.Text = "Save Tiles";
            btnSaveTiles.UseVisualStyleBackColor = true;
            btnSaveTiles.Click += btnSaveTiles_Click;
            // 
            // btnSaveTileMap
            // 
            btnSaveTileMap.Location = new Point(1018, 0);
            btnSaveTileMap.Name = "btnSaveTileMap";
            btnSaveTileMap.Size = new Size(102, 29);
            btnSaveTileMap.TabIndex = 34;
            btnSaveTileMap.Text = "SaveTileMap";
            btnSaveTileMap.UseVisualStyleBackColor = true;
            btnSaveTileMap.Click += btnSaveTileMap_Click;
            // 
            // btnLoadPalette
            // 
            btnLoadPalette.Location = new Point(913, 0);
            btnLoadPalette.Name = "btnLoadPalette";
            btnLoadPalette.Size = new Size(99, 29);
            btnLoadPalette.TabIndex = 33;
            btnLoadPalette.Text = "Load Palette";
            btnLoadPalette.UseVisualStyleBackColor = true;
            btnLoadPalette.Click += btnLoadPalette_Click;
            // 
            // button1
            // 
            button1.Location = new Point(828, 0);
            button1.Name = "button1";
            button1.Size = new Size(80, 29);
            button1.TabIndex = 31;
            button1.Text = "LoadTiles";
            button1.UseVisualStyleBackColor = true;
            button1.Click += btnLoadTiles_Click;
            // 
            // btnLoadTileMap
            // 
            btnLoadTileMap.Location = new Point(722, 0);
            btnLoadTileMap.Name = "btnLoadTileMap";
            btnLoadTileMap.Size = new Size(104, 29);
            btnLoadTileMap.TabIndex = 32;
            btnLoadTileMap.Text = "LoadTileMap";
            btnLoadTileMap.UseVisualStyleBackColor = true;
            btnLoadTileMap.Click += btnLoadTileMap_Click;
            // 
            // panelParent
            // 
            panelParent.AutoScroll = true;
            panelParent.Controls.Add(pnlTileMap);
            panelParent.Location = new Point(6, 41);
            panelParent.MaximumSize = new Size(1123, 800);
            panelParent.Name = "panelParent";
            panelParent.Size = new Size(1115, 800);
            panelParent.TabIndex = 6;
            // 
            // pnlTileMap
            // 
            pnlTileMap.Location = new Point(0, 0);
            pnlTileMap.MaximumSize = new Size(1280, 8192);
            pnlTileMap.Name = "pnlTileMap";
            pnlTileMap.Size = new Size(1280, 8192);
            pnlTileMap.TabIndex = 4;
            // 
            // button2
            // 
            button2.Location = new Point(1578, 429);
            button2.Name = "button2";
            button2.Size = new Size(91, 36);
            button2.TabIndex = 17;
            button2.Text = "SaveTile";
            button2.UseVisualStyleBackColor = true;
            button2.Click += btnSaveTileDef;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(1578, 367);
            numericUpDown1.Maximum = new decimal(new int[] { 15, 0, 0, 0 });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(120, 27);
            numericUpDown1.TabIndex = 15;
            numericUpDown1.ValueChanged += numericUpDown1_ValueChanged;
            // 
            // tileEditor1
            // 
            tileEditor1.Ink = null;
            tileEditor1.InkVal = 0;
            tileEditor1.Location = new Point(1578, 41);
            tileEditor1.Name = "tileEditor1";
            tileEditor1.palette = null;
            tileEditor1.PaletteOffset = 0;
            tileEditor1.Paper = null;
            tileEditor1.PaperVal = 0;
            tileEditor1.Size = new Size(256, 320);
            tileEditor1.TabIndex = 13;
            tileEditor1.Tile = null;
            // 
            // panel3
            // 
            panel3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel3.Controls.Add(TilemapPaletteInkAndPaperPicker);
            panel3.Controls.Add(pnlTilePalette);
            panel3.Location = new Point(1138, 41);
            panel3.MaximumSize = new Size(272, 696);
            panel3.MinimumSize = new Size(272, 696);
            panel3.Name = "panel3";
            panel3.Size = new Size(272, 696);
            panel3.TabIndex = 10;
            // 
            // TilemapPaletteInkAndPaperPicker
            // 
            TilemapPaletteInkAndPaperPicker.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            TilemapPaletteInkAndPaperPicker.BackColor = Color.RosyBrown;
            TilemapPaletteInkAndPaperPicker.Location = new Point(143, 0);
            TilemapPaletteInkAndPaperPicker.Name = "TilemapPaletteInkAndPaperPicker";
            TilemapPaletteInkAndPaperPicker.pal = null;
            TilemapPaletteInkAndPaperPicker.Size = new Size(128, 696);
            TilemapPaletteInkAndPaperPicker.TabIndex = 10;
            // 
            // pnlTilePalette
            // 
            pnlTilePalette.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            pnlTilePalette.BackColor = Color.LightGray;
            pnlTilePalette.Location = new Point(0, 0);
            pnlTilePalette.Name = "pnlTilePalette";
            pnlTilePalette.Size = new Size(128, 696);
            pnlTilePalette.TabIndex = 9;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(tile32PixImport1);
            tabPage2.Location = new Point(4, 29);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1801, 961);
            tabPage2.TabIndex = 2;
            tabPage2.Text = "Import 4x4 Tiles";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // tile32PixImport1
            // 
            tile32PixImport1.Dock = DockStyle.Fill;
            tile32PixImport1.Location = new Point(3, 3);
            tile32PixImport1.Name = "tile32PixImport1";
            tile32PixImport1.Size = new Size(1795, 955);
            tile32PixImport1.TabIndex = 0;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1864, 1033);
            Controls.Add(tab32pixtileImport);
            Name = "Form1";
            Text = "Form1";
            tab32pixtileImport.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numSpritePaletteOffset).EndInit();
            ((System.ComponentModel.ISupportInitialize)numSpriteNum).EndInit();
            TileEditor.ResumeLayout(false);
            TileEditor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numHeight).EndInit();
            ((System.ComponentModel.ISupportInitialize)numWidth).EndInit();
            panelParent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            panel3.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private TabControl tab32pixtileImport;
        private TabPage tabPage1;
        private TabPage TileEditor;
        private Panel panelParent;
        private Panel pnlTileMap;
        private Panel panel2;
        private Panel panel3;
        public PalettePicker TilemapPaletteInkAndPaperPicker;
        public Panel pnlTilePalette;
        private TileEditor tileEditor1;
        private NumericUpDown numericUpDown1;
        private Button button2;
        private Panel pnlSprites;
        private SpriteEditor spriteEditor1;
        private Button button5;
        private NumericUpDown numSpriteNum;
        private PalettePicker SpritePaletteInkAndPaperPicker;
        private Button btnWriteToSprite;
        private NumericUpDown numSpritePaletteOffset;
        private Panel panel1;
        private Button button4;
        private Button btnQuantizeImages;
        private Label label1;
        private Button btnSaveAsNextFormat;
        private Button btnSaveAsPNG;
        private Button btnImportFromNext;
        private Button btnImportFromPNG;
        private Button button3;
        private Label label3;
        private Label label2;
        private NumericUpDown numHeight;
        private NumericUpDown numWidth;
        private Button btnSavePalette;
        private Button btnSaveTiles;
        private Button btnSaveTileMap;
        private Button btnLoadPalette;
        private Button button1;
        private Button btnLoadTileMap;
        private Button button6;
        private TabPage tabPage2;
        private tile32PixImport tile32PixImport1;
    }
}