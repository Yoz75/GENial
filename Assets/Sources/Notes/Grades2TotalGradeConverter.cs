using Genial;

public static class Grades2TotalGradeConverter
{
    public static TotalGrade Convert(int genials, int greats, int goods, int mehs, int misses)
    {
        float genialScore = Grade2ScoreConverter.Convert(Grade.GENial);
        float greatScore = Grade2ScoreConverter.Convert(Grade.Great);
        float goodScore = Grade2ScoreConverter.Convert(Grade.Good);
        float mehScore = Grade2ScoreConverter.Convert(Grade.Meh);
        float missScore = Grade2ScoreConverter.Convert(Grade.Miss);

        float totalWeight = 0;

        totalWeight += genials * genialScore;
        totalWeight += greats * greatScore;
        totalWeight += goods * goodScore;
        totalWeight += mehs * mehScore;
        totalWeight += misses * missScore;

        float averageWeight = totalWeight / ((genials + greats + goods + mehs + misses) * genialScore);
        UnityEngine.Debug.Log($"total: {totalWeight}, sum: {(genials + greats + goods + mehs + misses) * genialScore}, average: {averageWeight}");

        return averageWeight switch
        {
            // Prevent floating-point arythmetics errors and shit like that
            > 0.995f => TotalGrade.SS,
            > 0.95f => TotalGrade.S,
            > 0.9f => TotalGrade.A,
            > 0.8f => TotalGrade.B,
            > 0.7f => TotalGrade.C,
            > 0.6f => TotalGrade.D,
            _ => TotalGrade.F
        };
    }
}