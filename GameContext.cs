using System;
using System.Drawing;
using System.Timers;

public class GameContext
{
    public Size GameAreaSize = new(width: 320, height: 480);

    public Rectangle SnowFlakeRect = new(x: 0, y: 0, width: 48, height: 48);

    public Rectangle SnowManRect = new(x: 0, y: 0, width: 64, height: 64);

    public Timer GameLoopTimer = new(interval: 30);

    public int Score;

    private Random Random = new();

    public GameContext()
    {
        this.ResetSnowFlakePos();
        this.ResetSnowManPos();

        this.GameLoopTimer.Elapsed += GameLoopTimer_Elapsed;
        this.GameLoopTimer.Start();
    }

    private void GameLoopTimer_Elapsed(object sender, EventArgs e)
    {
        this.SnowFlakeRect.Y += 10;
        if (this.SnowFlakeRect.Y > this.GameAreaSize.Height) ResetSnowFlakePos();

        var deltaH = this.SnowManRect.X - this.SnowFlakeRect.X;
        var deltaV = this.SnowManRect.Y - this.SnowFlakeRect.Y;
        var distance = Math.Sqrt(Math.Pow(deltaH, 2) + Math.Pow(deltaV, 2));

        if (distance < (this.SnowManRect.Height + this.SnowFlakeRect.Height) / 2 * 0.6)
        {
            ResetSnowFlakePos();
            this.Score++;
        }
    }

    private void ResetSnowFlakePos()
    {
        this.SnowFlakeRect.Y = -this.SnowFlakeRect.Height;
        this.SnowFlakeRect.X = Random.Next(minValue: 0, maxValue: this.GameAreaSize.Width - this.SnowFlakeRect.Width);
    }

    private void ResetSnowManPos()
    {
        this.SnowManRect.X = (this.GameAreaSize.Width - this.SnowManRect.Width) / 2;
        this.SnowManRect.Y = this.GameAreaSize.Height - this.SnowManRect.Height;
    }

    public void MoveSnowManToLeft()
    {
        this.SnowManRect.X = Math.Max(0, this.SnowManRect.X - 5);
    }

    public void MoveSnowManToRight()
    {
        var maxSnowManX = this.GameAreaSize.Width - this.SnowManRect.Width;
        this.SnowManRect.X = Math.Min(this.SnowManRect.X + 5, maxSnowManX);
    }
}