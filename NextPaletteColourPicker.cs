using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Next_tile_editor
{
    public partial class NextPaletteColourPicker : UserControl
    {
        PictureBox pbInk;
        PictureBox pbPaper;
        public NextPaletteColourPicker()
        {
            InitializeComponent();
            this.Width = 256;
            this.Height = 640;
            pbInk = new PictureBox { Location = new Point(0, this.Height - 64), Size = new Size(64, 64), Visible = true, Name = "PBInk", Anchor = AnchorStyles.Bottom | AnchorStyles.Left };
            pbPaper = new PictureBox { Location = new Point(64, this.Height - 64), Size = new Size(64, 64), Visible = true, Name = "pbPaper", Anchor = AnchorStyles.Bottom | AnchorStyles.Left };

            this.Controls.Add(pbInk);
            this.Controls.Add(pbPaper);
            this.Paper9bit = paletteValue9bit.FromColor(Color.White);
            this.Ink9bit = paletteValue9bit.FromColor(Color.Black);
            Paint += NextPalette_Paint;
            this.MouseClick += NextPalette_Click;
            
        }
        private paletteValue9bit _ink9bit = null;
        public paletteValue9bit Ink9bit
        {
            get
            {
                return _ink9bit;
            }
            set
            {
                _ink9bit = value;
                if (value != null && this.pbInk.Image != null)
                {
                    using (Graphics g = Graphics.FromImage(this.pbInk.Image))
                    {
                        g.Clear(_ink9bit.PalColor);
                    }
                }
            }
        }

        public paletteValue9bit Paper9bit
        {
            get;
            set;
        }
        public int InkIndex
        { get; set; }
        public int PaperIndex
        { get; set; }
        private void NextPalette_Click(object? sender, MouseEventArgs e)
        {
            if (colors == null)
                return;
            try
            {
                Point pos = this.PointToClient(Cursor.Position);
                var Button = e.Button;
                if (Button == MouseButtons.Left)
                {
                    Bitmap bmInk = new Bitmap(64, 64);
                    using (Graphics g = Graphics.FromImage(bmInk))
                    {
                        g.Clear(colors[pos.X, pos.Y]);
                        Ink9bit = paletteValue9bit.FromColor(colors[pos.X, pos.Y]);
                    
                    }
                    
                    pbInk.Image = bmInk;
                    if (InkColoursChanged != null)
                        InkColoursChanged(sender, e);

                }
                if (Button == MouseButtons.Right)
                {
                    Bitmap bmPaper = new Bitmap(64, 64);
                    using (Graphics g = Graphics.FromImage(bmPaper))
                    {
                        g.Clear(colors[pos.X, pos.Y]);
                        Paper9bit = paletteValue9bit.FromColor(colors[pos.X, pos.Y]);
                        
                    }
                    pbPaper.Image = bmPaper;
                    if (PaperColoursChanged != null)
                        PaperColoursChanged(sender, e);
                }
                
            }
            catch(Exception exc)
            {
                MessageBox.Show("Ouch : " + exc.ToString());
            }


        }

        Bitmap _bitmap = null;
        private void NextPalette_Paint(object? sender, PaintEventArgs e)
        {
            if (_bitmap != null)
            {
                e.Graphics.DrawImage(_bitmap, 0, 0, _bitmap.Width, _bitmap.Height);
            }
            
        }

        public event EventHandler InkColoursChanged;
        public event EventHandler PaperColoursChanged;

        private Palette9bit _palette = null;
        public Palette9bit Palette
        {
            get
            {
                return _palette;
            }

            set
            {
                _palette = value;
                UpdateBmp();
            }
        }
        public int ScaleVal
        {
            get;
            set;
        }
        private Color[,] colors = null;
        private void DrawHSL(Bitmap bitmap)
        { 

            int width = bitmap.Width;
            int height = bitmap.Height- 64;
            double horizratio = 1.0 / width;
            double vertratio = 1.0 / height;
            const double saturation = 1.0;
            colors = new Color[width, height+64];
        
            for (int i = 0; i < width; i++)
            {
                double lightness = 1.0 - i * horizratio;
                for (int j = 0; j < height; j++)
                {
                    double hue = j * vertratio;
                    HSL hSL = new HSL { H = hue, S = saturation, L = lightness };
                    colors[i, j] = FromHSL(hSL);
                    using (Graphics g = Graphics.FromImage(bitmap))
                    {
                        g.FillRectangle(new SolidBrush(paletteValue9bit.FromColor(colors[i, j]).PalColor), i, j, 2, 2);
                    }
                }
            }
            int colwidth = width / 8;
            for (int i = 0; i < width; i++)
            {
                    
                for (int j = height; j < height+64; j++)
                {
                    int shade = ((int)(i/colwidth))*colwidth *2;
                    colors[i, j] = Color.FromArgb(shade, shade, shade);
                    using (Graphics g = Graphics.FromImage(bitmap))
                    {
                        g.FillRectangle(new SolidBrush(paletteValue9bit.FromColor(colors[i, j]).PalColor), i, j, 2, 2);
                    }
                }
            }
            ///
            // WE NEED TO ADD A GREYSCALE BAR AS GREYS ARENT ALL IN THE CHART
        }
        private void UpdateBmp()
        {
            if (_palette != null)
            {
                if (_bitmap == null)
                    _bitmap = new Bitmap(this.Width, this.Height - 64);
          
                DrawHSL(_bitmap);
            }
            this.Invalidate();
        }
        public class HSL
        {
            public double H
            { get; set; }
            public double S { get; set; }
            public double L { get; set; }
        }
        public static Color FromHSL(HSL hsl)
        {
            double r = 0, g = 0, b = 0;
            double temp1, temp2;
            if (hsl.L == 0)
            {
                r = g = b = 0;
            }
            else
            {
                if (hsl.S == 0)
                {
                    r = g = b = hsl.L;
                }
                else
                {
                    temp2 = ((hsl.L <= 0.5) ? hsl.L * (1.0 + hsl.S) : hsl.L + hsl.S - (hsl.L * hsl.S));
                    temp1 = 2.0 * hsl.L - temp2;

                    double[] t3 = new double[] { hsl.H + 1.0 / 3.0, hsl.H, hsl.H - 1.0 / 3.0 };
                    double[] clr = new double[] { 0, 0, 0 };

                    for (int i = 0; i < 3; i++)
                    {
                        if (t3[i] < 0)
                            t3[i] += 1.0;
                        if (t3[i] > 1)
                            t3[i] -= 1.0;

                        if (6.0 * t3[i] < 1.0)
                            clr[i] = temp1 + (temp2 - temp1) * t3[i] * 6.0;
                        else if (2.0 * t3[i] < 1.0)
                            clr[i] = temp2;
                        else if (3.0 * t3[i] < 2.0)
                            clr[i] = (temp1 + (temp2 - temp1) * ((2.0 / 3.0) - t3[i]) * 6.0);
                        else
                            clr[i] = temp1;
                    }
                    r = clr[0];
                    g = clr[1];
                    b = clr[2];
                }
            }

            return Color.FromArgb((int)(255 * r), (int)(255 * g), (int)(255 * b));
        }
    }
}
