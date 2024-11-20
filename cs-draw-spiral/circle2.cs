using System;
using System.Drawing;
using System.Windows.Forms;

class SpiralForm : Form
{
    private const int NumPoints = 100000;
    private const double Increment = 0.01;
    private const double A = 0.1;
    private const double B = 0.01;

    public SpiralForm()
    {
        Text = "Spiral";
        Size = new Size(800, 800);
        CenterToScreen();
        Paint += OnPaint;
    }

    private void OnPaint(object sender, PaintEventArgs e)
    {
        Graphics g = e.Graphics;
        Pen pen = new Pen(Color.Black);

        double theta = 0;
        double x, y;

        for (int i = 0; i < NumPoints; i++)
        {
            x = A * theta * Math.Cos(theta * 5);
            y = B * theta * Math.Sin(theta * 7);

            int screenX = (int)(x * 10) + Width / 2;
            int screenY = (int)(y * 10) + Height / 2;

            g.DrawRectangle(pen, screenX, screenY, 1, 1);

            theta += Increment;
        }
    }

    [STAThread]
    static void Main()
    {
        Application.Run(new SpiralForm());
    }
}
