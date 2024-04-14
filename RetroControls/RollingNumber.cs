using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing.Text;

public class RollingNumber : UserControl
{
    private Timer animationTimer;
    private int currentNumber = 0;
    private int targetNumber = 0;
    private float animationProgress = 0f; // Animation progress from 0 (start) to 1 (end)
    private Font retroFont;
    private Brush foreBrush;
    private readonly int numberHeight;
    private bool incrementing;

    public RollingNumber()
    {
        retroFont = new Font("Consolas", 48, FontStyle.Bold);
        foreBrush = new SolidBrush(Color.FromArgb(225, 212, 212, 212)); // Bright orange
        BackColor = Color.Black;
        numberHeight = (int)CreateGraphics().MeasureString("0", retroFont).Height;

        animationTimer = new Timer
        {
            Interval = 50 // Animation speed
        };
        animationTimer.Tick += (sender, e) => AnimateNumber();
        DoubleBuffered = true;

        // Handling the control's appearance in design mode
        if (this.DesignMode)
        {
            Invalidate(); // This ensures that the control is redrawn in the designer
        }
    }

    public void SetNumber(int number)
    {
        if (number != targetNumber)
        {
            targetNumber = number;
            incrementing = targetNumber > currentNumber || (currentNumber == 9 && targetNumber == 0);
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
    }

    private void AnimateNumber()
    {
        animationProgress += 0.05f;
        if (animationProgress >= 1f)
        {
            animationProgress = 0f;
            currentNumber = targetNumber;
            animationTimer.Stop();
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

        // Check if incrementing or decrementing and adjust the drawing logic accordingly
        if (incrementing)
        {
            // When incrementing, make the current number move upwards
            DrawNumber(g, currentNumber, numberHeight * animationProgress);
            DrawNumber(g, GetNextNumber(currentNumber), -numberHeight + numberHeight * animationProgress);
        }
        else
        {
            // When decrementing, make the current number move downwards
            DrawNumber(g, currentNumber, -numberHeight * animationProgress);
            DrawNumber(g, GetPreviousNumber(currentNumber), numberHeight - numberHeight * animationProgress);
        }

        // Always draw the current number statically if not animating or in design mode
        if (animationProgress == 0f || this.DesignMode)
        {
            DrawNumber(g, currentNumber, 0);
        }
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
