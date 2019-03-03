using System;
using System.Runtime.InteropServices;
using OpenTK;

namespace amulware.Graphics
{
    /// <summary>
    /// A struct representing a 32bit argb colour.
    /// </summary>
    /// <remarks>
    /// The actual order of the components in the struct is RGBA(one byte each), to conform to how shader languages order colour components.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential)]
    public struct Color : IEquatable<Color>
    {
        #region Static W3C Colours /// @name Default static W3C colours
        /// <summary>Default transparent color.</summary>
        public static readonly Color Transparent = new Color(0x00000000);
        /// <summary>Default 'Pink' W3C color (FF C0 CB) / (255, 192, 203).</summary>
        public static readonly Color Pink = new Color(0xFFFFC0CB);
        /// <summary>Default 'LightPink' W3C color (FF B6 C1) / (255, 182, 193).</summary>
        public static readonly Color LightPink = new Color(0xFFFFB6C1);
        /// <summary>Default 'HotPink' W3C color (FF 69 B4) / (255, 105, 180).</summary>
        public static readonly Color HotPink = new Color(0xFFFF69B4);
        /// <summary>Default 'DeepPink' W3C color (FF 14 93) / (255, 20, 147).</summary>
        public static readonly Color DeepPink = new Color(0xFFFF1493);
        /// <summary>Default 'PaleVioletRed' W3C color (DB 70 93) / (219, 112, 147).</summary>
        public static readonly Color PaleVioletRed = new Color(0xFFDB7093);
        /// <summary>Default 'MediumVioletRed' W3C color (C7 15 85) / (199, 21, 133).</summary>
        public static readonly Color MediumVioletRed = new Color(0xFFC71585);
        /// <summary>Default 'LightSalmon' W3C color (FF A0 7A) / (255, 160, 122).</summary>
        public static readonly Color LightSalmon = new Color(0xFFFFA07A);
        /// <summary>Default 'Salmon' W3C color (FA 80 72) / (250, 128, 114).</summary>
        public static readonly Color Salmon = new Color(0xFFFA8072);
        /// <summary>Default 'DarkSalmon' W3C color (E9 96 7A) / (233, 150, 122).</summary>
        public static readonly Color DarkSalmon = new Color(0xFFE9967A);
        /// <summary>Default 'LightCoral' W3C color (F0 80 80) / (240, 128, 128).</summary>
        public static readonly Color LightCoral = new Color(0xFFF08080);
        /// <summary>Default 'IndianRed' W3C color (CD 5C 5C) / (205, 92, 92).</summary>
        public static readonly Color IndianRed = new Color(0xFFCD5C5C);
        /// <summary>Default 'Crimson' W3C color (DC 14 3C) / (220, 20, 60).</summary>
        public static readonly Color Crimson = new Color(0xFFDC143C);
        /// <summary>Default 'FireBrick' W3C color (B2 22 22) / (178, 34, 34).</summary>
        public static readonly Color FireBrick = new Color(0xFFB22222);
        /// <summary>Default 'DarkRed' W3C color (8B 00 00) / (139, 0, 0).</summary>
        public static readonly Color DarkRed = new Color(0xFF8B0000);
        /// <summary>Default 'Red' W3C color (FF 00 00) / (255, 0, 0).</summary>
        public static readonly Color Red = new Color(0xFFFF0000);
        /// <summary>Default 'OrangeRed' W3C color (FF 45 00) / (255, 69, 0).</summary>
        public static readonly Color OrangeRed = new Color(0xFFFF4500);
        /// <summary>Default 'Tomato' W3C color (FF 63 47) / (255, 99, 71).</summary>
        public static readonly Color Tomato = new Color(0xFFFF6347);
        /// <summary>Default 'Coral' W3C color (FF 7F 50) / (255, 127, 80).</summary>
        public static readonly Color Coral = new Color(0xFFFF7F50);
        /// <summary>Default 'DarkOrange' W3C color (FF 8C 00) / (255, 140, 0).</summary>
        public static readonly Color DarkOrange = new Color(0xFFFF8C00);
        /// <summary>Default 'Orange' W3C color (FF A5 00) / (255, 165, 0).</summary>
        public static readonly Color Orange = new Color(0xFFFFA500);
        /// <summary>Default 'Gold' W3C color (FF D7 00) / (255, 215, 0).</summary>
        public static readonly Color Gold = new Color(0xFFFFD700);
        /// <summary>Default 'Yellow' W3C color (FF FF 00) / (255, 255, 0).</summary>
        public static readonly Color Yellow = new Color(0xFFFFFF00);
        /// <summary>Default 'LightYellow' W3C color (FF FF E0) / (255, 255, 224).</summary>
        public static readonly Color LightYellow = new Color(0xFFFFFFE0);
        /// <summary>Default 'LemonChiffon' W3C color (FF FA CD) / (255, 250, 205).</summary>
        public static readonly Color LemonChiffon = new Color(0xFFFFFACD);
        /// <summary>Default 'LightGoldenrodYellow' W3C color (FA FA D2) / (250, 250, 210).</summary>
        public static readonly Color LightGoldenrodYellow = new Color(0xFFFAFAD2);
        /// <summary>Default 'PapayaWhip' W3C color (FF EF D5) / (255, 239, 213).</summary>
        public static readonly Color PapayaWhip = new Color(0xFFFFEFD5);
        /// <summary>Default 'Moccasin' W3C color (FF E4 B5) / (255, 228, 181).</summary>
        public static readonly Color Moccasin = new Color(0xFFFFE4B5);
        /// <summary>Default 'PeachPuff' W3C color (FF DA B9) / (255, 218, 185).</summary>
        public static readonly Color PeachPuff = new Color(0xFFFFDAB9);
        /// <summary>Default 'PaleGoldenrod' W3C color (EE E8 AA) / (238, 232, 170).</summary>
        public static readonly Color PaleGoldenrod = new Color(0xFFEEE8AA);
        /// <summary>Default 'Khaki' W3C color (F0 E6 8C) / (240, 230, 140).</summary>
        public static readonly Color Khaki = new Color(0xFFF0E68C);
        /// <summary>Default 'DarkKhaki' W3C color (BD B7 6B) / (189, 183, 107).</summary>
        public static readonly Color DarkKhaki = new Color(0xFFBDB76B);
        /// <summary>Default 'Cornsilk' W3C color (FF F8 DC) / (255, 248, 220).</summary>
        public static readonly Color Cornsilk = new Color(0xFFFFF8DC);
        /// <summary>Default 'BlanchedAlmond' W3C color (FF EB CD) / (255, 235, 205).</summary>
        public static readonly Color BlanchedAlmond = new Color(0xFFFFEBCD);
        /// <summary>Default 'Bisque' W3C color (FF E4 C4) / (255, 228, 196).</summary>
        public static readonly Color Bisque = new Color(0xFFFFE4C4);
        /// <summary>Default 'NavajoWhite' W3C color (FF DE AD) / (255, 222, 173).</summary>
        public static readonly Color NavajoWhite = new Color(0xFFFFDEAD);
        /// <summary>Default 'Wheat' W3C color (F5 DE B3) / (245, 222, 179).</summary>
        public static readonly Color Wheat = new Color(0xFFF5DEB3);
        /// <summary>Default 'BurlyWood' W3C color (DE B8 87) / (222, 184, 135).</summary>
        public static readonly Color BurlyWood = new Color(0xFFDEB887);
        /// <summary>Default 'Tan' W3C color (D2 B4 8C) / (210, 180, 140).</summary>
        public static readonly Color Tan = new Color(0xFFD2B48C);
        /// <summary>Default 'RosyBrown' W3C color (BC 8F 8F) / (188, 143, 143).</summary>
        public static readonly Color RosyBrown = new Color(0xFFBC8F8F);
        /// <summary>Default 'SandyBrown' W3C color (F4 A4 60) / (244, 164, 96).</summary>
        public static readonly Color SandyBrown = new Color(0xFFF4A460);
        /// <summary>Default 'Goldenrod' W3C color (DA A5 20) / (218, 165, 32).</summary>
        public static readonly Color Goldenrod = new Color(0xFFDAA520);
        /// <summary>Default 'DarkGoldenrod' W3C color (B8 86 0B) / (184, 134, 11).</summary>
        public static readonly Color DarkGoldenrod = new Color(0xFFB8860B);
        /// <summary>Default 'Peru' W3C color (CD 85 3F) / (205, 133, 63).</summary>
        public static readonly Color Peru = new Color(0xFFCD853F);
        /// <summary>Default 'Chocolate' W3C color (D2 69 1E) / (210, 105, 30).</summary>
        public static readonly Color Chocolate = new Color(0xFFD2691E);
        /// <summary>Default 'SaddleBrown' W3C color (8B 45 13) / (139, 69, 19).</summary>
        public static readonly Color SaddleBrown = new Color(0xFF8B4513);
        /// <summary>Default 'Sienna' W3C color (A0 52 2D) / (160, 82, 45).</summary>
        public static readonly Color Sienna = new Color(0xFFA0522D);
        /// <summary>Default 'Brown' W3C color (A5 2A 2A) / (165, 42, 42).</summary>
        public static readonly Color Brown = new Color(0xFFA52A2A);
        /// <summary>Default 'Maroon' W3C color (80 00 00) / (128, 0, 0).</summary>
        public static readonly Color Maroon = new Color(0xFF800000);
        /// <summary>Default 'DarkOliveGreen' W3C color (55 6B 2F) / (85, 107, 47).</summary>
        public static readonly Color DarkOliveGreen = new Color(0xFF556B2F);
        /// <summary>Default 'Olive' W3C color (80 80 00) / (128, 128, 0).</summary>
        public static readonly Color Olive = new Color(0xFF808000);
        /// <summary>Default 'OliveDrab' W3C color (6B 8E 23) / (107, 142, 35).</summary>
        public static readonly Color OliveDrab = new Color(0xFF6B8E23);
        /// <summary>Default 'YellowGreen' W3C color (9A CD 32) / (154, 205, 50).</summary>
        public static readonly Color YellowGreen = new Color(0xFF9ACD32);
        /// <summary>Default 'LimeGreen' W3C color (32 CD 32) / (50, 205, 50).</summary>
        public static readonly Color LimeGreen = new Color(0xFF32CD32);
        /// <summary>Default 'Lime' W3C color (00 FF 00) / (0, 255, 0).</summary>
        public static readonly Color Lime = new Color(0xFF00FF00);
        /// <summary>Default 'LawnGreen' W3C color (7C FC 00) / (124, 252, 0).</summary>
        public static readonly Color LawnGreen = new Color(0xFF7CFC00);
        /// <summary>Default 'Chartreuse' W3C color (7F FF 00) / (127, 255, 0).</summary>
        public static readonly Color Chartreuse = new Color(0xFF7FFF00);
        /// <summary>Default 'GreenYellow' W3C color (AD FF 2F) / (173, 255, 47).</summary>
        public static readonly Color GreenYellow = new Color(0xFFADFF2F);
        /// <summary>Default 'SpringGreen' W3C color (00 FF 7F) / (0, 255, 127).</summary>
        public static readonly Color SpringGreen = new Color(0xFF00FF7F);
        /// <summary>Default 'MediumSpringGreen' W3C color (00 FA 9A) / (0, 250, 154).</summary>
        public static readonly Color MediumSpringGreen = new Color(0xFF00FA9A);
        /// <summary>Default 'LightGreen' W3C color (90 EE 90) / (144, 238, 144).</summary>
        public static readonly Color LightGreen = new Color(0xFF90EE90);
        /// <summary>Default 'PaleGreen' W3C color (98 FB 98) / (152, 251, 152).</summary>
        public static readonly Color PaleGreen = new Color(0xFF98FB98);
        /// <summary>Default 'DarkSeaGreen' W3C color (8F BC 8F) / (143, 188, 143).</summary>
        public static readonly Color DarkSeaGreen = new Color(0xFF8FBC8F);
        /// <summary>Default 'MediumSeaGreen' W3C color (3C B3 71) / (60, 179, 113).</summary>
        public static readonly Color MediumSeaGreen = new Color(0xFF3CB371);
        /// <summary>Default 'SeaGreen' W3C color (2E 8B 57) / (46, 139, 87).</summary>
        public static readonly Color SeaGreen = new Color(0xFF2E8B57);
        /// <summary>Default 'ForestGreen' W3C color (22 8B 22) / (34, 139, 34).</summary>
        public static readonly Color ForestGreen = new Color(0xFF228B22);
        /// <summary>Default 'Green' W3C color (00 80 00) / (0, 128, 0).</summary>
        public static readonly Color Green = new Color(0xFF008000);
        /// <summary>Default 'DarkGreen' W3C color (00 64 00) / (0, 100, 0).</summary>
        public static readonly Color DarkGreen = new Color(0xFF006400);
        /// <summary>Default 'MediumAquamarine' W3C color (66 CD AA) / (102, 205, 170).</summary>
        public static readonly Color MediumAquamarine = new Color(0xFF66CDAA);
        /// <summary>Default 'Aqua' W3C color (00 FF FF) / (0, 255, 255).</summary>
        public static readonly Color Aqua = new Color(0xFF00FFFF);
        /// <summary>Default 'Cyan' W3C color (00 FF FF) / (0, 255, 255).</summary>
        public static readonly Color Cyan = new Color(0xFF00FFFF);
        /// <summary>Default 'LightCyan' W3C color (E0 FF FF) / (224, 255, 255).</summary>
        public static readonly Color LightCyan = new Color(0xFFE0FFFF);
        /// <summary>Default 'PaleTurquoise' W3C color (AF EE EE) / (175, 238, 238).</summary>
        public static readonly Color PaleTurquoise = new Color(0xFFAFEEEE);
        /// <summary>Default 'Aquamarine' W3C color (7F FF D4) / (127, 255, 212).</summary>
        public static readonly Color Aquamarine = new Color(0xFF7FFFD4);
        /// <summary>Default 'Turquoise' W3C color (40 E0 D0) / (64, 224, 208).</summary>
        public static readonly Color Turquoise = new Color(0xFF40E0D0);
        /// <summary>Default 'MediumTurquoise' W3C color (48 D1 CC) / (72, 209, 204).</summary>
        public static readonly Color MediumTurquoise = new Color(0xFF48D1CC);
        /// <summary>Default 'DarkTurquoise' W3C color (00 CE D1) / (0, 206, 209).</summary>
        public static readonly Color DarkTurquoise = new Color(0xFF00CED1);
        /// <summary>Default 'LightSeaGreen' W3C color (20 B2 AA) / (32, 178, 170).</summary>
        public static readonly Color LightSeaGreen = new Color(0xFF20B2AA);
        /// <summary>Default 'CadetBlue' W3C color (5F 9E A0) / (95, 158, 160).</summary>
        public static readonly Color CadetBlue = new Color(0xFF5F9EA0);
        /// <summary>Default 'DarkCyan' W3C color (00 8B 8B) / (0, 139, 139).</summary>
        public static readonly Color DarkCyan = new Color(0xFF008B8B);
        /// <summary>Default 'Teal' W3C color (00 80 80) / (0, 128, 128).</summary>
        public static readonly Color Teal = new Color(0xFF008080);
        /// <summary>Default 'LightSteelBlue' W3C color (B0 C4 DE) / (176, 196, 222).</summary>
        public static readonly Color LightSteelBlue = new Color(0xFFB0C4DE);
        /// <summary>Default 'PowderBlue' W3C color (B0 E0 E6) / (176, 224, 230).</summary>
        public static readonly Color PowderBlue = new Color(0xFFB0E0E6);
        /// <summary>Default 'LightBlue' W3C color (AD D8 E6) / (173, 216, 230).</summary>
        public static readonly Color LightBlue = new Color(0xFFADD8E6);
        /// <summary>Default 'SkyBlue' W3C color (87 CE EB) / (135, 206, 235).</summary>
        public static readonly Color SkyBlue = new Color(0xFF87CEEB);
        /// <summary>Default 'LightSkyBlue' W3C color (87 CE FA) / (135, 206, 250).</summary>
        public static readonly Color LightSkyBlue = new Color(0xFF87CEFA);
        /// <summary>Default 'DeepSkyBlue' W3C color (00 BF FF) / (0, 191, 255).</summary>
        public static readonly Color DeepSkyBlue = new Color(0xFF00BFFF);
        /// <summary>Default 'DodgerBlue' W3C color (1E 90 FF) / (30, 144, 255).</summary>
        public static readonly Color DodgerBlue = new Color(0xFF1E90FF);
        /// <summary>Default 'CornflowerBlue' W3C color (64 95 ED) / (100, 149, 237).</summary>
        public static readonly Color CornflowerBlue = new Color(0xFF6495ED);
        /// <summary>Default 'SteelBlue' W3C color (46 82 B4) / (70, 130, 180).</summary>
        public static readonly Color SteelBlue = new Color(0xFF4682B4);
        /// <summary>Default 'RoyalBlue' W3C color (41 69 E1) / (65, 105, 225).</summary>
        public static readonly Color RoyalBlue = new Color(0xFF4169E1);
        /// <summary>Default 'Blue' W3C color (00 00 FF) / (0, 0, 255).</summary>
        public static readonly Color Blue = new Color(0xFF0000FF);
        /// <summary>Default 'MediumBlue' W3C color (00 00 CD) / (0, 0, 205).</summary>
        public static readonly Color MediumBlue = new Color(0xFF0000CD);
        /// <summary>Default 'DarkBlue' W3C color (00 00 8B) / (0, 0, 139).</summary>
        public static readonly Color DarkBlue = new Color(0xFF00008B);
        /// <summary>Default 'Navy' W3C color (00 00 80) / (0, 0, 128).</summary>
        public static readonly Color Navy = new Color(0xFF000080);
        /// <summary>Default 'MidnightBlue' W3C color (19 19 70) / (25, 25, 112).</summary>
        public static readonly Color MidnightBlue = new Color(0xFF191970);
        /// <summary>Default 'Lavender' W3C color (E6 E6 FA) / (230, 230, 250).</summary>
        public static readonly Color Lavender = new Color(0xFFE6E6FA);
        /// <summary>Default 'Thistle' W3C color (D8 BF D8) / (216, 191, 216).</summary>
        public static readonly Color Thistle = new Color(0xFFD8BFD8);
        /// <summary>Default 'Plum' W3C color (DD A0 DD) / (221, 160, 221).</summary>
        public static readonly Color Plum = new Color(0xFFDDA0DD);
        /// <summary>Default 'Violet' W3C color (EE 82 EE) / (238, 130, 238).</summary>
        public static readonly Color Violet = new Color(0xFFEE82EE);
        /// <summary>Default 'Orchid' W3C color (DA 70 D6) / (218, 112, 214).</summary>
        public static readonly Color Orchid = new Color(0xFFDA70D6);
        /// <summary>Default 'Fuchsia' W3C color (FF 00 FF) / (255, 0, 255).</summary>
        public static readonly Color Fuchsia = new Color(0xFFFF00FF);
        /// <summary>Default 'Magenta' W3C color (FF 00 FF) / (255, 0, 255).</summary>
        public static readonly Color Magenta = new Color(0xFFFF00FF);
        /// <summary>Default 'MediumOrchid' W3C color (BA 55 D3) / (186, 85, 211).</summary>
        public static readonly Color MediumOrchid = new Color(0xFFBA55D3);
        /// <summary>Default 'MediumPurple' W3C color (93 70 DB) / (147, 112, 219).</summary>
        public static readonly Color MediumPurple = new Color(0xFF9370DB);
        /// <summary>Default 'BlueViolet' W3C color (8A 2B E2) / (138, 43, 226).</summary>
        public static readonly Color BlueViolet = new Color(0xFF8A2BE2);
        /// <summary>Default 'DarkViolet' W3C color (94 00 D3) / (148, 0, 211).</summary>
        public static readonly Color DarkViolet = new Color(0xFF9400D3);
        /// <summary>Default 'DarkOrchid' W3C color (99 32 CC) / (153, 50, 204).</summary>
        public static readonly Color DarkOrchid = new Color(0xFF9932CC);
        /// <summary>Default 'DarkMagenta' W3C color (8B 00 8B) / (139, 0, 139).</summary>
        public static readonly Color DarkMagenta = new Color(0xFF8B008B);
        /// <summary>Default 'Purple' W3C color (80 00 80) / (128, 0, 128).</summary>
        public static readonly Color Purple = new Color(0xFF800080);
        /// <summary>Default 'Indigo' W3C color (4B 00 82) / (75, 0, 130).</summary>
        public static readonly Color Indigo = new Color(0xFF4B0082);
        /// <summary>Default 'DarkSlateBlue' W3C color (48 3D 8B) / (72, 61, 139).</summary>
        public static readonly Color DarkSlateBlue = new Color(0xFF483D8B);
        /// <summary>Default 'SlateBlue' W3C color (6A 5A CD) / (106, 90, 205).</summary>
        public static readonly Color SlateBlue = new Color(0xFF6A5ACD);
        /// <summary>Default 'MediumSlateBlue' W3C color (7B 68 EE) / (123, 104, 238).</summary>
        public static readonly Color MediumSlateBlue = new Color(0xFF7B68EE);
        /// <summary>Default 'White' W3C color (FF FF FF) / (255, 255, 255).</summary>
        public static readonly Color White = new Color(0xFFFFFFFF);
        /// <summary>Default 'Snow' W3C color (FF FA FA) / (255, 250, 250).</summary>
        public static readonly Color Snow = new Color(0xFFFFFAFA);
        /// <summary>Default 'Honeydew' W3C color (F0 FF F0) / (240, 255, 240).</summary>
        public static readonly Color Honeydew = new Color(0xFFF0FFF0);
        /// <summary>Default 'MintCream' W3C color (F5 FF FA) / (245, 255, 250).</summary>
        public static readonly Color MintCream = new Color(0xFFF5FFFA);
        /// <summary>Default 'Azure' W3C color (F0 FF FF) / (240, 255, 255).</summary>
        public static readonly Color Azure = new Color(0xFFF0FFFF);
        /// <summary>Default 'AliceBlue' W3C color (F0 F8 FF) / (240, 248, 255).</summary>
        public static readonly Color AliceBlue = new Color(0xFFF0F8FF);
        /// <summary>Default 'GhostWhite' W3C color (F8 F8 FF) / (248, 248, 255).</summary>
        public static readonly Color GhostWhite = new Color(0xFFF8F8FF);
        /// <summary>Default 'WhiteSmoke' W3C color (F5 F5 F5) / (245, 245, 245).</summary>
        public static readonly Color WhiteSmoke = new Color(0xFFF5F5F5);
        /// <summary>Default 'Seashell' W3C color (FF F5 EE) / (255, 245, 238).</summary>
        public static readonly Color Seashell = new Color(0xFFFFF5EE);
        /// <summary>Default 'Beige' W3C color (F5 F5 DC) / (245, 245, 220).</summary>
        public static readonly Color Beige = new Color(0xFFF5F5DC);
        /// <summary>Default 'OldLace' W3C color (FD F5 E6) / (253, 245, 230).</summary>
        public static readonly Color OldLace = new Color(0xFFFDF5E6);
        /// <summary>Default 'FloralWhite' W3C color (FF FA F0) / (255, 250, 240).</summary>
        public static readonly Color FloralWhite = new Color(0xFFFFFAF0);
        /// <summary>Default 'Ivory' W3C color (FF FF F0) / (255, 255, 240).</summary>
        public static readonly Color Ivory = new Color(0xFFFFFFF0);
        /// <summary>Default 'AntiqueWhite' W3C color (FA EB D7) / (250, 235, 215).</summary>
        public static readonly Color AntiqueWhite = new Color(0xFFFAEBD7);
        /// <summary>Default 'Linen' W3C color (FA F0 E6) / (250, 240, 230).</summary>
        public static readonly Color Linen = new Color(0xFFFAF0E6);
        /// <summary>Default 'LavenderBlush' W3C color (FF F0 F5) / (255, 240, 245).</summary>
        public static readonly Color LavenderBlush = new Color(0xFFFFF0F5);
        /// <summary>Default 'MistyRose' W3C color (FF E4 E1) / (255, 228, 225).</summary>
        public static readonly Color MistyRose = new Color(0xFFFFE4E1);
        /// <summary>Default 'Gainsboro' W3C color (DC DC DC) / (220, 220, 220).</summary>
        public static readonly Color Gainsboro = new Color(0xFFDCDCDC);
        /// <summary>Default 'LightGray' W3C color (D3 D3 D3) / (211, 211, 211).</summary>
        public static readonly Color LightGray = new Color(0xFFD3D3D3);
        /// <summary>Default 'Silver' W3C color (C0 C0 C0) / (192, 192, 192).</summary>
        public static readonly Color Silver = new Color(0xFFC0C0C0);
        /// <summary>Default 'DarkGray' W3C color (A9 A9 A9) / (169, 169, 169).</summary>
        public static readonly Color DarkGray = new Color(0xFFA9A9A9);
        /// <summary>Default 'Gray' W3C color (80 80 80) / (128, 128, 128).</summary>
        public static readonly Color Gray = new Color(0xFF808080);
        /// <summary>Default 'DimGray' W3C color (69 69 69) / (105, 105, 105).</summary>
        public static readonly Color DimGray = new Color(0xFF696969);
        /// <summary>Default 'LightSlateGray' W3C color (77 88 99) / (119, 136, 153).</summary>
        public static readonly Color LightSlateGray = new Color(0xFF778899);
        /// <summary>Default 'SlateGray' W3C color (70 80 90) / (112, 128, 144).</summary>
        public static readonly Color SlateGray = new Color(0xFF708090);
        /// <summary>Default 'DarkSlateGray' W3C color (2F 4F 4F) / (47, 79, 79).</summary>
        public static readonly Color DarkSlateGray = new Color(0xFF2F4F4F);
        /// <summary>Default 'Black' W3C color (00 00 00) / (0, 0, 0).</summary>
        public static readonly Color Black = new Color(0xFF000000);

        #endregion

        #region Fields

        private readonly byte r, g, b, a;

        #endregion

        #region Constructors

        /// <summary>
        /// Constructs a colour from a red, green, blue and alpha value.
        /// </summary>
        /// <param name="r">The red value.</param>
        /// <param name="g">The green value.</param>
        /// <param name="b">The blue value.</param>
        /// <param name="a">The alpha value.</param>
        public Color(byte r, byte g, byte b, byte a = 255)
        {
            this.r = r;
            this.g = g;
            this.b = b;
            this.a = a;
        }

        /// <summary>
        /// Constructs a colour from a 32bit unsigned integer including the colour components in the order ARGB.
        /// </summary>
        /// <param name="argb">The unsigned integer representing the colour.</param>
        public Color(uint argb)
        {
            a = (byte)((argb >> 24) & 255);
            r = (byte)((argb >> 16) & 255);
            g = (byte)((argb >> 8) & 255);
            b = (byte)(argb & 255);
        }

        /// <summary>
        /// Constructs a colour from another colour and a new alpha value.
        /// </summary>
        /// <param name="color">The template colour.</param>
        /// <param name="newAlpha">The new alpha value.</param>
        public Color(Color color, byte newAlpha)
        {
            r = color.r;
            g = color.g;
            b = color.b;
            a = newAlpha;
        }

        #endregion

        #region Static Methods

        #region Construction

        /// <summary>
        /// Creates a colour from hue, saturation and value.
        /// </summary>
        /// <param name="h">Hue of the colour (0-2pi).</param>
        /// <param name="s">Saturation of the colour (0-1).</param>
        /// <param name="v">Value of the colour (0-1).</param>
        /// <param name="a">Alpha of the colour.</param>
        /// <returns>The constructed colour.</returns>
        public static Color FromHSVA(float h, float s, float v, byte a = 255)
        {
            var chroma = v * s;
            h /= MathHelper.PiOver3;
            var x = chroma * (1 - Math.Abs(h % 2 - 1));
            var m = v - chroma;
            float r, g, b;
            if (h > 6 || h < 0)
            {
                r = 0;
                g = 0;
                b = 0;
            }
            else if (h < 1)
            {
                r = chroma;
                g = x;
                b = 0;
            }
            else if (h < 2)
            {
                r = x;
                g = chroma;
                b = 0;
            }
            else if (h < 3)
            {
                r = 0;
                g = chroma;
                b = x;
            }
            else if (h < 4)
            {
                r = 0;
                g = x;
                b = chroma;
            }
            else if (h < 5)
            {
                r = x;
                g = 0;
                b = chroma;
            }
            else
            {
                r = chroma;
                g = 0;
                b = x;
            }

            return new Color((byte) ((r + m) * 255), (byte) ((g + m) * 255), (byte) ((b + m) * 255), a);
        }

        /// <summary>
        /// Creates a new gray color.
        /// </summary>
        /// <param name="value">The value (brightness) of the color.</param>
        /// <param name="alpha">The opacity of the color.</param>
        /// <returns>A gray colour with the given value and transparency.</returns>
        public static Color GrayScale(byte value, byte alpha = 255)
        {
            return new Color(value, value, value, alpha);
        }

        #endregion

        #region Other

        /// <summary>
        /// Linearly interpolates between two colours and returns the result.
        /// </summary>
        /// <param name="color0">The first colour.</param>
        /// <param name="color1">The second colour.</param>
        /// <param name="p">Interpolation parameter, is clamped to [0, 1]</param>
        /// <returns>The interpolated colour</returns>
        public static Color Lerp(Color color0, Color color1, float p)
        {
            if (p <= 0)
                return color0;
            if (p >= 1)
                return color1;

            var q = 1 - p;
            return new Color(
                (byte) (color0.r * q + color1.r * p),
                (byte) (color0.g * q + color1.g * p),
                (byte) (color0.b * q + color1.b * p),
                (byte) (color0.a * q + color1.a * p)
            );
        }

        #endregion

        #endregion

        #region Properties
        
        // ReSharper disable ConvertToAutoPropertyWhenPossible
        // Disable converting to auto-properties because we want to ensure the correct sequential layout of this struct.

        /// <summary>
        /// The colour's red value
        /// </summary>
        public byte R => r;

        /// <summary>
        /// The colour's green value
        /// </summary>
        public byte G => g;

        /// <summary>
        /// The colour's blue value
        /// </summary>
        public byte B => b;

        /// <summary>
        /// The colour's alpha value (0 = fully transparent, 255 = fully opaque)
        /// </summary>
        public byte A => a;

        // ReSharper restore ConvertToAutoPropertyWhenPossible

        /// <summary>
        /// The colour, represented as 32bit unsigned integer, with its colour components in the order ARGB.
        /// </summary>
        public uint ARGB =>
            ((uint)a << 24)
            | ((uint)r << 16)
            | ((uint)g << 8)
            | b;

        /// <summary>
        /// Returns the value (lightness) of the colour in the range 0 to 1.
        /// </summary>
        public float Value => Math.Max(r, Math.Max(g, b)) / 255f;

        /// <summary>
        /// Returns the saturation of the colour in the range 0 to 1.
        /// </summary>
        public float Saturation
        {
            get
            {
                var max = Math.Max(r, Math.Max(g, b));
                if (max == 0)
                    return 0;

                var min = Math.Min(r, Math.Min(g, b));

                return (float)(max - min) / max;
            }
        }

        /// <summary>
        /// Returns the hue of the colour in the range 0 to 2pi.
        /// </summary>
        public float Hue
        {
            get
            {
                var floatR = r / 255f;
                var floatG = g / 255f;
                var floatB = b / 255f;

                float h;

                var max = Math.Max(floatR, Math.Max(floatG, floatB));
                // ReSharper disable once CompareOfFloatsByEqualityOperator
                if (max == 0)
                    return 0;

                var min = Math.Min(floatR, Math.Min(floatG, floatB));
                var delta = max - min;

                // ReSharper disable once CompareOfFloatsByEqualityOperator
                if (floatR == max)
                    h = (floatG - floatB) / delta;
                // ReSharper disable once CompareOfFloatsByEqualityOperator
                else if (floatG == max)
                    h = 2 + (floatB - floatR) / delta;
                else
                    h = 4 + (floatR - floatG) / delta;

                h *= (float)(Math.PI / 3);
                if (h < 0)
                    h += (float)(Math.PI * 2);

                return h;
            }
        }

        /// <summary>
        /// Converts the colour to a float vector with components Hue, Saturation, Value in that order.
        /// The range of the hue is 0 to 2pi, the range of all over components is 0 to 1.
        /// </summary>
        public Vector4 AsHSVAVector
        {
            get
            {
                var floatR = r / 255f;
                var floatG = g / 255f;
                var floatB = b / 255f;
                var floatA = a / 255f;

                var max = Math.Max(floatR, Math.Max(floatG, floatB));
                // ReSharper disable once CompareOfFloatsByEqualityOperator
                if (max == 0)
                    return new Vector4(0, 0, 0, floatA);

                var v = max;
                var min = Math.Min(floatR, Math.Min(floatG, floatB));
                var delta = max - min;

                var s = delta / max;

                float h;

                // ReSharper disable once CompareOfFloatsByEqualityOperator
                if (floatR == max)
                    h = (floatG - floatB) / delta;
                // ReSharper disable once CompareOfFloatsByEqualityOperator
                else if (floatG == max)
                    h = 2 + (floatB - floatR) / delta;
                else
                    h = 4 + (floatR - floatG) / delta;

                h *= (float)(Math.PI / 3);
                if (h < 0)
                    h += (float)(Math.PI * 2);

                return new Vector4(h, s, v, floatA);
            }
        }

        /// <summary>
        /// Converts the colour to a float vector with components RGBA in that order.
        /// The range of each component is 0 to 1.
        /// </summary>
        public Vector4 AsRGBAVector => new Vector4(r / 255f, g / 255f, b / 255f, a / 255f);


        /// <summary>
        /// The colour, pre-multiplied with its alpha value.
        /// </summary>
        public Color Premultiplied
        {
            get
            {
                var floatA = a / 255f;
                return new Color(
                    (byte)(r * floatA),
                    (byte)(g * floatA),
                    (byte)(b * floatA),
                    a);
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Returns a new colour with the same RGB values, but a different alpha value.
        /// </summary>
        /// <param name="alpha">The new alpha value (0-255).</param>
        public Color WithAlpha(byte alpha = 0) => new Color(this, alpha);

        /// <summary>
        /// Returns a new colour with the same RGB values, but a different alpha value.
        /// </summary>
        /// <param name="alpha">The new alpha value (0-1).</param>
        /// <remarks>
        /// This expects alpha values in the range 0 to 1.
        /// Values outside that range will result in overflow of the valid range and may lead to undesirable values.
        /// </remarks>
        public Color WithAlpha(float alpha) => WithAlpha((byte)(255 * alpha));

        #region Equals, GetHashCode, ToString

        /// <summary>
        /// Checks whether this colour is the same as another.
        /// </summary>
        public bool Equals(Color other) => r == other.r && g == other.g && b == other.b && a == other.a;

        /// <summary>
        /// Checks whether this colour is the same as another.
        /// </summary>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is Color color && Equals(color);
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = r.GetHashCode();
                hashCode = (hashCode * 397) ^ g.GetHashCode();
                hashCode = (hashCode * 397) ^ b.GetHashCode();
                hashCode = (hashCode * 397) ^ a.GetHashCode();
                return hashCode;
            }
        }

        /// <summary>
        /// Returns a hexadecimal <see cref="System.String" /> that represents this color.
        /// </summary>
        /// <returns>
        /// A hexadecimal <see cref="System.String" /> that represents this color.
        /// </returns>
        public override string ToString() => "#" + ARGB.ToString("X8");

        #endregion

        #endregion

        #region Operators

        /// <summary>
        /// Casts the color to equivalent <see cref="System.Drawing.Color"/>
        /// </summary>
        /// <param name="color">The color.</param>
        /// <returns><see cref="System.Drawing.Color"/></returns>
        public static implicit operator System.Drawing.Color(Color color) =>
            System.Drawing.Color.FromArgb(color.a, color.r, color.g, color.b);

        /// <summary>
        /// Compares two colours for equality.
        /// </summary>
        public static bool operator ==(Color color1, Color color2) => color1.Equals(color2);

        /// <summary>
        /// Compares two colours for inequality.
        /// </summary>
        public static bool operator !=(Color color1, Color color2) => !(color1 == color2);

        /// <summary>
        /// Multiplies all components of the colour by a given scalar.
        /// Note that scalar values outside the range of 0 to 1 may result in overflow and cause unexpected results.
        /// </summary>
        public static Color operator *(Color color, float scalar) =>
            new Color(
                (byte)(color.r * scalar),
                (byte)(color.g * scalar),
                (byte)(color.b * scalar),
                (byte)(color.a * scalar));

        /// <summary>
        /// Multiplies all components of the colour by a given scalar.
        /// Note that scalar values outside the range of 0 to 1 may result in overflow and cause unexpected results.
        /// </summary>
        public static Color operator *(float scalar, Color color) => color * scalar;

        #endregion

    }
}
