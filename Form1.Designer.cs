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
            Next_tile_editor.paletteValue9bit paletteValue9bit3 = new Next_tile_editor.paletteValue9bit();
            Next_tile_editor.paletteValue9bit paletteValue9bit4 = new Next_tile_editor.paletteValue9bit();
            this.NextPalette = new Next_tile_editor.NextPaletteColourPicker();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button4 = new System.Windows.Forms.Button();
            this.btnQuantizeImages = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSaveAsNextFormat = new System.Windows.Forms.Button();
            this.btnSaveAsPNG = new System.Windows.Forms.Button();
            this.btnImportFromNext = new System.Windows.Forms.Button();
            this.btnImportFromPNG = new System.Windows.Forms.Button();
            this.numSpritePaletteOffset = new System.Windows.Forms.NumericUpDown();
            this.SpritePaletteInkAndPaperPicker = new Next_tile_editor.PalettePicker();
            this.btnWriteToSprite = new System.Windows.Forms.Button();
            this.numSpriteNum = new System.Windows.Forms.NumericUpDown();
            this.spriteEditor1 = new Next_tile_editor.SpriteEditor();
            this.pnlSprites = new System.Windows.Forms.Panel();
            this.TileEditor = new System.Windows.Forms.TabPage();
            this.button3 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numHeight = new System.Windows.Forms.NumericUpDown();
            this.numWidth = new System.Windows.Forms.NumericUpDown();
            this.btnSavePalette = new System.Windows.Forms.Button();
            this.btnSaveTiles = new System.Windows.Forms.Button();
            this.btnSaveTileMap = new System.Windows.Forms.Button();
            this.btnLoadPalette = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnLoadTileMap = new System.Windows.Forms.Button();
            this.panelParent = new System.Windows.Forms.Panel();
            this.pnlTileMap = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.tileEditor1 = new Next_tile_editor.TileEditor();
            this.panel3 = new System.Windows.Forms.Panel();
            this.TilemapPaletteInkAndPaperPicker = new Next_tile_editor.PalettePicker();
            this.pnlTilePalette = new System.Windows.Forms.Panel();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSpritePaletteOffset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSpriteNum)).BeginInit();
            this.TileEditor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWidth)).BeginInit();
            this.panelParent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // NextPalette
            // 
            this.NextPalette.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            paletteValue9bit3.Blue = ((byte)(0));
            paletteValue9bit3.Green = ((byte)(0));
            paletteValue9bit3.Red = ((byte)(0));
            this.NextPalette.Ink9bit = paletteValue9bit3;
            this.NextPalette.InkIndex = 0;
            this.NextPalette.Location = new System.Drawing.Point(1428, 41);
            this.NextPalette.Name = "NextPalette";
            this.NextPalette.Palette = null;
            paletteValue9bit4.Blue = ((byte)(7));
            paletteValue9bit4.Green = ((byte)(7));
            paletteValue9bit4.Red = ((byte)(7));
            this.NextPalette.Paper9bit = paletteValue9bit4;
            this.NextPalette.PaperIndex = 0;
            this.NextPalette.ScaleVal = 0;
            this.NextPalette.Size = new System.Drawing.Size(128, 696);
            this.NextPalette.TabIndex = 12;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.TileEditor);
            this.tabControl1.Location = new System.Drawing.Point(2, 27);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1809, 994);
            this.tabControl1.TabIndex = 7;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Controls.Add(this.numSpritePaletteOffset);
            this.tabPage1.Controls.Add(this.SpritePaletteInkAndPaperPicker);
            this.tabPage1.Controls.Add(this.btnWriteToSprite);
            this.tabPage1.Controls.Add(this.numSpriteNum);
            this.tabPage1.Controls.Add(this.spriteEditor1);
            this.tabPage1.Controls.Add(this.pnlSprites);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1801, 961);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Sprite Import";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.btnQuantizeImages);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnSaveAsNextFormat);
            this.panel1.Controls.Add(this.btnSaveAsPNG);
            this.panel1.Controls.Add(this.btnImportFromNext);
            this.panel1.Controls.Add(this.btnImportFromPNG);
            this.panel1.Location = new System.Drawing.Point(488, 835);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(965, 37);
            this.panel1.TabIndex = 6;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(735, 4);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(99, 29);
            this.button4.TabIndex = 38;
            this.button4.Text = "Load Palette";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.btnLoadSpritePalette_Click);
            // 
            // btnQuantizeImages
            // 
            this.btnQuantizeImages.Location = new System.Drawing.Point(435, 5);
            this.btnQuantizeImages.Name = "btnQuantizeImages";
            this.btnQuantizeImages.Size = new System.Drawing.Size(94, 29);
            this.btnQuantizeImages.TabIndex = 37;
            this.btnQuantizeImages.Text = "Quantize";
            this.btnQuantizeImages.UseVisualStyleBackColor = true;
            this.btnQuantizeImages.Click += new System.EventHandler(this.btnQuantizeImages_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(378, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 20);
            this.label1.TabIndex = 36;
            this.label1.Text = "label1";
            // 
            // btnSaveAsNextFormat
            // 
            this.btnSaveAsNextFormat.Location = new System.Drawing.Point(635, 2);
            this.btnSaveAsNextFormat.Name = "btnSaveAsNextFormat";
            this.btnSaveAsNextFormat.Size = new System.Drawing.Size(94, 29);
            this.btnSaveAsNextFormat.TabIndex = 35;
            this.btnSaveAsNextFormat.Text = "Next Save";
            this.btnSaveAsNextFormat.UseVisualStyleBackColor = true;
            this.btnSaveAsNextFormat.Click += new System.EventHandler(this.btnSaveAsNextFormat_Click);
            // 
            // btnSaveAsPNG
            // 
            this.btnSaveAsPNG.Location = new System.Drawing.Point(535, 2);
            this.btnSaveAsPNG.Name = "btnSaveAsPNG";
            this.btnSaveAsPNG.Size = new System.Drawing.Size(94, 29);
            this.btnSaveAsPNG.TabIndex = 34;
            this.btnSaveAsPNG.Text = "PNG Save";
            this.btnSaveAsPNG.UseVisualStyleBackColor = true;
            this.btnSaveAsPNG.Click += new System.EventHandler(this.btnSaveAsPNG_Click);
            // 
            // btnImportFromNext
            // 
            this.btnImportFromNext.Location = new System.Drawing.Point(257, 2);
            this.btnImportFromNext.Name = "btnImportFromNext";
            this.btnImportFromNext.Size = new System.Drawing.Size(115, 29);
            this.btnImportFromNext.TabIndex = 33;
            this.btnImportFromNext.Text = "Next Import";
            this.btnImportFromNext.UseVisualStyleBackColor = true;
            this.btnImportFromNext.Click += new System.EventHandler(this.btnImportFromNext_Click);
            // 
            // btnImportFromPNG
            // 
            this.btnImportFromPNG.Location = new System.Drawing.Point(130, 2);
            this.btnImportFromPNG.Name = "btnImportFromPNG";
            this.btnImportFromPNG.Size = new System.Drawing.Size(121, 29);
            this.btnImportFromPNG.TabIndex = 32;
            this.btnImportFromPNG.Text = "PNG Import";
            this.btnImportFromPNG.UseVisualStyleBackColor = true;
            this.btnImportFromPNG.Click += new System.EventHandler(this.btnImportFromPNG_Click);
            // 
            // numSpritePaletteOffset
            // 
            this.numSpritePaletteOffset.Location = new System.Drawing.Point(332, 835);
            this.numSpritePaletteOffset.Name = "numSpritePaletteOffset";
            this.numSpritePaletteOffset.Size = new System.Drawing.Size(150, 27);
            this.numSpritePaletteOffset.TabIndex = 5;
            this.numSpritePaletteOffset.ValueChanged += new System.EventHandler(this.numSpritePaletteOffset_ValueChanged);
            // 
            // SpritePaletteInkAndPaperPicker
            // 
            this.SpritePaletteInkAndPaperPicker.Location = new System.Drawing.Point(333, 479);
            this.SpritePaletteInkAndPaperPicker.Name = "SpritePaletteInkAndPaperPicker";
            this.SpritePaletteInkAndPaperPicker.pal = null;
            this.SpritePaletteInkAndPaperPicker.Size = new System.Drawing.Size(433, 348);
            this.SpritePaletteInkAndPaperPicker.TabIndex = 4;
            this.SpritePaletteInkAndPaperPicker.InkColourChanged += new Next_tile_editor.PalettePicker.InkColourChangedEventHandler(this.SpritePaletteInkAndPaperPicker_InkColourChanged);
            this.SpritePaletteInkAndPaperPicker.PaperColourChanged += new Next_tile_editor.PalettePicker.PaperColourChangedEventHandler(this.SpritePaletteInkAndPaperPicker_PaperColourChanged);
            // 
            // btnWriteToSprite
            // 
            this.btnWriteToSprite.Location = new System.Drawing.Point(1531, 562);
            this.btnWriteToSprite.Name = "btnWriteToSprite";
            this.btnWriteToSprite.Size = new System.Drawing.Size(168, 88);
            this.btnWriteToSprite.TabIndex = 3;
            this.btnWriteToSprite.Text = "^\r\n||\r\nWrite To Sprite\r\n";
            this.btnWriteToSprite.UseVisualStyleBackColor = true;
            this.btnWriteToSprite.Click += new System.EventHandler(this.btnWriteToSprite_Click);
            // 
            // numSpriteNum
            // 
            this.numSpriteNum.Location = new System.Drawing.Point(1531, 656);
            this.numSpriteNum.Name = "numSpriteNum";
            this.numSpriteNum.Size = new System.Drawing.Size(150, 27);
            this.numSpriteNum.TabIndex = 2;
            // 
            // spriteEditor1
            // 
            this.spriteEditor1.InkIdx = 0;
            this.spriteEditor1.Location = new System.Drawing.Point(10, 482);
            this.spriteEditor1.Name = "spriteEditor1";
            this.spriteEditor1.Palette = null;
            this.spriteEditor1.PaperIdx = 15;
            this.spriteEditor1.Size = new System.Drawing.Size(304, 300);
            this.spriteEditor1.Sprite = null;
            this.spriteEditor1.TabIndex = 1;
            // 
            // pnlSprites
            // 
            this.pnlSprites.Location = new System.Drawing.Point(0, 3);
            this.pnlSprites.Name = "pnlSprites";
            this.pnlSprites.Size = new System.Drawing.Size(1798, 470);
            this.pnlSprites.TabIndex = 0;
            // 
            // TileEditor
            // 
            this.TileEditor.Controls.Add(this.button3);
            this.TileEditor.Controls.Add(this.label3);
            this.TileEditor.Controls.Add(this.label2);
            this.TileEditor.Controls.Add(this.numHeight);
            this.TileEditor.Controls.Add(this.numWidth);
            this.TileEditor.Controls.Add(this.btnSavePalette);
            this.TileEditor.Controls.Add(this.btnSaveTiles);
            this.TileEditor.Controls.Add(this.btnSaveTileMap);
            this.TileEditor.Controls.Add(this.btnLoadPalette);
            this.TileEditor.Controls.Add(this.button1);
            this.TileEditor.Controls.Add(this.btnLoadTileMap);
            this.TileEditor.Controls.Add(this.panelParent);
            this.TileEditor.Controls.Add(this.button2);
            this.TileEditor.Controls.Add(this.numericUpDown1);
            this.TileEditor.Controls.Add(this.tileEditor1);
            this.TileEditor.Controls.Add(this.NextPalette);
            this.TileEditor.Controls.Add(this.panel3);
            this.TileEditor.Location = new System.Drawing.Point(4, 29);
            this.TileEditor.Name = "TileEditor";
            this.TileEditor.Padding = new System.Windows.Forms.Padding(3);
            this.TileEditor.Size = new System.Drawing.Size(1801, 961);
            this.TileEditor.TabIndex = 1;
            this.TileEditor.Text = "Tile Editor";
            this.TileEditor.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(658, 0);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(58, 29);
            this.button3.TabIndex = 41;
            this.button3.Text = "New";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(540, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 20);
            this.label3.TabIndex = 40;
            this.label3.Text = "Height";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(424, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 20);
            this.label2.TabIndex = 39;
            this.label2.Text = "width";
            // 
            // numHeight
            // 
            this.numHeight.Location = new System.Drawing.Point(592, 0);
            this.numHeight.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numHeight.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numHeight.Name = "numHeight";
            this.numHeight.Size = new System.Drawing.Size(63, 27);
            this.numHeight.TabIndex = 38;
            this.numHeight.Value = new decimal(new int[] {
            32,
            0,
            0,
            0});
            // 
            // numWidth
            // 
            this.numWidth.Location = new System.Drawing.Point(476, 0);
            this.numWidth.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numWidth.Name = "numWidth";
            this.numWidth.Size = new System.Drawing.Size(63, 27);
            this.numWidth.TabIndex = 37;
            this.numWidth.Value = new decimal(new int[] {
            40,
            0,
            0,
            0});
            // 
            // btnSavePalette
            // 
            this.btnSavePalette.Location = new System.Drawing.Point(1210, 0);
            this.btnSavePalette.Name = "btnSavePalette";
            this.btnSavePalette.Size = new System.Drawing.Size(97, 29);
            this.btnSavePalette.TabIndex = 36;
            this.btnSavePalette.Text = "Save Palette";
            this.btnSavePalette.UseVisualStyleBackColor = true;
            this.btnSavePalette.Click += new System.EventHandler(this.btnSavePalette_Click);
            // 
            // btnSaveTiles
            // 
            this.btnSaveTiles.Location = new System.Drawing.Point(1124, 0);
            this.btnSaveTiles.Name = "btnSaveTiles";
            this.btnSaveTiles.Size = new System.Drawing.Size(84, 29);
            this.btnSaveTiles.TabIndex = 35;
            this.btnSaveTiles.Text = "Save Tiles";
            this.btnSaveTiles.UseVisualStyleBackColor = true;
            this.btnSaveTiles.Click += new System.EventHandler(this.btnSaveTiles_Click);
            // 
            // btnSaveTileMap
            // 
            this.btnSaveTileMap.Location = new System.Drawing.Point(1018, 0);
            this.btnSaveTileMap.Name = "btnSaveTileMap";
            this.btnSaveTileMap.Size = new System.Drawing.Size(102, 29);
            this.btnSaveTileMap.TabIndex = 34;
            this.btnSaveTileMap.Text = "SaveTileMap";
            this.btnSaveTileMap.UseVisualStyleBackColor = true;
            this.btnSaveTileMap.Click += new System.EventHandler(this.btnSaveTileMap_Click);
            // 
            // btnLoadPalette
            // 
            this.btnLoadPalette.Location = new System.Drawing.Point(913, 0);
            this.btnLoadPalette.Name = "btnLoadPalette";
            this.btnLoadPalette.Size = new System.Drawing.Size(99, 29);
            this.btnLoadPalette.TabIndex = 33;
            this.btnLoadPalette.Text = "Load Palette";
            this.btnLoadPalette.UseVisualStyleBackColor = true;
            this.btnLoadPalette.Click += new System.EventHandler(this.btnLoadPalette_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(828, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(80, 29);
            this.button1.TabIndex = 31;
            this.button1.Text = "LoadTiles";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnLoadTiles_Click);
            // 
            // btnLoadTileMap
            // 
            this.btnLoadTileMap.Location = new System.Drawing.Point(722, 0);
            this.btnLoadTileMap.Name = "btnLoadTileMap";
            this.btnLoadTileMap.Size = new System.Drawing.Size(104, 29);
            this.btnLoadTileMap.TabIndex = 32;
            this.btnLoadTileMap.Text = "LoadTileMap";
            this.btnLoadTileMap.UseVisualStyleBackColor = true;
            this.btnLoadTileMap.Click += new System.EventHandler(this.btnLoadTileMap_Click);
            // 
            // panelParent
            // 
            this.panelParent.AutoScroll = true;
            this.panelParent.Controls.Add(this.pnlTileMap);
            this.panelParent.Location = new System.Drawing.Point(6, 41);
            this.panelParent.MaximumSize = new System.Drawing.Size(1123, 800);
            this.panelParent.Name = "panelParent";
            this.panelParent.Size = new System.Drawing.Size(1115, 800);
            this.panelParent.TabIndex = 6;
            // 
            // pnlTileMap
            // 
            this.pnlTileMap.Location = new System.Drawing.Point(0, 0);
            this.pnlTileMap.MaximumSize = new System.Drawing.Size(1280, 8192);
            this.pnlTileMap.Name = "pnlTileMap";
            this.pnlTileMap.Size = new System.Drawing.Size(1280, 8192);
            this.pnlTileMap.TabIndex = 4;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1578, 429);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(91, 36);
            this.button2.TabIndex = 17;
            this.button2.Text = "SaveTile";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.btnSaveTileDef);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(1578, 367);
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
            this.tileEditor1.Location = new System.Drawing.Point(1578, 41);
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
            this.panel3.Controls.Add(this.TilemapPaletteInkAndPaperPicker);
            this.panel3.Controls.Add(this.pnlTilePalette);
            this.panel3.Location = new System.Drawing.Point(1138, 41);
            this.panel3.MaximumSize = new System.Drawing.Size(272, 696);
            this.panel3.MinimumSize = new System.Drawing.Size(272, 696);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(272, 696);
            this.panel3.TabIndex = 10;
            // 
            // TilemapPaletteInkAndPaperPicker
            // 
            this.TilemapPaletteInkAndPaperPicker.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TilemapPaletteInkAndPaperPicker.BackColor = System.Drawing.Color.RosyBrown;
            this.TilemapPaletteInkAndPaperPicker.Location = new System.Drawing.Point(143, 0);
            this.TilemapPaletteInkAndPaperPicker.Name = "TilemapPaletteInkAndPaperPicker";
            this.TilemapPaletteInkAndPaperPicker.pal = null;
            this.TilemapPaletteInkAndPaperPicker.Size = new System.Drawing.Size(128, 696);
            this.TilemapPaletteInkAndPaperPicker.TabIndex = 10;
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1864, 1033);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSpritePaletteOffset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSpriteNum)).EndInit();
            this.TileEditor.ResumeLayout(false);
            this.TileEditor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWidth)).EndInit();
            this.panelParent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private TabControl tabControl1;
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
    }
}