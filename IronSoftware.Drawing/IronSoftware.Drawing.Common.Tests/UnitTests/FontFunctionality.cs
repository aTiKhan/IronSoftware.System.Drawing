﻿using FluentAssertions;
using System;
using System.Runtime.InteropServices;
using Xunit;
using Xunit.Abstractions;

namespace IronSoftware.Drawing.Common.Tests.UnitTests
{
    public class FontFunctionality : TestsBase
    {
        public FontFunctionality(ITestOutputHelper output) : base(output)
        {
        }

        [FactWithAutomaticDisplayName]
        public void Create_new_Font()
        {

            var font = new Font("Roboto Serif");
            _ = font.FamilyName.Should().Be("Roboto Serif");
            _ = font.Style.Should().Be(FontStyle.Regular);
            _ = font.Size.Should().Be(12);
            _ = font.Bold.Should().BeFalse();
            _ = font.Italic.Should().BeFalse();

            font = new Font("Roboto", 20);
            _ = font.FamilyName.Should().Be("Roboto");
            _ = font.Style.Should().Be(FontStyle.Regular);
            _ = font.Size.Should().Be(20);
            _ = font.Bold.Should().BeFalse();
            _ = font.Italic.Should().BeFalse();

            font = new Font("Roboto Mono", FontStyle.Bold | FontStyle.Strikeout);
            _ = font.FamilyName.Should().Be("Roboto Mono");
            _ = font.Style.Should().Be(FontStyle.Bold | FontStyle.Strikeout);
            _ = font.Size.Should().Be(12);
            _ = font.Bold.Should().BeTrue();
            _ = font.Strikeout.Should().BeTrue();

            font = new Font("Roboto Flex", FontStyle.Italic | FontStyle.Underline, 30);
            _ = font.FamilyName.Should().Be("Roboto Flex");
            _ = font.Style.Should().Be(FontStyle.Italic | FontStyle.Underline);
            _ = font.Size.Should().Be(30);
            _ = font.Italic.Should().BeTrue();
            _ = font.Underline.Should().BeTrue();

        }

        [FactWithAutomaticDisplayName]
        public void CastSKFont_to_Font()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                SkiaSharp.SKFont skFont = SkiaSharp.SKTypeface.FromFamilyName("Liberation Mono", SkiaSharp.SKFontStyleWeight.Normal, SkiaSharp.SKFontStyleWidth.Normal, SkiaSharp.SKFontStyleSlant.Upright).ToFont(30);
                Font font = skFont;
                _ = font.FamilyName.Should().Be("Liberation Mono");
                _ = font.Size.Should().Be(30);
                _ = font.Style.Should().Be(FontStyle.Regular);
                _ = font.Bold.Should().BeFalse();
                _ = font.Italic.Should().BeFalse();

                skFont = new SkiaSharp.SKFont(SkiaSharp.SKTypeface.FromFamilyName("Liberation Serif", SkiaSharp.SKFontStyleWeight.Bold, SkiaSharp.SKFontStyleWidth.Normal, SkiaSharp.SKFontStyleSlant.Italic), 20);
                font = skFont;
                _ = font.FamilyName.Should().Be("Liberation Serif");
                _ = font.Size.Should().Be(20);
                _ = font.Style.Should().Be(FontStyle.Bold | FontStyle.Italic);
                _ = font.Bold.Should().BeTrue();
                _ = font.Italic.Should().BeTrue();
            }
            else
            {
                SkiaSharp.SKFont skFont = SkiaSharp.SKTypeface.FromFamilyName("Courier New", SkiaSharp.SKFontStyleWeight.Normal, SkiaSharp.SKFontStyleWidth.Normal, SkiaSharp.SKFontStyleSlant.Upright).ToFont(30);
                Font font = skFont;
                _ = font.FamilyName.Should().Be("Courier New");
                _ = font.Size.Should().Be(30);
                _ = font.Style.Should().Be(FontStyle.Regular);
                _ = font.Bold.Should().BeFalse();
                _ = font.Italic.Should().BeFalse();

                skFont = new SkiaSharp.SKFont(SkiaSharp.SKTypeface.FromFamilyName("Times New Roman", SkiaSharp.SKFontStyleWeight.Bold, SkiaSharp.SKFontStyleWidth.Normal, SkiaSharp.SKFontStyleSlant.Italic), 20);
                font = skFont;
                _ = font.FamilyName.Should().Be("Times New Roman");
                _ = font.Size.Should().Be(20);
                _ = font.Style.Should().Be(FontStyle.Bold | FontStyle.Italic);
                _ = font.Bold.Should().BeTrue();
                _ = font.Italic.Should().BeTrue();
            }
        }

        [FactWithAutomaticDisplayName]
        public void CastSKFont_from_Font()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                var font = new Font("Courier New", 30);
                SkiaSharp.SKFont skFont = font;
                _ = skFont.Typeface.FamilyName.Should().Be("Liberation Mono");
                _ = skFont.Size.Should().Be(30);
                _ = skFont.Typeface.FontStyle.Slant.Should().Be(SkiaSharp.SKFontStyleSlant.Upright);
                _ = skFont.Typeface.FontStyle.Weight.Should().Be((int)SkiaSharp.SKFontStyleWeight.Normal);
                _ = skFont.Typeface.FontStyle.Width.Should().Be((int)SkiaSharp.SKFontStyleWidth.Normal);
                _ = skFont.Typeface.IsBold.Should().BeFalse();
                _ = skFont.Typeface.IsItalic.Should().BeFalse();

                font = new Font("Liberation Serif", FontStyle.Bold | FontStyle.Italic, 20);
                skFont = font;
                _ = skFont.Typeface.FamilyName.Should().Be("Liberation Serif");
                _ = skFont.Size.Should().Be(20);
                _ = skFont.Typeface.FontStyle.Slant.Should().Be(SkiaSharp.SKFontStyleSlant.Italic);
                _ = skFont.Typeface.FontStyle.Weight.Should().Be((int)SkiaSharp.SKFontStyleWeight.Bold);
                _ = skFont.Typeface.FontStyle.Width.Should().Be((int)SkiaSharp.SKFontStyleWidth.Normal);
                _ = skFont.Typeface.IsBold.Should().BeTrue();
                _ = skFont.Typeface.IsItalic.Should().BeTrue();
            }
            else
            {
                var font = new Font("Courier New", 30);
                SkiaSharp.SKFont skFont = font;
                _ = skFont.Typeface.FamilyName.Should().Be("Courier New");
                _ = skFont.Size.Should().Be(30);
                _ = skFont.Typeface.FontStyle.Slant.Should().Be(SkiaSharp.SKFontStyleSlant.Upright);
                _ = skFont.Typeface.FontStyle.Weight.Should().Be((int)SkiaSharp.SKFontStyleWeight.Normal);
                _ = skFont.Typeface.FontStyle.Width.Should().Be((int)SkiaSharp.SKFontStyleWidth.Normal);
                _ = skFont.Typeface.IsBold.Should().BeFalse();
                _ = skFont.Typeface.IsItalic.Should().BeFalse();

                font = new Font("Times New Roman", FontStyle.Bold | FontStyle.Italic, 20);
                skFont = font;
                _ = skFont.Typeface.FamilyName.Should().Be("Times New Roman");
                _ = skFont.Size.Should().Be(20);
                _ = skFont.Typeface.FontStyle.Slant.Should().Be(SkiaSharp.SKFontStyleSlant.Italic);
                _ = skFont.Typeface.FontStyle.Weight.Should().Be((int)SkiaSharp.SKFontStyleWeight.Bold);
                _ = skFont.Typeface.FontStyle.Width.Should().Be((int)SkiaSharp.SKFontStyleWidth.Normal);
                _ = skFont.Typeface.IsBold.Should().BeTrue();
                _ = skFont.Typeface.IsItalic.Should().BeTrue();
            }
        }

        [IgnoreOnMacFact]
        public void CastSystemDrawingFont_to_Font()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                var drawingFont = new System.Drawing.Font("Liberation Mono", 30);
                Font font = drawingFont;
                _ = font.FamilyName.Should().Be("Liberation Mono");
                _ = font.Size.Should().Be(30);
                _ = font.Style.Should().Be(FontStyle.Regular);
                _ = font.Bold.Should().BeFalse();
                _ = font.Italic.Should().BeFalse();

                drawingFont = new System.Drawing.Font("Liberation Serif", 20, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic);
                font = drawingFont;
                _ = font.FamilyName.Should().Be("Liberation Serif");
                _ = font.Size.Should().Be(20);
                _ = font.Style.Should().Be(FontStyle.Bold | FontStyle.Italic);
                _ = font.Bold.Should().BeTrue();
                _ = font.Italic.Should().BeTrue();
            }
            else
            {
                var drawingFont = new System.Drawing.Font("Courier New", 30);
                Font font = drawingFont;
                _ = font.FamilyName.Should().Be("Courier New");
                _ = font.Size.Should().Be(30);
                _ = font.Style.Should().Be(FontStyle.Regular);
                _ = font.Bold.Should().BeFalse();
                _ = font.Italic.Should().BeFalse();

                drawingFont = new System.Drawing.Font("Times New Roman", 20, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic);
                font = drawingFont;
                _ = font.FamilyName.Should().Be("Times New Roman");
                _ = font.Size.Should().Be(20);
                _ = font.Style.Should().Be(FontStyle.Bold | FontStyle.Italic);
                _ = font.Bold.Should().BeTrue();
                _ = font.Italic.Should().BeTrue();
            }
        }

        [IgnoreOnMacFact]
        public void CastSystemDrawingFont_from_Font()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                var font = new Font("Liberation Mono", 30);
                System.Drawing.Font drawingFont = font;
                _ = drawingFont.FontFamily.Name.Should().Be("Liberation Mono");
                _ = drawingFont.Size.Should().Be(30);
                _ = drawingFont.Style.Should().Be(System.Drawing.FontStyle.Regular);
                _ = drawingFont.Bold.Should().BeFalse();
                _ = drawingFont.Italic.Should().BeFalse();

                font = new Font("Liberation Serif", FontStyle.Bold | FontStyle.Italic, 20);
                drawingFont = font;
                _ = drawingFont.FontFamily.Name.Should().Be("Liberation Serif");
                _ = drawingFont.Size.Should().Be(20);
                _ = drawingFont.Style.Should().Be(System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic);
                _ = drawingFont.Bold.Should().BeTrue();
                _ = drawingFont.Italic.Should().BeTrue();
            }
            else
            {
                var font = new Font("Courier New", 30);
                System.Drawing.Font drawingFont = font;
                _ = drawingFont.FontFamily.Name.Should().Be("Courier New");
                _ = drawingFont.Size.Should().Be(30);
                _ = drawingFont.Style.Should().Be(System.Drawing.FontStyle.Regular);
                _ = drawingFont.Bold.Should().BeFalse();
                _ = drawingFont.Italic.Should().BeFalse();

                font = new Font("Times New Roman", FontStyle.Bold | FontStyle.Italic, 20);
                drawingFont = font;
                _ = drawingFont.FontFamily.Name.Should().Be("Times New Roman");
                _ = drawingFont.Size.Should().Be(20);
                _ = drawingFont.Style.Should().Be(System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic);
                _ = drawingFont.Bold.Should().BeTrue();
                _ = drawingFont.Italic.Should().BeTrue();
            }
        }

        [FactWithAutomaticDisplayName]
        public void CastSixLaborsFont_to_Font()
        {

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                SixLabors.Fonts.Font sixLaborsFont = SixLabors.Fonts.SystemFonts.CreateFont("Liberation Mono", 30);
                Font font = sixLaborsFont;
                _ = font.FamilyName.Should().Be("Liberation Mono");
                _ = font.Size.Should().Be(30);
                _ = font.Style.Should().Be(FontStyle.Regular);
                _ = font.Bold.Should().BeFalse();
                _ = font.Italic.Should().BeFalse();

                sixLaborsFont = SixLabors.Fonts.SystemFonts.CreateFont("Liberation Serif", 20, SixLabors.Fonts.FontStyle.BoldItalic);
                font = sixLaborsFont;
                _ = font.FamilyName.Should().Be("Liberation Serif");
                _ = font.Size.Should().Be(20);
                _ = font.Style.Should().Be(FontStyle.Bold | FontStyle.Italic);
                _ = font.Bold.Should().BeTrue();
                _ = font.Italic.Should().BeTrue();
            }
            else
            {
                SixLabors.Fonts.Font sixLaborsFont = SixLabors.Fonts.SystemFonts.CreateFont("Courier New", 30);
                Font font = sixLaborsFont;
                _ = font.FamilyName.Should().Be("Courier New");
                _ = font.Size.Should().Be(30);
                _ = font.Style.Should().Be(FontStyle.Regular);
                _ = font.Bold.Should().BeFalse();
                _ = font.Italic.Should().BeFalse();

                sixLaborsFont = SixLabors.Fonts.SystemFonts.CreateFont("Times New Roman", 20, SixLabors.Fonts.FontStyle.BoldItalic);
                font = sixLaborsFont;
                _ = font.FamilyName.Should().Be("Times New Roman");
                _ = font.Size.Should().Be(20);
                _ = font.Style.Should().Be(FontStyle.Bold | FontStyle.Italic);
                _ = font.Bold.Should().BeTrue();
                _ = font.Italic.Should().BeTrue();
            }
        }

        [FactWithAutomaticDisplayName]
        public void CastSixLaborsFont_from_Font()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                var font = new Font("Liberation Mono", 30);
                SixLabors.Fonts.Font sixLaborsFont = font;
                _ = sixLaborsFont.Family.Name.Should().Be("Liberation Mono");
                _ = sixLaborsFont.Size.Should().Be(30);
                _ = sixLaborsFont.IsBold.Should().BeFalse();
                _ = sixLaborsFont.IsItalic.Should().BeFalse();

                font = new Font("Liberation Serif", FontStyle.Bold | FontStyle.Italic, 20);
                sixLaborsFont = font;
                _ = sixLaborsFont.Family.Name.Should().Be("Liberation Serif");
                _ = sixLaborsFont.Size.Should().Be(20);
                _ = sixLaborsFont.IsBold.Should().BeTrue();
                _ = sixLaborsFont.IsItalic.Should().BeTrue();
            }
            else
            {
                var font = new Font("Courier New", 30);
                SixLabors.Fonts.Font sixLaborsFont = font;
                _ = sixLaborsFont.Family.Name.Should().Be("Courier New");
                _ = sixLaborsFont.Size.Should().Be(30);
                _ = sixLaborsFont.IsBold.Should().BeFalse();
                _ = sixLaborsFont.IsItalic.Should().BeFalse();

                font = new Font("Times New Roman", FontStyle.Bold | FontStyle.Italic, 20);
                sixLaborsFont = font;
                _ = sixLaborsFont.Family.Name.Should().Be("Times New Roman");
                _ = sixLaborsFont.Size.Should().Be(20);
                _ = sixLaborsFont.IsBold.Should().BeTrue();
                _ = sixLaborsFont.IsItalic.Should().BeTrue();
            }
        }

        [TheoryWithAutomaticDisplayName]
        [InlineData("Arial", "Arial", FontStyle.Regular)]
        [InlineData("Arial-Bold", "Arial", FontStyle.Bold)]
        [InlineData("Arial-Italic", "Arial", FontStyle.Italic)]
        [InlineData("Arial-BoldItalic", "Arial", FontStyle.BoldItalic)]
        [InlineData("CourierNew", "Courier New", FontStyle.Regular)]
        [InlineData("CourierNew-Bold", "Courier New", FontStyle.Bold)]
        [InlineData("CourierNew-Italic", "Courier New", FontStyle.Italic)]
        [InlineData("CourierNew-BoldItalic", "Courier New", FontStyle.BoldItalic)]
        [InlineData("Helvetica", "Helvetica", FontStyle.Regular)]
        [InlineData("Helvetica-Bold", "Helvetica", FontStyle.Bold)]
        [InlineData("Helvetica-Oblique", "Helvetica", FontStyle.Italic)]
        [InlineData("Helvetica-BoldOblique", "Helvetica", FontStyle.BoldItalic)]
        [InlineData("TimesNewRoman", "Times New Roman", FontStyle.Regular)]
        [InlineData("TimesNewRoman-Bold", "Times New Roman", FontStyle.Bold)]
        [InlineData("TimesNewRoman-Italic", "Times New Roman", FontStyle.Italic)]
        [InlineData("TimesNewRoman-BoldItalic", "Times New Roman", FontStyle.BoldItalic)]
        public void CastFontTypes_to_Font(string fontTypesName, string expectedFontName, FontStyle expectedFontStyle)
        {
            IronSoftware.Drawing.FontTypes fontTypes = IronSoftware.Drawing.FontTypes.FromString(fontTypesName);
            Font font = fontTypes; // Implicit cast

            font.FamilyName.Should().Be(expectedFontName);
            font.Style.Should().Be(expectedFontStyle);
        }

        [TheoryWithAutomaticDisplayName]
        [InlineData("Arial", "Arial", FontStyle.Regular)]
        [InlineData("Arial-Bold", "Arial", FontStyle.Bold)]
        [InlineData("Arial-Italic", "Arial", FontStyle.Italic)]
        [InlineData("Arial-BoldItalic", "Arial", FontStyle.BoldItalic)]
        [InlineData("CourierNew", "Courier New", FontStyle.Regular)]
        [InlineData("CourierNew-Bold", "Courier New", FontStyle.Bold)]
        [InlineData("CourierNew-Italic", "Courier New", FontStyle.Italic)]
        [InlineData("CourierNew-BoldItalic", "Courier New", FontStyle.BoldItalic)]
        [InlineData("Helvetica", "Helvetica", FontStyle.Regular)]
        [InlineData("Helvetica-Bold", "Helvetica", FontStyle.Bold)]
        [InlineData("Helvetica-Oblique", "Helvetica", FontStyle.Italic)]
        [InlineData("Helvetica-BoldOblique", "Helvetica", FontStyle.BoldItalic)]
        [InlineData("TimesNewRoman", "Times New Roman", FontStyle.Regular)]
        [InlineData("TimesNewRoman-Bold", "Times New Roman", FontStyle.Bold)]
        [InlineData("TimesNewRoman-Italic", "Times New Roman", FontStyle.Italic)]
        [InlineData("TimesNewRoman-BoldItalic", "Times New Roman", FontStyle.BoldItalic)]
        public void CastFontTypes_from_Font(string expectedfontTypeName, string fontName, FontStyle fontStyle)
        {
            var font = new Font(fontName, fontStyle);

            IronSoftware.Drawing.FontTypes fontTypes = font; // Implicit cast

            fontTypes.Name.Should().Be(expectedfontTypeName);
        }

        [TheoryWithAutomaticDisplayName]
        [InlineData("Comic Sans MS", FontStyle.Regular)]
        [InlineData("Optima", FontStyle.Bold)]
        [InlineData("Gill Sans", FontStyle.Italic)]
        [InlineData("Garamond", FontStyle.BoldItalic)]
        public void CastFontTypes_from_Font_Should_throw_exception(string fontName, FontStyle fontStyle)
        {
            var font = new Font(fontName, fontStyle);

            Exception ex = Assert.Throws<InvalidCastException>(() =>
            {
                IronSoftware.Drawing.FontTypes fontTypes = font; // Implicit cast
            });

            string expectedFontName = fontStyle switch
            {
                FontStyle.Bold => $"{fontName.Replace(" ", "")}-Bold",
                FontStyle.Italic => $"{fontName.Replace(" ", "")}-Italic",
                FontStyle.BoldItalic => $"{fontName.Replace(" ", "")}-BoldItalic",
                _ => fontName.Replace(" ", "")
            };

            Assert.Contains($"You have set a non PDF standatd FontType: {expectedFontName}, Please select one from IronSoftware.Drawing.FontTypes.", ex.Message);
        }

#if !NETFRAMEWORK

        [FactWithAutomaticDisplayName]
        public void CastMauiFont_to_Font()
        {

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                var mFont = new Microsoft.Maui.Graphics.Font("Liberation Mono");
                Font font = mFont;
                _ = font.FamilyName.Should().Be("Liberation Mono");
                _ = font.Style.Should().Be(FontStyle.Regular);
                _ = font.Bold.Should().BeFalse();
                _ = font.Italic.Should().BeFalse();

                mFont = new Microsoft.Maui.Graphics.Font("Liberation Serif", 800, Microsoft.Maui.Graphics.FontStyleType.Italic);
                font = mFont;
                _ = font.FamilyName.Should().Be("Liberation Serif");
                _ = font.Style.Should().Be(FontStyle.Bold | FontStyle.Italic);
                _ = font.Bold.Should().BeTrue();
                _ = font.Italic.Should().BeTrue();
            }
            else
            {
                var mFont = new Microsoft.Maui.Graphics.Font("Courier New");
                Font font = mFont;
                _ = font.FamilyName.Should().Be("Courier New");
                _ = font.Style.Should().Be(FontStyle.Regular);
                _ = font.Bold.Should().BeFalse();
                _ = font.Italic.Should().BeFalse();

                mFont = new Microsoft.Maui.Graphics.Font("Times New Roman", 800, Microsoft.Maui.Graphics.FontStyleType.Italic);
                font = mFont;
                _ = font.FamilyName.Should().Be("Times New Roman");
                _ = font.Style.Should().Be(FontStyle.Bold | FontStyle.Italic);
                _ = font.Bold.Should().BeTrue();
                _ = font.Italic.Should().BeTrue();
            }
        }

        [FactWithAutomaticDisplayName]
        public void CastMauiFont_from_Font()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                var font = new Font("Liberation Mono", 30);
                Microsoft.Maui.Graphics.Font mFont = font;
                _ = mFont.Name.Should().Be("Liberation Mono");
                _ = mFont.Weight.Should().Be(400);
                _ = mFont.StyleType.Should().Be(Microsoft.Maui.Graphics.FontStyleType.Normal);

                font = new Font("Liberation Serif", FontStyle.Bold | FontStyle.Italic, 20);
                mFont = font;
                _ = mFont.Name.Should().Be("Liberation Serif");
                _ = mFont.Weight.Should().Be(700);
                _ = mFont.StyleType.Should().Be(Microsoft.Maui.Graphics.FontStyleType.Italic);
            }
            else
            {
                var font = new Font("Courier New", 30);
                Microsoft.Maui.Graphics.Font mFont = font;
                _ = mFont.Name.Should().Be("Courier New");
                _ = mFont.Weight.Should().Be(400);
                _ = mFont.StyleType.Should().Be(Microsoft.Maui.Graphics.FontStyleType.Normal);

                font = new Font("Times New Roman", FontStyle.Bold | FontStyle.Italic, 20);
                mFont = font;
                _ = mFont.Name.Should().Be("Times New Roman");
                _ = mFont.Weight.Should().Be(700);
                _ = mFont.StyleType.Should().Be(Microsoft.Maui.Graphics.FontStyleType.Italic);
            }
        }
#endif
    }
}
