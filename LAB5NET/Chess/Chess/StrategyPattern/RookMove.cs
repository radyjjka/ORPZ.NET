namespace Chess;

class RookMove : IMove
{
    public string Move(string position, Figure figure)
    {
        if (position[0].Equals(figure.pos[0]) || (position[1].Equals(figure.pos[1])))
        {
            Console.WriteLine($"{figure.Name} was moved from {figure.pos} to {position}!");
            return position;
        }
        Console.WriteLine("Impossible move!");
        return figure.pos;
    }
}