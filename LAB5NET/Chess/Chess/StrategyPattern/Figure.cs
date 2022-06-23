namespace Chess;

public class Figure
{
    public string Name;
    public string pos;
    public Figure(string name, IMove mov, string position)
    {
        Name = name;
        Movable = mov;
        pos = position;
    }
    protected IMove Movable;
    public void MakeMove(string position)
    {
        pos = Movable.Move(position, this);
    }
}

