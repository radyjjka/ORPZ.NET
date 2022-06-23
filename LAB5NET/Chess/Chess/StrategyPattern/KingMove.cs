namespace Chess;

class KingMove : IMove
{
    private List<char> Letters = new List<char>(){ 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H' };
    public string Move(string position, Figure figure)
    {
        int index = 0;
        for (int i = 0; i < Letters.Count; i++)
        {
            if (Letters[i] == figure.pos[0])
            {
                index = i;
            }
        }

        if (index == 0)
        {
            Console.WriteLine("Something went wrong");
            return figure.pos;
        }

        if ((position[0] == Letters[index]) && (Convert.ToInt32(position[1]) - Convert.ToInt32(figure.pos[1]) == -1))
        {
            Console.WriteLine($"{figure.Name} was moved from {figure.pos} to {position}!");
            return position;
        }
        if ((position[0] == Letters[index]) && (Convert.ToInt32(position[1]) - Convert.ToInt32(figure.pos[1]) == 1))
        {
            Console.WriteLine($"{figure.Name} was moved from {figure.pos} to {position}!");
            return position;
        }
        if ((position[0] == Letters[index+1]) && (position[1] == figure.pos[1]))
        {
            Console.WriteLine($"{figure.Name} was moved from {figure.pos} to {position}!");
            return position;
        }
        if ((position[0] == Letters[index-1]) && (position[1] == figure.pos[1]))
        {
            Console.WriteLine($"{figure.Name} was moved from {figure.pos} to {position}!");
            return position;
        }
        
        if ((position[0] == Letters[index+1]) && (Convert.ToInt32(position[1]) - Convert.ToInt32(figure.pos[1]) == -1))
        {
            Console.WriteLine($"{figure.Name} was moved from {figure.pos} to {position}!");
            return position;
        }
        if ((position[0] == Letters[index+1]) && (Convert.ToInt32(position[1]) - Convert.ToInt32(figure.pos[1]) == 1))
        {
            Console.WriteLine($"{figure.Name} was moved from {figure.pos} to {position}!");
            return position;
        }
        
        if ((position[0] == Letters[index-1]) && (Convert.ToInt32(position[1]) - Convert.ToInt32(figure.pos[1]) == -1))
        {
            Console.WriteLine($"{figure.Name} was moved from {figure.pos} to {position}!");
            return position;
        }
        if ((position[0] == Letters[index-1]) && (Convert.ToInt32(position[1]) - Convert.ToInt32(figure.pos[1]) == 1))
        {
            Console.WriteLine($"{figure.Name} was moved from {figure.pos} to {position}!");
            return position;
        }
        Console.WriteLine("Impossible move!");
        return figure.pos;
    }
}