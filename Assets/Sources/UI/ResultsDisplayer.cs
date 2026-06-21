using TMPro;
using UnityEngine;

namespace Genial
{
    public class ResultsDisplayer : MonoBehaviour
    {
        [SerializeField] private TMP_Text MissCount, MehCount, GoodCount, GreatCount, GenialCount;
        [SerializeField] private TMP_Text ScoreCount;

        public void Display()
        {
            MissCount.text = ScoreManager.Instance.GetGradeCount(Grade.Miss).ToString();
            MehCount.text = ScoreManager.Instance.GetGradeCount(Grade.Meh).ToString();
            GoodCount.text = ScoreManager.Instance.GetGradeCount(Grade.Good).ToString();
            GreatCount.text = ScoreManager.Instance.GetGradeCount(Grade.Great).ToString();
            GenialCount.text = ScoreManager.Instance.GetGradeCount(Grade.GENial).ToString();

            ScoreCount.text = Mathf.RoundToInt(ScoreManager.Instance.Score).ToString();
        }
    }
}