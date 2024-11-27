using System;
using System.Drawing;

class Program
{
    private static Bitmap myBitmap;
    private static Bitmap newBitmap;

    private static void RotatePoint(int xi, int yi, double beta)
    {
        double R, x1, y1;
        double alpha, alpha1;
        double x, y;

        x = (double)xi;
        y = (double)yi;

        // Calculate the radius vector of the point and angle
        R = Math.Sqrt(x * x + y * y);
        alpha = Math.Atan2(y, x); // Use Atan2 for correct angle calculation

        // The new angle is the old angle + beta
        alpha1 = alpha + beta;

        // Calculate the new coordinates of the point
        x1 = R * Math.Cos(alpha1);
        y1 = R * Math.Sin(alpha1);

        // Ensure new coordinates are within bounds
        int newX = (int)Math.Round(x1);
        int newY = (int)Math.Round(y1);

        if (newX >= 0 && newX < newBitmap.Width && newY >= 0 && newY < newBitmap.Height)
        {
            Color myPoint = myBitmap.GetPixel(xi, yi);
            newBitmap.SetPixel(newX, newY, myPoint);
        }
    }

    public static void RotateImage(double angle)
    {
        for (int x = 0; x < myBitmap.Width; x++) // Start from 0
        {
            for (int y = 0; y < myBitmap.Height; y++) // Start from 0
            {
                RotatePoint(x, y, angle); // Rotate by 45 degrees
            }
        }
    }

    public static void Main(string[] args)
    {
        double angle = Math.PI / 7;
        myBitmap     = new Bitmap("./lady.jpg");
        int newWidth     = (int)(myBitmap.Width  * (Math.Sin(angle) + Math.Cos(angle));
        int newHeight    = (int)(myBitmap.Height * (Math.Sin(angle) + Math.Cos(angle));
        newBitmap    = new Bitmap(newWidth, newHeight);
        RotateImage(angle); // Call the RotateImage method to process the image
        
        newBitmap.Save("./lady3.jpg"); // Save the new bitmap after processing
    }
}
