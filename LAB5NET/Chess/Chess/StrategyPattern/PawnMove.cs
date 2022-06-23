namespace Chess;

class PawnMove : IMove
{
    public string Move(string position, Figure figure)
    {
        if (position[0].Equals(figure.pos[0]) && (Convert.ToInt32(position[1]) - Convert.ToInt32(figure.pos[1]) <= 2))
        {
            Console.WriteLine($"{figure.Name} was moved from {figure.pos} to {position}!");
            return position;
        }
        Console.WriteLine("Impossible move!");
        return figure.pos;
    }
}