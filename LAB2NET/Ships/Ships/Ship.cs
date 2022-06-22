namespace Ships;

public class Ship
{
    public string Name { get; set; }
    public bool Type { get; set; } // True = Sea / False = River
    public int PortId { get; set; }
    public int Year { get; set; }
    public int PosPas { get; set; }
}