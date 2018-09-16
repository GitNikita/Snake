namespace Snake
{
    class HorizontalLine : FigureLine
    {
        public HorizontalLine(int x, int y, char symbol, int lenght) : base(x, y, symbol, lenght)
        {
            for (int i = 0; i <= lenght; i++)
            {
                Plist.Add(new Point(x++, y, symbol));
            }
        }
    }
}
