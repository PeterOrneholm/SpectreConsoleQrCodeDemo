using QRCoder;
using Spectre.Console;

// Sample on how to write a QR code to the console using QRCoder and Spectre.Console

// Note: The more content you add to the QR-code, the more "pixels" it will require.
//       As a pixel is represented as an ASCII-char in the console it might be quite large.
//       I've noted that large QR-codes requires the user to scale down the font size to fit the QR code on a normal screen.

var canvas = GetQrCanvas("https://www.youtube.com/watch?v=dQw4w9WgXcQ");
AnsiConsole.Write(canvas);
Console.ReadLine();

static Canvas GetQrCanvas(string content)
{
    using var qrGenerator = new QRCodeGenerator();
    var qrCodeData = qrGenerator.CreateQrCode(content, QRCodeGenerator.ECCLevel.L);
    var matrix = qrCodeData.ModuleMatrix;
    var width = matrix.First().Length;
    var height = matrix.Count;
    var canvas = new Canvas(width, height);

    for (var y = 0; y < matrix.Count; y++)
    {
        for (var x = 0; x < matrix[y].Length; x++)
        {
            canvas.SetPixel(x, y, matrix[y][x] ? Color.Black : Color.White);
        }
    }

    return canvas;
}