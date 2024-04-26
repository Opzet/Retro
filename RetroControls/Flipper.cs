using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

public partial class Flipper : UserControl
{
    private Bitmap[] upperImages = new Bitmap[60];
    private Bitmap[] lowerImages = new Bitmap[60];
    private Timer animationTimer = new Timer();
    private int animationStep = 0;
    private const int totalAnimationSteps = 10;

    private int animationStartTime;

    private PictureBox pbTop = new PictureBox();
    private PictureBox pbBott = new PictureBox();
    private PictureBox pbFill = new PictureBox();
    /*
    CSS
    border-radius: 8px;
    box-shadow: rgba(0,0,0,0.31) 5px 5px 10px 0px;
*/
    public enum Style
    {
        Hour,
        Minute,
        Second
    }

    private Style _flipperStyle = Style.Hour;
    public Style FlipperStyle
    {
        get { return _flipperStyle; }
        set
        {
            if (_flipperStyle != value)
            {
                _flipperStyle = value;
                UpdateTimerInterval();
                UpdateDisplay();
            }
        }
    }

    private void UpdateTimerInterval()
    {
        if (FlipperStyle == Style.Second)
            animationTimer.Interval = 1000; // 1 second for seconds
        else
            animationTimer.Interval = 50; // faster for smooth hour/minute animations
        if (!DesignMode)
        {
            animationStartTime = Environment.TickCount;
            animationTimer.Start();
        }
    }

    public Flipper()
    {
        //if (DesignMode)
        //    return;

        InitializeComponents();
        InitializeTimer();
        SizeFlaps();
        LoadImages();
        // Handling the control's appearance in design mode

        UpdateTimerInterval();
        UpdateDisplay(); // This ensures that the control is redrawn in the designer
    }

    private void InitializeComponents()
    {
        this.DoubleBuffered = true;

        pbTop.Dock = DockStyle.Top;
        pbBott.Dock = DockStyle.Bottom;
        pbFill.Dock = DockStyle.Fill;
        pbFill.Visible = false;

        this.Controls.Add(pbFill);
        this.Controls.Add(pbBott);
        this.Controls.Add(pbTop);

        this.Resize += Flipper_Resize;
        
        
    }

    private void InitializeTimer()
    {
        animationTimer.Interval = 50; // Fast enough for smooth animation
        animationTimer.Tick += (sender, e) => AnimationTimer_Tick();
    }

    private void Flipper_Resize(object sender, EventArgs e)
    {
        SizeFlaps();
        // Handling the control's appearance in design mode
        UpdateTimerInterval();
        UpdateDisplay(); // This ensures that the control is redrawn in the designer
    }

    private void LoadImages()
    {
        try
        {
            CreateImages();
        }
        catch (Exception ex)
        {
            // Handle exceptions related to image creation
            MessageBox.Show("Failed to create images: " + ex.Message);
        }
    }

    const int Gap = 2;

    void SizeFlaps()
    {
        pbFill.Width = pbTop.Width = pbBott.Width = this.Width;

        int combinedPictureBoxHeight = this.Height - Gap;
        
        pbTop.Height = combinedPictureBoxHeight / 2;
        
        pbBott.Height = combinedPictureBoxHeight / 2;
        pbBott.Top = pbTop.Bottom + 5;

        pbFill.Height = this.Height;
        pbFill.BringToFront();
        PerformAnimationStep(0);
    }

    private void CreateImages()
    {
        int width = this.Width;
        int height =  (this.Height - Gap) /2;

        for (int x = 0; x < 60; x++)
        {
            using (Bitmap img = new Bitmap(width, height * 2))
            using (Graphics gr = Graphics.FromImage(img))
            {
                gr.SmoothingMode = SmoothingMode.AntiAlias;
                gr.InterpolationMode = InterpolationMode.HighQualityBicubic;
                gr.CompositingQuality = CompositingQuality.HighQuality;
                gr.Clear(Color.Black);
                gr.DrawString(x.ToString("00"), new Font(this.Font.FontFamily, height * 0.9f, FontStyle.Regular, GraphicsUnit.Pixel), Brushes.White, new RectangleF(0, 0, width, height * 2), new StringFormat
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                });

                upperImages[x] = new Bitmap(width, height);
                lowerImages[x] = new Bitmap(width, height);
                using (Graphics grUpper = Graphics.FromImage(upperImages[x]))
                using (Graphics grLower = Graphics.FromImage(lowerImages[x]))
                {
                    grUpper.DrawImage(img, new Rectangle(0, 0, width, height), new Rectangle(0, 0, width, height), GraphicsUnit.Pixel);
                    grLower.DrawImage(img, new Rectangle(0, 0, width, height), new Rectangle(0, height, width, height), GraphicsUnit.Pixel);
                }
            }
        }
    }


    private void UpdateDisplay()
    {
        int index = GetCurrentIndex();

        if (index >= 0 && index < 60)
        {
            pbTop.Image = upperImages[index];
            pbTop.Tag = index;
            pbBott.Image = lowerImages[index];
        }
        else
        {
            MessageBox.Show("Index for images is out of expected range (0-59).");
        }
    }

    private int GetCurrentIndex()
    {
        switch (FlipperStyle)
        {
            case Style.Hour:
            return DateTime.Now.Hour % 24;
            case Style.Minute:
            return DateTime.Now.Minute;
            case Style.Second:
            return DateTime.Now.Second;
            default:
            throw new InvalidOperationException("Unsupported flipper style");
        }
    }

    private void AnimationTimer_Tick()
    {
        // Prevent the flip if the new value is the same as the current one.
        //    if (Convert.ToInt32(pictureBox1.Tag) == newValue) return;

        // Duration of the animation in milliseconds.
        const double animationDuration = 500;
        double timeFraction = (Environment.TickCount - animationStartTime) / animationDuration;

        if (timeFraction >= 1)
        {
            if (!DesignMode)
            {
                UpdateDisplay();
                animationStartTime = Environment.TickCount;
                animationTimer.Start();
                // animationTimer.Stop();
            }


            pbFill.Visible = false;
            return;
        }

        timeFraction = EaseInOutCubic(timeFraction);
        PerformAnimationStep(timeFraction);
    }

    private double EaseInOutCubic(double t)
    {
        return t < 0.5 ? 4 * t * t * t : 1 - Math.Pow(-2 * t + 2, 3) / 2;
    }

    private void PerformAnimationStep(double fraction)
    {
        int flipHeight = pbFill.Height;
        int newHeight = (int) (flipHeight * (1 - fraction));
        int newTop = flipHeight - newHeight;

        pbFill.Invalidate(new Rectangle(0, newTop, pbFill.Width, newHeight + 1));


        /*
        // Redraw only the changing part of the PictureBox for better performance.
        Rectangle invalidRect = new Rectangle(0, newTop, pictureBox3.Width, newHeight + 1);
        pictureBox3.Invalidate(invalidRect);

        pictureBox3.Update();

            //// Start the flipping animation to show a new value.
    //public void StartFlip(int newValue)
    //{
    //    // Prevent the flip if the new value is the same as the current one.
    //    if (Convert.ToInt32(pictureBox1.Tag) == newValue) return;

    //    // Set the image for the flip animation to the current visible image.
    //    pictureBox3.Image = pictureBox1.Image;
    //    // Ensure the height of the animating PictureBox matches the static PictureBoxes.
    //    pictureBox3.Height = pictureBox1.Height;
    //    // Make the animating PictureBox visible.
    //    pictureBox3.Visible = true;

    //    // Set the new value as the "back" image which will be revealed after the flip.
    //    pictureBox1.Image = upperImages[newValue];
    //    pictureBox1.Tag = newValue;

    //    // Start the animation by recording the start time and starting the timer.
    //    animationStartTime = Environment.TickCount;
    //    animationTimer.Start();
    //}

        */
    }
}
