using System;
using System.Drawing;

class Program
{
    private static Bitmap myBitmap;
    private static Bitmap newBitmap;

    private static void FlipPoint(int xi, int yi)
    {
        double x1, y1;
        double x, y;

        x = (double)xi;
        y = (double)yi;
      
        // Calculate the new coordinates of the point
        x1 = x;
        y1 = myBitmap.Height - y;

        // Ensure new coordinates are within bounds
        int newX = (int)Math.Round(x1);
        int newY = (int)Math.Round(y1);

        if (newX >= 0 && newX < newBitmap.Width && newY >= 0 && newY < newBitmap.Height)
        {
            Color myPoint  = myBitmap.GetPixel(xi  , yi);
            Color myPoint2 = myBitmap.GetPixel(newX, newY);
            newBitmap.SetPixel(newX, newY, myPoint);
            newBitmap.SetPixel(xi  , yi  , myPoint2);
            
        }
    }

    public static void FlipImage()
    {
        for (int x = 0; x < myBitmap.Width; x++) // Start from 0
        {
            for (int y = 0; y < myBitmap.Height / 2; y++) // Start from 0
            {
                FlipPoint(x, y); // Rotate by 45 degrees
            }
        }
    }

    public static void Main(string[] args)
    {
        myBitmap     = new Bitmap("./lady.jpg");
        newBitmap    = new Bitmap(myBitmap.Width, myBitmap.Height);
        FlipImage(); // Call the RotateImage method to process the image
        newBitmap.Save("./lady-flip.jpg"); // Save the new bitmap after processing
    }
}
