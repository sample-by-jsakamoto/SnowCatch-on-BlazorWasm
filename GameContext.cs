using System.Drawing;

public class GameContext
{
    public Size GameAreaSize = new(width: 320, height: 480);

    public Rectangle SnowFlakeRect = new(x: 0, y: 0, width: 48, height: 48);

    public GameContext()
    {
    }
}