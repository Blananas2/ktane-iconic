using System.Collections.Generic;

public class SpriteData
{
    public string _ = "This file contains the positions for each module on the generated sprite sheet. For use with the Iconic Interactive manual.";
    public Dictionary<string, SpriteInfo> sprites = new Dictionary<string, SpriteInfo>();
}

public class SpriteInfo
{
    public string name;
    public string sortkey;
    public int x;
    public int y;
    public int sheet;
}