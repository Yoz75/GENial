
namespace Genial
{
    public static class Grade2ScoreConverter
    {
        public static int Convert(Grade grade)
        {
            switch(grade)
            {
                case Grade.Meh:
                    return 10;    
                case Grade.Good:
                    return 20;
                case Grade.Great:
                    return 40;
                case Grade.GENial:
                    return 80;
                default:
                    return 0;
            }
        }
    }
}