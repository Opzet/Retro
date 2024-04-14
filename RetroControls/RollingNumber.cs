/// <summary>
/// Retro Barrel Fuel Pump 
/// Ability to set a new alphanumeric character for retro display to smoothly animate roll to
/// </summary>
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.ComponentModel;


public class RollingNumber : UserControl
{
    private Timer animationTimer;
    private int currentNumber = 0;
    private int targetNumber = 0;
    private float animationProgress = 0f; // 0 (start) to 1 (end)
    private Font retroFont;
    private Brush foreBrush;
    private readonly int numberHeight;

    public RollingNumber()
    {
        retroFont = new Font("Consolas", 48, FontStyle.Bold); // Adjust size/style as needed
        foreBrush = new SolidBrush(Color.FromArgb(255, 255, 108, 0)); // A bright orange as the foreground color
        BackColor = Color.Black; // Set the background color to black
        numberHeight = (int)CreateGraphics().MeasureString("0", retroFont).Height;

        if (!this.DesignMode)
        {
            animationTimer = new Timer
            {
                Interval = 50 // Adjust the speed of the animation here
            };
            animationTimer.Tick += (sender, e) => AnimateNumber();
        }
        DoubleBuffered = true;
    }

    public void SetNumber(int number)
    {
        targetNumber = number;
        animationProgress = 0f;

        if (!this.DesignMode && animationTimer != null)
        {
            animationTimer.Start();
        }
        else
        {
            currentNumber = targetNumber;
            Invalidate();
        }
    }

    private void AnimateNumber()
    {
        animationProgress += 0.05f; // Increment to control speed
        if (animationProgress >= 1f)
        {
            animationProgress = 0f;
            currentNumber = targetNumber;
            animationTimer?.Stop();
        }
        Invalidate();
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        Graphics g = e.Graphics;
        g.SmoothingMode = SmoothingMode.AntiAlias;
        g.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
        g.Clear(BackColor);

        // Draw the previous, current, and next numbers
        DrawNumber(g, GetPreviousNumber(currentNumber), -numberHeight + (numberHeight * animationProgress));
        DrawNumber(g, currentNumber, numberHeight * animationProgress);
        DrawNumber(g, GetNextNumber(currentNumber), numberHeight + (numberHeight * animationProgress));
    }

    private void DrawNumber(Graphics g, int number, float yOffset)
    {
        string numberText = number.ToString();
        SizeF size = g.MeasureString(numberText, retroFont);
        PointF location = new PointF((Width - size.Width) / 2, (Height - size.Height) / 2 + yOffset);
        g.DrawString(numberText, retroFont, foreBrush, location);
    }

    private int GetPreviousNumber(int number)
    {
        return number == 0 ? 9 : number - 1;
    }

    private int GetNextNumber(int number)
    {
        return number == 9 ? 0 : number + 1;
    }
}