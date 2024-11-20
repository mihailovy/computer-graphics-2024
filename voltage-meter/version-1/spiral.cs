using System;
using System.Drawing;
using System.Timers;
using System.IO.Ports;
using System.Threading;
using System.Management;
using System.Windows.Forms;
using System.Windows;
using System.Collections.Generic;


class Program
{
  public static Form        myWindow    = null;
  public static System.Timers.Timer aTimer;
  public static TextBox     tbMain      = null;
  public static TextBox     tbAvg       = null;
  public static Graphics    g           = null;
  public static PictureBox  pictureBox1 = new PictureBox();
  public static ComboBox    comboBox1   = new ComboBox(); 
  public static Queue<int>  yQueue      = new Queue<int>();
  public static bool Simulate           = true;
  
  public static int    x          = 0 ;
  public static int    y          = 0 ;
  public static string serialPort = "";
  public static bool   status     = false;
  public static float[] range;
  
  // Cache font instead of recreating font objects each time we paint.
  private static Font fnt = new Font("Arial",10);

  static SerialPort _serialPort;
  
  public static void Main()
  {
    
    // Init(); // Initialize Serial communication 
    GUI();
    //DrawLinePointF();
  }
  
  public static bool Init(int rate = 9600)
  {
    if (Simulate == true) {
      status = true;
      return true;
    }
    if (serialPort == "") {
      MessageBox.Show("Грешка: Моля, изберете комуникационен порт!");
      return false;
    } else {
      // Init serial communication
      try {         
        _serialPort = new SerialPort();
        _serialPort.PortName = serialPort;//Set your board COM
        _serialPort.BaudRate = rate;
        _serialPort.Open();
        status = true;
        return true;
      } catch(Exception e) {
        MessageBox.Show("Error: Could not initialize port  " + serialPort);
        return false;
      }
    }
  }
  
  public static void Send(string command)
  {
    if (command != "") 
    {
      char[] commandArray = command.ToCharArray();  
      if (Simulate == false) {
        _serialPort.Write(commandArray, 0, 1);
      }
      Thread.Sleep(200);
    }
  }

  public static string Receive()
  {
    string a;
    if (Simulate == false) {
      a = _serialPort.ReadExisting();
    } else {
      Random rnd = new Random();
      int aRnd = rnd.Next(0, 1024);  // creates a number between 1 and 12
 
      a = aRnd.ToString();
    }
    Thread.Sleep(200);
    return a;
  }
  
  public static string[] GetPorts()
  {
    int i = 0;
    string[] ports = SerialPort.GetPortNames();
    if (ports.Length > 0) {
      return ports;
    } else {
      ManagementObjectSearcher searcher = new ManagementObjectSearcher
         ("SELECT * FROM Win32_PnPEntity WHERE Caption like '%(COM%'");
      foreach (ManagementObject service in searcher.Get())
      {
          ports[i] = service.ToString();
          i++;
      }
      if (ports.Length > 0) {
        return ports;
      } else {
        string[] ports2 = {"COM1", "COM2", "COM3", "COM4", "COM5"};
        return ports2;
      }
    }
  }
  
  public static string[] GetPorts2()
  {
    string[] ports2 = {"COM1", "COM2", "COM3", "COM4", "COM5"};
    return ports2;
  }
  
  public static void GUI()
  {
    int btnWidth  = 40;
    int btnHeight = 40; 
    int btnOffset = 40;
    
    myWindow        = new Form();
    myWindow.Text   = "Цифров волтметър с Arduino";
    myWindow.Height = btnHeight*10;
    myWindow.Width  = btnWidth*10;
    
    tbMain          = new TextBox();
    tbMain.Height   = btnHeight;
    tbMain.Width    = btnWidth*3;
    myWindow.Controls.Add(tbMain);
    
    tbAvg          = new TextBox();
    tbAvg.Top      = 0;
    tbAvg.Left     = btnWidth*3;
    tbAvg.Height   = btnHeight;
    tbAvg.Width    = btnWidth*3;
    myWindow.Controls.Add(tbAvg);
    
    // Press 'On' button
    Button btn1    = new Button();
    btn1.Text      = " On ";
    btn1.Width     = btnWidth;
    btn1.Height    = btnHeight; 
    btn1.Left      = btnWidth*0;
    btn1.Top       = btnOffset + btnHeight*0;
    // Добавяне на обработчик на събитие
    btn1.Click    += delegate(object a, EventArgs b) {
       bool serialInit = Init();
       if (serialInit == true) {
         string command  = "1";
         Send(command);
         string feedback = Receive();
         tbMain.Text = feedback;
         timer();
       }
    };
    myWindow.Controls.Add(btn1); 
    
    // Press 'Off' button
    Button btn2    = new Button();
    btn2.Text      = " Off ";
    btn2.Width     = btnWidth;
    btn2.Height    = btnHeight; 
    btn2.Left      = btnWidth;
    btn2.Top       = btnOffset + btnHeight*0;
    btn2.Click    += delegate(object a, EventArgs b) {
       if (status == true) {
         string command = "2";
         Send(command);
         string feedback = Receive();
         tbMain.Text = feedback;
         yQueue.Clear();
         myWindow.Refresh();
         aTimer.Enabled = false;
         aTimer.Stop();
         aTimer.Dispose();
         tbMain.Text = "Off.";
       }
    };
    myWindow.Controls.Add(btn2); 
    
    Button btn3    = new Button();
    btn3.Text      = " 10V ";
    btn3.Width     = btnWidth*2;
    btn3.Height    = btnHeight; 
    btn3.Left      = btnWidth*2;
    btn3.Top       = btnOffset + btnHeight*0;
    btn3.Click    += delegate(object a, EventArgs b) {
       string command = "v";
       Send(command);
       string feedback = Receive();
       float voltage = 5*(float.Parse(feedback)/1024);
       feedback = voltage.ToString("0.00");
       tbMain.Text = "Voltage = " + feedback+ " V ";
    };
    myWindow.Controls.Add(btn3); 

    Button btn4    = new Button();
    btn4.Text      = " 25V ";
    btn4.Width     = btnWidth*2;
    btn4.Height    = btnHeight; 
    btn4.Left      = btnWidth*4;
    btn4.Top       = btnOffset + btnHeight*0;
    btn4.Click    += delegate(object a, EventArgs b) {
       string command = "v";
       Send(command);
       string feedback = Receive();
       float voltage = 5*(float.Parse(feedback)/1024);
       feedback = voltage.ToString("0.00");
       tbMain.Text = "Voltage = " + feedback+ " V ";
    };
    myWindow.Controls.Add(btn4); 
    
    Button btn5    = new Button();
    btn5.Text      = " 50V ";
    btn5.Width     = btnWidth*2;
    btn5.Height    = btnHeight; 
    btn5.Left      = btnWidth*6;
    btn5.Top       = btnOffset + btnHeight*0;
    btn5.Click    += delegate(object a, EventArgs b) {
       string command = "v";
       Send(command);
       string feedback = Receive();
       float voltage = 5*(float.Parse(feedback)/1024);
       feedback = voltage.ToString("0.00");
       tbMain.Text = "Voltage = " + feedback+ " V ";
    };
    myWindow.Controls.Add(btn5);
    
    //Избор на USB интерфейс
    comboBox1.Text      = " COM ";
    comboBox1.Width     = btnWidth*2;
    comboBox1.Height    = btnHeight; 
    comboBox1.Left      = btnWidth*6;
    comboBox1.Top       = btnHeight*0;
    string[] port = GetPorts();
    for (int i = 0; i < port.Length; i++) {
      Console.WriteLine(port[i]);
      comboBox1.Items.Add(port[i].ToString());
    }
    comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
    myWindow.Controls.Add(comboBox1);
     
    // Dock the PictureBox to the form and set its background to white.
    pictureBox1.Dock      = DockStyle.Fill;
    pictureBox1.BackColor = Color.White;
    pictureBox1.SizeMode  = PictureBoxSizeMode.CenterImage;
     
    // Connect the Paint event of the PictureBox to the event handler method.
    pictureBox1.Paint     += new System.Windows.Forms.PaintEventHandler(  pictureBox1_Paint);
   // pictureBox1.OnRepaint += new System.Windows.Forms.PaintEventHandler(  pictureBox1_Paint);

    // Add the PictureBox control to the Form.
    myWindow.Controls.Add(pictureBox1);
       
    Application.Run(myWindow);
  }
  
  private static void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
  {
    int selectedIndex   = comboBox1.SelectedIndex;
    Object selectedItem = comboBox1.SelectedItem;
    serialPort          = selectedItem.ToString();
    //MessageBox.Show("Selected Item Text: "+selectedItem.ToString()+"\n"+"Index: "+selectedIndex.ToString());
  }
  
  private static void pictureBox1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
  {
    int   last      = 0;
    float lineWidth = 8.0F;
    int   c1, c2    = 0;
    // Create a local version of the graphics object for the PictureBox.
    g = e.Graphics;
    x = 10;
    if (yQueue.Count + 1 > myWindow.Width / 10) {
      yQueue.Dequeue();
    }
    float avg = 0; 
    foreach( int y in yQueue )
    {
      c1 = 0 + 255 * y / Math.Abs(pictureBox1.Bottom - pictureBox1.Top);
      if (c1 > 255) {
        c1 = 255;
      }
      c2 = 255 - c1;
      myWindow.BackColor = Color.FromArgb(255, 255, c2);
      // Draw a string on the PictureBox.
      g.DrawLine(
         new Pen(Color.FromArgb(c1, 0, 0), lineWidth),
         pictureBox1.Left + x,
         pictureBox1.Bottom,
         pictureBox1.Left + x,
         pictureBox1.Bottom - y
      );
      x = x + 10;
      avg += y;
      last = y;
    }
    avg = avg / yQueue.Count;
    avg = 5*avg/1024;
    tbAvg.Text = "Ср. = " + avg + " V ";

    g.DrawLine(
       new Pen(Color.Green, lineWidth),
       pictureBox1.Left + x - 10,
       pictureBox1.Bottom,
       pictureBox1.Left + x - 10,
       pictureBox1.Bottom - last
    );
  }
  
  public static void MeasureVoltage(Object source, ElapsedEventArgs e)
  {
    string command = "v";
    Send(command);
    string feedback = Receive();
    float voltage = 5*(float.Parse(feedback)/1024);
    
    x = x + 10;
    y = (int) (Math.Abs( (float) pictureBox1.Bottom - (float) pictureBox1.Top) * (voltage/5) );
    yQueue.Enqueue(y);
    
    feedback = voltage.ToString("0.00");
    tbMain.Text = "Напрежение = " + feedback+ " V ";
    myWindow.Refresh(); // Redraw the form
    
    //pictureBox1.OnResize();
  }
  
  public static void timer()
  {
        // Create a timer with a two second interval.
        aTimer = new System.Timers.Timer(2000);
        // Hook up the Elapsed event for the timer. 
        aTimer.Elapsed += MeasureVoltage;
        aTimer.AutoReset = true;
        aTimer.Enabled = true;
  }
  
}
