using System;
using System.Drawing;
using System.Timers;

public class GameContext
{
    public Size GameAreaSize = new(width: 320, height: 480);

    public Rectangle SnowFlakeRect = new(x: 0, y: 0, width: 48, height: 48);

    public Timer GameLoopTimer = new(interval: 30);

    public GameContext()
    {
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
    }
}