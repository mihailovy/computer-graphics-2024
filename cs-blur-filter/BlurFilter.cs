using System.Drawing;

class Program
{
    private static Bitmap myBitmap;
	
	private static void BlurPoint(int x, int y)
	{
		Color c  = myBitmap.GetPixel(x  , y  );
		Color t  = myBitmap.GetPixel(x  , y-1);
		Color b  = myBitmap.GetPixel(x  , y+1);
		Color l  = myBitmap.GetPixel(x-1, y);
		Color r  = myBitmap.GetPixel(x+1, y);
		Color tl = myBitmap.GetPixel(x-1, y-1);
		Color tr = myBitmap.GetPixel(x-1, y+1);
		Color bl = myBitmap.GetPixel(x+1, y-1);
		Color br = myBitmap.GetPixel(x+1, y+1);		
		int red   = (t.R + b.R + l.R + r.R + tr.R + bl.R + bl.R + br.R) / 8;
		int green = (t.G + b.G + l.G + r.G + tr.G + bl.G + bl.G + br.G) / 8;
		int blue  = (t.B + b.B + l.B + r.B + tr.B + bl.B + bl.B + br.B) / 8;
		int alpha = (t.A + b.A + l.A + r.A + tr.A + bl.A + bl.A + br.A) / 8;
		Color newColor = Color.FromArgb(alpha, red, green, blue);
		myBitmap.SetPixel(x, y, newColor);
	}
	
	public static void BlurImage()
	{	
		for (int x = 1; x < myBitmap.Width-1; x++) {
			for (int y = 1; y < myBitmap.Height-1; y++) { 
				//Color pixelColor = myBitmap.GetPixel(x, y);
				BlurPoint(x, y);
				// things we do with pixelColor
			}
		}
	}
	
    public static void Main(string[] args)
    {
		myBitmap = new Bitmap("lady.jpg");  
		BlurImage();
		BlurImage();
		BlurImage();
		BlurImage();
		BlurImage();
		BlurImage();
		BlurImage();
		myBitmap.Save("lady2.jpg");
	}
}
