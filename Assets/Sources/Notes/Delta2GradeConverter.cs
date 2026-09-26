
namespace Genial
{
    public static class Delta2GradeConverter
    {
        public const float GenialDelta = 0.075f;
        public const float GreatDelta = 0.1f;
        public const float GoodDelta = 0.2f;
        public const float MehDelta = 0.4f;

        public static Grade Convert(float positionDelta)
        {
            if(positionDelta < GenialDelta) return Grade.GENial;
            else if(positionDelta < GreatDelta) return Grade.Great;
            else if(positionDelta < GoodDelta) return Grade.Good;
            else if(positionDelta < MehDelta) return Grade.Meh;

            else return Grade.Miss;
        }
    }
}