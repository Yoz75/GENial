using TMPro;
using UnityEngine;

namespace Genial
{
    public class ResultsDisplayer : MonoBehaviour
    {
        [SerializeField] private GradesBinding Grades;
        [SerializeField] private TotalResultsBinding TotalResults;

        public void Display()
        {
            var genials = ScoreManager.Instance.GetGradeCount(Grade.GENial);
            var greats = ScoreManager.Instance.GetGradeCount(Grade.Great);
            var goods = ScoreManager.Instance.GetGradeCount(Grade.Good);
            var mehs = ScoreManager.Instance.GetGradeCount(Grade.Meh);
            var misses = ScoreManager.Instance.GetGradeCount(Grade.Miss);

            Grades.MissSerializedCount = misses.ToString();
            Grades.MehSerializedCount = mehs.ToString();
            Grades.GoodSerializedCount = goods.ToString();
            Grades.GreatSerializedCount = greats.ToString();
            Grades.GenialSerializedCount = genials.ToString();

            TotalResults.TotalScore = Mathf.RoundToInt(ScoreManager.Instance.Score).ToString();
            TotalResults.MaxCombo = Combo.MaxCombo.ToString();

            TotalResults.Grade = Grades2TotalGradeConverter.Convert(genials, greats, goods, mehs, misses).ToString();
        }
    }
}