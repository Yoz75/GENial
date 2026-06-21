
using UnityEngine;

namespace Genial
{
    // God-Manager class ahhhhh core 😭😭😭😭
    public class ScoreManager : MonoBehaviour
    {
        // It should be a dictionary but im too lazy to initialize each grade as 0
        private int[] GradesDistributions = new int[(int) Grade.Count];

        public int Score
        {
            get;
            private set;
        }

        public static ScoreManager Instance
        {
            get;
            private set;
        }

        private void Start()
        {
            Instance = this;
        }

        public int GetGradeCount(Grade grade) => GradesDistributions[(int)grade];

        public void UpdateScore(ConsumedNoteInfo info)
        {
            Grade grade;
            if(info.IsMiss) grade = Grade.Miss;
            else grade = Delta2GradeConverter.Convert(info.PositionDelta);

            GradesDistributions[(int)grade]++;
            Score += Grade2ScoreConverter.Convert(grade);
        }
    }
}