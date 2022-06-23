using System;

// Реалізувати хід шахової фігури.
// Обрано паттерн Стратегія.
// Реалізовано три фігури: Пішка, Тура, Король.

namespace Chess
{
    class Program
    {
        static void Main(string[] args)
        {
            Figure figure1 = new Figure("Pawn", new PawnMove(), "A1");
            figure1.MakeMove("A1");
            figure1.MakeMove("A3");
            Figure figure2 = new Figure("Rook", new RookMove(), "A1");
            figure2.MakeMove("A8");
            figure2.MakeMove("D8");
            figure2.MakeMove("C3"); // Impossible move
            Figure figure3 = new Figure("King", new KingMove(), "G4");
            figure3.MakeMove("G5");
            figure3.MakeMove("F4");
            figure3.MakeMove("F2"); // Impossible move
        }
    }
}
