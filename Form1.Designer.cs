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
            this.SpritePaletteInkAndPaperPicker = new Next_tile_editor.PalettePicker();
            this.btnWriteToSprite = new System.Windows.Forms.Button();
            this.numSpriteNum = new System.Windows.Forms.NumericUpDown();
            this.spriteEditor1 = new Next_tile_editor.SpriteEditor();
            this.pnlSprites = new System.Windows.Forms.Panel();
            this.TileEditor = new System.Windows.Forms.TabPage();
            this.panelParent = new System.Windows.Forms.Panel();
            this.pnlTileMap = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.tileEditor1 = new Next_tile_editor.TileEditor();
            this.panel3 = new System.Windows.Forms.Panel();
            this.TilemapPaletteInkAndPaperPicker = new Next_tile_editor.PalettePicker();
            this.pnlTilePalette = new System.Windows.Forms.Panel();
            this.btnSavePalette = new System.Windows.Forms.Button();
            this.btnSaveTiles = new System.Windows.Forms.Button();
            this.btnSaveTileMap = new System.Windows.Forms.Button();
            this.btnLoadPalette = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnLoadTileMap = new System.Windows.Forms.Button();
            this.numWidth = new System.Windows.Forms.NumericUpDown();
            this.numHeight = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.numSpritePaletteOffset = new System.Windows.Forms.NumericUpDown();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSpriteNum)).BeginInit();
            this.TileEditor.SuspendLayout();
            this.panelParent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSpritePaletteOffset)).BeginInit();
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
            this.NextPalette.Location = new System.Drawing.Point(1428, 41);
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
            this.btnImportFromNext.Location = new System.Drawing.Point(130, 3);
            this.btnImportFromNext.Name = "btnImportFromNext";
            this.btnImportFromNext.Size = new System.Drawing.Size(115, 29);
            this.btnImportFromNext.TabIndex = 1;
            this.btnImportFromNext.Text = "Next Import";
            this.btnImportFromNext.UseVisualStyleBackColor = true;
            this.btnImportFromNext.Click += new System.EventHandler(this.btnImportFromNext_Click);
            // 
            // btnSaveAsPNG
            // 
            this.btnSaveAsPNG.Location = new System.Drawing.Point(408, 3);
            this.btnSaveAsPNG.Name = "btnSaveAsPNG";
            this.btnSaveAsPNG.Size = new System.Drawing.Size(94, 29);
            this.btnSaveAsPNG.TabIndex = 2;
            this.btnSaveAsPNG.Text = "PNG Save";
            this.btnSaveAsPNG.UseVisualStyleBackColor = true;
            this.btnSaveAsPNG.Click += new System.EventHandler(this.btnSaveAsPNG_Click);
            // 
            // btnSaveAsNextFormat
            // 
            this.btnSaveAsNextFormat.Location = new System.Drawing.Point(508, 3);
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
            this.label1.Location = new System.Drawing.Point(251, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "label1";
            // 
            // btnQuantizeImages
            // 
            this.btnQuantizeImages.Location = new System.Drawing.Point(308, 6);
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
            this.tabControl1.Location = new System.Drawing.Point(3, 74);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1809, 994);
            this.tabControl1.TabIndex = 7;
            // 
            // tabPage1
            // 
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
            // btnSavePalette
            // 
            this.btnSavePalette.Location = new System.Drawing.Point(1418, 12);
            this.btnSavePalette.Name = "btnSavePalette";
            this.btnSavePalette.Size = new System.Drawing.Size(97, 29);
            this.btnSavePalette.TabIndex = 25;
            this.btnSavePalette.Text = "Save Palette";
            this.btnSavePalette.UseVisualStyleBackColor = true;
            this.btnSavePalette.Click += new System.EventHandler(this.btnSavePalette_Click);
            // 
            // btnSaveTiles
            // 
            this.btnSaveTiles.Location = new System.Drawing.Point(1332, 12);
            this.btnSaveTiles.Name = "btnSaveTiles";
            this.btnSaveTiles.Size = new System.Drawing.Size(84, 29);
            this.btnSaveTiles.TabIndex = 24;
            this.btnSaveTiles.Text = "Save Tiles";
            this.btnSaveTiles.UseVisualStyleBackColor = true;
            this.btnSaveTiles.Click += new System.EventHandler(this.btnSaveTiles_Click);
            // 
            // btnSaveTileMap
            // 
            this.btnSaveTileMap.Location = new System.Drawing.Point(1226, 12);
            this.btnSaveTileMap.Name = "btnSaveTileMap";
            this.btnSaveTileMap.Size = new System.Drawing.Size(102, 29);
            this.btnSaveTileMap.TabIndex = 23;
            this.btnSaveTileMap.Text = "SaveTileMap";
            this.btnSaveTileMap.UseVisualStyleBackColor = true;
            this.btnSaveTileMap.Click += new System.EventHandler(this.btnSaveTileMap_Click);
            // 
            // btnLoadPalette
            // 
            this.btnLoadPalette.Location = new System.Drawing.Point(1121, 12);
            this.btnLoadPalette.Name = "btnLoadPalette";
            this.btnLoadPalette.Size = new System.Drawing.Size(99, 29);
            this.btnLoadPalette.TabIndex = 22;
            this.btnLoadPalette.Text = "Load Palette";
            this.btnLoadPalette.UseVisualStyleBackColor = true;
            this.btnLoadPalette.Click += new System.EventHandler(this.btnLoadPalette_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1036, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(80, 29);
            this.button1.TabIndex = 20;
            this.button1.Text = "LoadTiles";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnLoadTiles_Click);
            // 
            // btnLoadTileMap
            // 
            this.btnLoadTileMap.Location = new System.Drawing.Point(930, 12);
            this.btnLoadTileMap.Name = "btnLoadTileMap";
            this.btnLoadTileMap.Size = new System.Drawing.Size(104, 29);
            this.btnLoadTileMap.TabIndex = 21;
            this.btnLoadTileMap.Text = "LoadTileMap";
            this.btnLoadTileMap.UseVisualStyleBackColor = true;
            this.btnLoadTileMap.Click += new System.EventHandler(this.btnLoadTileMap_Click);
            // 
            // numWidth
            // 
            this.numWidth.Location = new System.Drawing.Point(684, 12);
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
            this.numWidth.TabIndex = 26;
            this.numWidth.Value = new decimal(new int[] {
            40,
            0,
            0,
            0});
            // 
            // numHeight
            // 
            this.numHeight.Location = new System.Drawing.Point(800, 12);
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
            this.numHeight.TabIndex = 27;
            this.numHeight.Value = new decimal(new int[] {
            32,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(632, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 20);
            this.label2.TabIndex = 28;
            this.label2.Text = "width";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(748, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 20);
            this.label3.TabIndex = 29;
            this.label3.Text = "Height";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(866, 12);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(58, 29);
            this.button3.TabIndex = 30;
            this.button3.Text = "New";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(7, 38);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(99, 29);
            this.button4.TabIndex = 31;
            this.button4.Text = "Load Palette";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.btnLoadSpritePalette_Click);
            // 
            // numSpritePaletteOffset
            // 
            this.numSpritePaletteOffset.Location = new System.Drawing.Point(332, 835);
            this.numSpritePaletteOffset.Name = "numSpritePaletteOffset";
            this.numSpritePaletteOffset.Size = new System.Drawing.Size(150, 27);
            this.numSpritePaletteOffset.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1864, 1033);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numHeight);
            this.Controls.Add(this.numWidth);
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
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numSpriteNum)).EndInit();
            this.TileEditor.ResumeLayout(false);
            this.panelParent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSpritePaletteOffset)).EndInit();
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
        public PalettePicker TilemapPaletteInkAndPaperPicker;
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
        private NumericUpDown numWidth;
        private NumericUpDown numHeight;
        private Label label2;
        private Label label3;
        private Button button3;
        private Button button4;
        private Panel pnlSprites;
        private SpriteEditor spriteEditor1;
        private Button button5;
        private NumericUpDown numSpriteNum;
        private PalettePicker SpritePaletteInkAndPaperPicker;
        private Button btnWriteToSprite;
        private NumericUpDown numSpritePaletteOffset;
    }
}