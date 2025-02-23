[![NuGet](https://img.shields.io/nuget/v/IronSoftware.System.Drawing?color=informational&label=latest&logo=nuget)](https://www.nuget.org/packages/IronSoftware.System.Drawing/) [![Installs](https://img.shields.io/nuget/dt/IronSoftware.System.Drawing?color=informational&label=installs&logo=nuget)](https://www.nuget.org/packages/IronSoftware.System.Drawing/) [![GitHub Latest Commit](https://img.shields.io/github/last-commit/iron-software/IronSoftware.Drawing.Common?color=informational&logo=github)](https://github.com/iron-software/IronSoftware.Drawing.Common) [![GitHub Contributors](https://img.shields.io/github/contributors/iron-software/IronSoftware.Drawing.Common?color=informational&logo=github)](https://github.com/iron-software/IronSoftware.Drawing.Common)

# IronSoftware.Drawing - Image, Color, Rectangle, and Font class for .NET Applications

**IronSoftware.Drawing** is an open-source library originally developed by Iron Software that helps C# Software Engineers to replace System.Drawing.Common in .NET projects.

## Table of Contents

- [Features](#ironsoftwaredrawing-features)
  - [Compatibility](#ironsoftwaredrawing-has-cross-platform-support-compatibility-with)
- [Using IronSoftware.Drawing](#using-ironsoftwaredrawing)
  - [AnyBitmap Example](#anybitmap-code-example)
  - [Color Example](#color-code-example)
  - [CropRectangle Example](#croprectangle-code-example)
  - [Font Example](#font-code-example)
- [Support](#support-available)

## IronSoftware.Drawing Features:
- **AnyBitmap**: A universally compatible Bitmap class. Implicit casting between `IronSoftware.Drawing.AnyBitmap` and following popular Bitmap/Image formats supported:

| **Implicit Casting Support** | To `AnyBitmap` Supported | From `AnyBitmap` Supported |
|------------------------------------------------------------------------|:--------------------------:|:----------------------------:|
|                           `System.Drawing.Bitmap`                          |              ✅             |               ✅              |
|                           `System.Drawing.Image`                           |              ✅             |               ✅              |
|                            `SkiaSharp.SKBitmap`                            |              ✅             |               ✅              |
|                             `SkiaSharp.SKImage`                            |              ✅             |               ✅              |
|                           `SixLabors.ImageSharp`                           |              ✅             |               ✅              |
|              `Microsoft.Maui.Graphics.Platform.PlatformImage`              |              ✅             |               ✅              |

- **Color**: A universally compatible Color class. Implicit casting between `IronSoftware.Drawing.Color` and following popular Color formats supported:

|     **Implicit Casting Support**    | To `Color` Supported | From `Color` Supported |
|-----------------------------------|:--------------------:|:----------------------:|
|         `SkiaSharp.SKColor`         |           ✅          |            ✅           |
|     `SixLabors.ImageSharp.Color`    |           ✅          |            ✅           |
| `SixLabors.ImageSharp.PixelFormats` |           ✅          |            ✅           |
  
- **CropRectangle**: A universally compatible Rectangle class. Implicit casting between `IronSoftware.Drawing.CropRectangle` and following popular Rectangle formats supported:

|   **Implicit Casting Support**   | To `CropRectangle` Supported | From `CropRectangle` Supported |
|--------------------------------|:----------------------------:|:------------------------------:|
|    `System.Drawing.Rectangle`    |               ✅              |                ✅               |
|        `SkiaSharp.SKRect`        |               ✅              |                ✅               |
|        `SkiaSharp.SKRectI`       |               ✅              |                ✅               |
| `SixLabors.ImageSharp.Rectangle` |               ✅              |                ✅               |

- **Font**: A universally compatible Font class. Implicit casting between `IronSoftware.Drawing.Font` and following popular Font formats supported:

| **Implicit Casting Support** | To `Font` Supported | From `Font` Supported |
|----------------------------|:-------------------:|:---------------------:|
|     `System.Drawing.Font`    |          ✅          |           ✅           |
|      `SkiaSharp.SKFont`      |          ✅          |           ✅           |
|    `SixLabors.Fonts.Font`    |          ✅          |           ✅           |

- **Point** and **PointF**: Universally compatible Point and PointF classes. Implicit casting between `IronSoftware.Drawing.Point` and `IronSoftware.Drawing.PointF` and the following supported:

|   **Implicit Casting Support**   | To `Point` Supported | From `Point` Supported | To `PointF` Supported | From `PointF` Supported |
|--------------------------------|:----------------------------:|:------------------------------:|:----------------------------:|:------------------------------:|
| `System.Drawing.Point`            |               ✅              |                ✅               |                              |                                |
| `SixLabors.ImageSharp.Point`      |               ✅              |                ✅               |                              |                                |
| `SixLabors.ImageSharp.PointF`     |                              |                                |               ✅              |                ✅               |
| `Microsoft.Maui.Graphics.Point`   |               ✅              |                ✅               |                              |                                |
| `Microsoft.Maui.Graphics.PointF`  |                              |                                |               ✅              |                ✅               |
| `SkiaSharp.SKPoint`               |                              |                                |               ✅              |                ✅               |
| `SkiaSharp.SKPointI`              |               ✅              |                ✅               |                              |                                |

### IronSoftware.Drawing has cross platform support compatibility with:
- .NET 7, .NET 6, .NET 5, .NET Core, Standard, and Framework
- Windows, macOS, Linux, Docker, Azure, and AWS

## Using IronSoftware.Drawing

Installing the IronSoftware.Drawing NuGet package is quick and easy, please install the package like this:
```
PM> Install-Package IronSoftware.System.Drawing
```
Alternatively, download directly from the [official NuGet website](https://www.nuget.org/packages/IronSoftware.System.Drawing).


Once installed, you can get started by adding `using IronSoftware.Drawing;` to the top of your C# code.
### `AnyBitmap` Code Example
```csharp
using IronSoftware.Drawing;

// Create a new AnyBitmap object
var bitmap = AnyBitmap.FromFile("FILE_PATH");
bitmap.SaveAs("result.jpg");

var bytes = bitmap.ExportBytes();

var resultExport = new System.IO.MemoryStream();
bimtap.ExportStream(resultExport, AnyBitmap.ImageFormat.Jpeg, 100);

// Casting between System.Drawing.Bitmap and IronSoftware.Drawing.AnyBitmap
System.Drawing.Bitmap image = new System.Drawing.Bitmap("FILE_PATH");
IronSoftware.Drawing.AnyBitmap anyBitmap = image;
anyBitmap.SaveAs("result-from-casting.png");


// Creates a Multi-page Tiff-style AnyBitmap from an Image array
List<AnyBitmap> bitmaps = new List<AnyBitmap>()
{
    AnyBitmap.FromFile("FILE_PATH_1"),
    AnyBitmap.FromFile("FILE_PATH_2")
};
AnyBitmap anyBitmap = AnyBitmap.CreateMultiFrameTiff(bitmaps);

// Creates a Multi-page Tiff-style AnyBitmap from a fully qualified file path array
List<string> imagePaths = new List<string>()
{
    "FILE_PATH_1",
    "FILE_PATH_2"
};
AnyBitmap anyBitmap = AnyBitmap.CreateMultiFrameTiff(imagePaths);

// Manipulate image frames
int frameCount = anyBitmap.FrameCount;
List<AnyBitmap> frames = anyBitmap.GetAllFrames();
```
### `Color` Code Example
```csharp
using IronSoftware.Drawing;

// Create a new Color object
Color fromHex = new Color("#191919");
Color fromRgb = new Color(255, 255, 0);
Color fromEnum = Color.Crimson;

// Casting between System.Drawing.Color and IronSoftware.Drawing.Color
System.Drawing.Color drawingColor = System.Drawing.Color.Red;
IronSoftware.Drawing.Color ironColor = drawingColor;

ironColor.A;
ironColor.R;
ironColor.G;
ironColor.B;

// Luminance is a value from 0 (black) to 100 (white) where 50 is the perceptual "middle grey"
ironColor.GetLuminance();

// Gets the 32-bit ARGB value of this Color structure.
ironColor.ToArgb()
```
### `CropRectangle` Code Example
```csharp
using IronSoftware.Drawing;

// Create a new CropRectangle object
CropRectangle cropRectangle = new CropRectangle(5, 5, 50, 50);

// Create a new CropRectangle object with MeasurementUnits
CropRectangle mmRectangle = new CropRectangle(5, 5, 50, 50, MeasurementUnits.Millimeters);

// Convert between MeasurementUnits
CropRectangle pxRectangle = mmRectangle.ConvertTo(MeasurementUnits.Millimeters);
// Or specify DPI
CropRectangle pxRectangleWithDPI = mmRectangle.ConvertTo(MeasurementUnits.Millimeters, 200);

// Casting between System.Drawing.Rectangle and IronSoftware.Drawing.CropRectangle
System.Drawing.Rectangle rectangle = new System.Drawing.Rectangle(10, 10, 150, 150);
IronSoftware.Drawing.CropRectangle ironRectangle = rectangle;

ironRectangle.X;
ironRectangle.Y;
ironRectangle.Width;
ironRectangle.Height;
```
### `Font` Code Example
```csharp
using IronSoftware.Drawing;

// Create a new Font object
Font font = new Font("Times New Roman", FontStyle.Italic | FontStyle.Bold, 30);

// Casting between System.Drawing.Font and IronSoftware.Drawing.Font
System.Drawing.Font drawingFont = new System.Drawing.Font("Courier New", 30);
IronSoftware.Drawing.Font ironFont = drawingFont;

ironFont.FamilyName;
ironFont.Style;
ironFont.Size;
ironFont.Italic;
ironFont.Bold;
```

## Support Available

For more information about Iron Software please visit our website: [https://ironsoftware.com/](https://ironsoftware.com/)

For general support and technical inquiries, please email us at: developers@ironsoftware.com
