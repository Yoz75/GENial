using UnityEngine;

namespace Genial
{
    public class GradeMarkSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject GradeMarkPrefab;
        [SerializeField] private Sprite MissSprite, MehSprite, GoodSprite, GreatSprite, GenialSprite;

        public void Spawn(ConsumedNoteInfo info)
        {
            Grade grade;
            if(info.IsTypeMismatch) grade = Grade.Miss;
            else grade = Delta2GradeConverter.Convert(info.PositionDelta);

            Sprite sprite;
            switch(grade)
            {
                case Grade.Meh:
                    sprite = MehSprite;
                    break;
                case Grade.Good:
                    sprite = GoodSprite;
                    break;
                case Grade.Great:
                    sprite = GreatSprite;
                    break;
                case Grade.GENial:
                    sprite = GenialSprite;
                    break;
                default:
                    sprite = MissSprite;
                    break;
            }

            var gradeMark = Instantiate(GradeMarkPrefab, transform);
            gradeMark.transform.localPosition = Vector3.zero;
            gradeMark.GetComponent<SpriteRenderer>().sprite = sprite;
        }
    }
}