using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static Next_tile_editor.paletteValue9bit;
using static Next_tile_editor.tile32PixImport;

namespace Next_tile_editor
{
    public class tileMapObjs
    {
        private static tileMapObjs m_tileMapOjbs = null;

        public static tileMapObjs GetInstance()
        {
            m_tileMapOjbs = m_tileMapOjbs ?? (m_tileMapOjbs = new tileMapObjs());
            return m_tileMapOjbs;
        }

        public List<Tile8x8> tiles = new List<Tile8x8>();


        public List<TileRef> tile32_32_definition_Map = new List<TileRef>();

        private TileSettings m_ImportSettings = null;
        public TileSettings ImportSettings {
            get
            {
                if (m_ImportSettings == null)
                    m_ImportSettings = new TileSettings()
                    {
                        NumberOfTilesPerSuperTile = 16,
                        ImportTilesInX = 12,
                        ImportTilesInY = 12,
                        superTileTileWidth = 4,
                        superTileTileHeight = 4,
                        tileWidth = 32, // 4 supertiles * 8px
                        tileHeight = 32, // 4 supertiles * 8px
                        tileGroupWidth = 2, // Example default, adjust as needed
                        tileGroupHeight = 2
                    };
                return m_ImportSettings;
            }
            set
            {
                m_ImportSettings = value;
            }
        }


        public byte[] tileMapBytes
        {
            get
            {
                List<byte> retList = new List<byte>(); // new byte[tile32_32_definition_Map.Count * 2];
                foreach (var tile in tile32_32_definition_Map)
                {
                    retList.AddRange(new byte[]
                    {
                        tile.flags, tile.index
                    });
                }

                return retList.ToArray();
            }
        }

        public static Image BytesToImage(byte[] bytes)
        {
            using (var ms = new MemoryStream(bytes))
            {
                return Image.FromStream(ms);
            }
    }


        public static byte[] ImageToBytes(Image img)
        {
            using (var ms = new MemoryStream())
            {
                img.Save(ms, ImageFormat.Png); // or ImageFormat.Jpeg
                return ms.ToArray();
            }
        }

    public bool Save(string szFileName)
        {

            SaveAsJson(szFileName);
            return true;
        }

        public bool Load(string szFileName)
        {
            GetInstance().LoadFromJson(szFileName);
            return true;
        }

        public void Clear()
        {
            GetInstance().tiles.Clear();
            GetInstance().tile32_32_definition_Map.Clear();
            GetInstance().TileList.Clear();
            GetInstance().palette = new Palette9bit();
            GetInstance().imgOrigin = null;
            m_tileMapOjbs = null; // reset the singleton instance

        }
        private class TileMapObjsDto
        {
            public string imgOriginb64 { get; set; }
            public List<byte[]> tiles { get; set; } = new List<byte[]>();
            public List<TileRef> tile32_32_definition_Map { get; set; } = new List<TileRef>();
            public List<List<Tile8x8>> TileList { get; set; } = new List<List<Tile8x8>>();
            public Palette9bitDto palette { get; set; } = new Palette9bitDto();

            public ProjInfoDto projInfo { get; set; } = new ProjInfoDto();

            public TileSettings? ImportSettings { get; set; }
            public List<byte[]> gauntletMap { get; set; }
        

            public class ProjInfoDto
            {
                public int Num8x8Tiledefs { get; set; }
                public int LargeTileDefs { get; set; }
                public int mapwidth_LargeTiles { get; set; }
                public int mapheight_LargeTiles { get; set; }
                public Palette9bitDto palette { get; set; } = new Palette9bitDto();
            }
        }




        public bool SaveAsJson(string fileName)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
            };
            List<byte[]> temptiles = new List<byte[]>();
            foreach (var tile in this.tiles)
            {
                temptiles.Add(tile.tileData);
            }

            var dto = new TileMapObjsDto
            {
                imgOriginb64 =  Convert.ToBase64String(ImageToBytes(this.imgOrigin)),
                palette = new Palette9bitDto(this.palette),
          
                tiles = temptiles,
                tile32_32_definition_Map = this.tile32_32_definition_Map,
                TileList = this.TileList,
                gauntletMap = this.gauntletMap,
                projInfo = new TileMapObjsDto.ProjInfoDto()
                {
                    // Map ProjInfo if you have it, e.g.:
                    // Num8x8Tiledefs = this.projInfo?.Num8x8Tiledefs ?? 0,
                    // palette = new Palette9bitDto(this.projInfo?.palette)
                },
                ImportSettings = this.ImportSettings

            };
            
            string json = JsonSerializer.Serialize(dto, options);
            File.WriteAllText(fileName, json);
            return true;
        }



        public bool LoadFromJson(string fileName)
        {
            if (!File.Exists(fileName))
                return false;

            string json = File.ReadAllText(fileName);

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var dto = JsonSerializer.Deserialize<TileMapObjsDto>(json, options);

            if (dto == null)
                return false;
            

            // Deserialize
            Image myImage = 
            this.imgOrigin = BytesToImage(Convert.FromBase64String(dto.imgOriginb64)); ;
            this.palette = dto.palette?.ToPalette9bit() ?? new Palette9bit();
            this.tiles = new List<Tile8x8>();
            foreach (var tileData in dto.tiles)
            {
                tiles.Add(new Tile8x8(this.palette,0,tileData));
                
            }

            this.ImportSettings = dto.ImportSettings;
            this.TileList = dto.TileList ?? new List<List<Tile8x8>>();
            this.tile32_32_definition_Map = dto.tile32_32_definition_Map ?? new List<TileRef>();
            this.gauntletMap = dto.gauntletMap;
            return true;
        }

        public Image imgOrigin {get;set; }

        private List<List<Tile8x8>> m_tilelist = null;
        private Palette9bit m_palette;

        public List<List<Tile8x8>> TileList
        {
            get
            {
                if (m_tilelist == null || m_tilelist.Count == 0) { m_tilelist  = new List<List<Tile8x8>>(); }
                return m_tilelist;
            }
            set { m_tilelist = value; }

        }

        public Palette9bit palette
        {
            get { if (m_palette== null ) m_palette = new Palette9bit(); return m_palette; }
            set { m_palette = value; }
        }

        public List<byte[]> gauntletMap = new List<byte[]>();
        public class ProjInfo
        {
            public int Num8x8Tiledefs { get; set; }

            public int LargeTileDefs { get; set; }
            public int mapwidth_LargeTiles { get; set; }
            public int mapheight_LargeTiles { get; set; }

            public Palette9bit palette { get; set; }

            


        }
        public class TileSettings
        {
            /// <summary>
            /// Number of 8x8 px tiles in each supertile
            /// </summary>
            public int NumberOfTilesPerSuperTile { get; set; } = 16;
            /// <summary>
            /// How many super tiles in the import horizontally
            /// </summary>
            public int ImportTilesInX { get; set; } = 8;
            /// <summary>
            /// How many super tiles in the import vertically
            /// </summary>
            public int ImportTilesInY { get; set; } = 8;

            /// <summary>
            /// How many 8px squares are there horizontally in one super tile
            /// </summary>
            public int superTileTileWidth { get; set; } = 4;
            /// <summary>
            /// How many 8px squares are there vertically in one super tile
            /// </summary>
            public int superTileTileHeight { get; set; } = 4;

            /// <summary>
            /// How manage 8 px squares in the import horizontally
            /// </summary>
            public int tileWidth { get; set; } = 48;

            /// How manage 8 px squares in the import vertically
            public int tileHeight { get; set; } = 48;

            /// <summary>
            /// /  how many groups of 1,2 or 4 tiles left to right
            /// </summary>
            public int tileGroupWidth { get; set; } = 12;

            /// <summary>
            /// //  how many groups of 1,2 or 4 tiles top to bottom
            /// </summary>
            public int tileGroupHeight { get; set; } = 12; //  how many groups of 1,2 or 4 tiles top to bottom

            public int width_32tiles { get; set; } = 32;
            public int height_32tiles { get; set; } = 64;
        }
    }
}
