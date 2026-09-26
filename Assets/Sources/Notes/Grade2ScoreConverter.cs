
namespace Genial
{
    public static class Grade2ScoreConverter
    {
        public const float BaseScore = 100;

        public static float Convert(Grade grade)
        {
            switch(grade)
            {
                case Grade.Meh:
                    return BaseScore * Delta2GradeConverter.GenialDelta / Delta2GradeConverter.MehDelta;
                case Grade.Good:
                    return BaseScore * Delta2GradeConverter.GenialDelta / Delta2GradeConverter.GoodDelta;
                case Grade.Great:
                    return BaseScore * Delta2GradeConverter.GenialDelta / Delta2GradeConverter.GreatDelta;
                case Grade.GENial:
                    return BaseScore;
                default:
                    return 0;
            }
        }
    }
}