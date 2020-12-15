using System;
using System.Drawing;
using System.Timers;

public class GameContext
{
    public Size GameAreaSize = new(width: 320, height: 480);

    public Rectangle SnowFlakeRect = new(x: 0, y: 0, width: 48, height: 48);

    public Timer GameLoopTimer = new(interval: 30);

    private Random Random = new();

    public GameContext()
    {
        this.ResetSnowFlakePos();
        this.GameLoopTimer.Elapsed += GameLoopTimer_Elapsed;
        this.GameLoopTimer.Start();
    }

    private void GameLoopTimer_Elapsed(object sender, EventArgs e)
    {
        this.SnowFlakeRect.Y += 10;
        if (this.SnowFlakeRect.Y > this.GameAreaSize.Height) ResetSnowFlakePos();
    }

    private void ResetSnowFlakePos()
    {
        this.SnowFlakeRect.Y = -this.SnowFlakeRect.Height;
        this.SnowFlakeRect.X = Random.Next(minValue: 0, maxValue: this.GameAreaSize.Width - this.SnowFlakeRect.Width);
    }
}