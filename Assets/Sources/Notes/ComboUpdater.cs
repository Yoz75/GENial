using UnityEngine;

namespace Genial
{
    public class ComboUpdater : MonoBehaviour
    {
        public void UpdateCombo(ConsumedNoteInfo info)
        {
            var grade = Delta2GradeConverter.Convert(info.PositionDelta);

            if(info.IsMiss || grade == Grade.Miss)
            {
                Combo.ComboCount = 0;
            }
            else
            {
                Combo.ComboCount++;
            }
        }
    }
}