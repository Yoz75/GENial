
namespace Genial
{
    public static class Delta2GradeConverter
    {
        public static Grade Convert(float positionDelta)
        {
            const float genialTime = 0.05f;
            const float greatTime = 0.1f;
            const float goodTime = 0.2f;
            const float mehTime = 0.4f;

            if(positionDelta < genialTime) return Grade.GENial;
            else if(positionDelta < greatTime) return Grade.Great;
            else if(positionDelta < goodTime) return Grade.Good;
            else if(positionDelta < mehTime) return Grade.Meh;

            else return Grade.Miss;
        }
    }
}