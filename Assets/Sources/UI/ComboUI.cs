using TMPro;
using UnityEngine;

namespace Genial
{
    public class ComboUI : MonoBehaviour
    {
        [SerializeField] private TMP_Text ComboText;

        public void UpdateComboText(ConsumedNoteInfo info)
        {
            ComboText.text = Combo.ComboCount.ToString("000");
        }
    }
}