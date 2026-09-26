
namespace Genial
{
    public static class Combo
    {
        private static int ComboCountValue;

        public static int MaxCombo
        {
            get;
            private set;
        }

        public static int ComboCount
        {
            get => ComboCountValue;
            set
            {
                if(value > MaxCombo)
                {
                    MaxCombo = value;
                }

                ComboCountValue = value;
            }
        }
    }
}