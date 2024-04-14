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

    private PictureBox pictureBox1 = new PictureBox();
    private PictureBox pictureBox2 = new PictureBox();
    private PictureBox pictureBox3 = new PictureBox();


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
    }



    public Flipper()
    {
        this.DoubleBuffered = true;

        pictureBox1.Dock = DockStyle.Top;
        pictureBox2.Dock = DockStyle.Bottom;
        pictureBox3.Dock = DockStyle.Fill;
        pictureBox3.Visible = false;

        this.Controls.Add(pictureBox3);
        this.Controls.Add(pictureBox2);
        this.Controls.Add(pictureBox1);

        this.Resize += Flipper_Resize;

        SizeFlaps();

        animationTimer.Interval = 50; // Fast enough for smooth animation
        animationTimer.Tick += AnimationTimer_Tick;
    }

    private void Flipper_Resize(object sender, EventArgs e)
    {
        SizeFlaps();
    }

    void SizeFlaps()
    {
        // Calculate the height for each PictureBox, leaving space for a 5 pixel gap.
        int combinedPictureBoxHeight = this.Height - 5; // Subtract the gap from the total height
        pictureBox1.Height = combinedPictureBoxHeight / 2;
        pictureBox2.Height = combinedPictureBoxHeight / 2;

        // Adjust the location of pictureBox2 to create the gap between the two PictureBox controls.
        pictureBox2.Top = pictureBox1.Bottom + 5;

        pictureBox3.Height = this.Height;
        pictureBox3.BringToFront(); // Ensure the animating PictureBox is on top

        SizeFlaps();
        CreateImages();
        UpdateDisplay();
    }

    private void CreateImages()
    {
        int width = this.Width;
        int height = this.Height / 3;

        for (int x = 0; x < 60; x++)
        {
            Bitmap img = new Bitmap(width, height * 2);
            using (Graphics gr = Graphics.FromImage(img))
            {
                gr.SmoothingMode = SmoothingMode.AntiAlias;
                gr.InterpolationMode = InterpolationMode.HighQualityBicubic;
                gr.CompositingQuality = CompositingQuality.HighQuality;

                gr.Clear(Color.Black);
                StringFormat sf = new StringFormat
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                };
                gr.DrawString(x.ToString("00"), new Font(this.Font.FontFamily, height * 0.9f, FontStyle.Regular, GraphicsUnit.Pixel), Brushes.White, new RectangleF(0, 0, width, height * 2), sf);
            }

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

    private void UpdateDisplay()
    {
        int index;

        if (FlipperStyle == Style.Hour)
        {
            index = DateTime.Now.Hour % 24;  // Hours are usually represented in a 24-hour format.
        }
        else if (FlipperStyle == Style.Minute)
        {
            index = DateTime.Now.Minute;  // Minutes and seconds from 0 to 59.
        }
        else if (FlipperStyle == Style.Second)
        {
            index = DateTime.Now.Second;  // Include support for seconds.
        }
        else
        {
            throw new InvalidOperationException("Unsupported flipper style");
        }

        // Ensure the selected index is within bounds of the image arrays
        if (index >= 0 && index < 60)
        {
            pictureBox1.Image = upperImages[index];  // Update the upper part image.
            pictureBox1.Tag = index;                 // Store the current index as Tag for reference.
            pictureBox2.Image = lowerImages[index];  // Update the lower part image.
        }
        else
        {
            // Handle the case where the index is out of bounds, though this should not occur.
            throw new IndexOutOfRangeException("Index for images is out of expected range (0-59).");
        }
    }


    //private void PerformAnimationStep()
    //{
    //    int flipHeight = pictureBox3.Height;
    //    int stepHeight = flipHeight / totalAnimationSteps;
    //    int currentTop = stepHeight * animationStep;

    //    pictureBox3.Height = flipHeight - currentTop;
    //    pictureBox3.Top = currentTop;
    //    pictureBox3.Refresh();
    //}

    // ... (Other parts of the Flipper class remain unchanged) ...

    // This method will be called every time the timer ticks.
    private void AnimationTimer_Tick(object sender, EventArgs e)
    {
        // Duration of the animation in milliseconds.
        const double animationDuration = 500;
        // Calculate the fraction of the elapsed time relative to the total animation duration.
        double timeFraction = (Environment.TickCount - animationStartTime) / animationDuration;

        if (timeFraction >= 1)
        {
            // Stop the timer if the animation has completed.
            animationTimer.Stop();
            // Hide the animating PictureBox.
            pictureBox3.Visible = false;
            // Reset the animation step counter.
            animationStep = 0;
            return;
        }

        // Apply ease-in-out interpolation for a smoother animation.
        timeFraction = EaseInOutCubic(timeFraction);
        // Update the animation based on the interpolated time fraction.
        PerformAnimationStep(timeFraction);
    }


    // Interpolation function for the animation easing (ease-in-out cubic).
    private double EaseInOutCubic(double t)
    {
        return t < 0.5 ? 4 * t * t * t : 1 - Math.Pow(-2 * t + 2, 3) / 2;
    }

    // Update the animation for the current time fraction.
    private void PerformAnimationStep(double fraction)
    {
        // Calculate the height for the current step of the animation.
        int flipHeight = pictureBox3.Height;
        int newHeight = (int)(flipHeight * (1 - fraction));
        int newTop = flipHeight - newHeight;

        // Redraw only the changing part of the PictureBox for better performance.
        Rectangle invalidRect = new Rectangle(0, newTop, pictureBox3.Width, newHeight + 1);
        pictureBox3.Invalidate(invalidRect);
        pictureBox3.Update();
    }

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

    public void StartFlip()
    {
        int currentValue = Convert.ToInt32(pictureBox1.Tag);
        int newValue;

        switch (FlipperStyle)
        {
            case Style.Hour:
                newValue = DateTime.Now.Hour % 24;
                break;
            case Style.Minute:
                newValue = DateTime.Now.Minute;
                break;
            case Style.Second:
                newValue = DateTime.Now.Second;
                break;
            default:
                newValue = 0;
                break;
        }

        if (currentValue == newValue) return;

        pictureBox3.Top = 0;
        pictureBox3.Image = pictureBox1.Image;
        pictureBox3.Visible = true;

        pictureBox1.Image = upperImages[newValue];
        pictureBox1.Tag = newValue;

        animationStartTime = Environment.TickCount;
        animationTimer.Start();
    }

}