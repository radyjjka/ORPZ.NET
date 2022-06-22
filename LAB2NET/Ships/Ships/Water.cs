namespace Ships;

public class Water
{
    public int Id { get; set; }
    public string Name { get; set; }
}

public class River : Water
{
    public double Length { get; set; }
    public double MaxWidth { get; set; }
    public int Inflows { get; set; }
}

public class Sea : Water
{
    public double Square { get; set; }
}