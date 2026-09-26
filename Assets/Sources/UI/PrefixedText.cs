using Unity.Properties;
using UnityEngine.UIElements;

namespace Genial
{
    [UxmlElement]
    public partial class PrefixedLabel : Label
    {
        private string PrefixValue = string.Empty;
        private string ContentTextValue = string.Empty;

        [UxmlAttribute]
        [CreateProperty]
        public string Prefix
        {
            get => PrefixValue;
            set
            {
                PrefixValue = value;
                UpdateText();
            }
        }

        [UxmlAttribute]
        [CreateProperty]
        public string ContentText
        {
            get => ContentTextValue;
            set
            {
                ContentTextValue = value;
                UpdateText();
            }
        }

        public PrefixedLabel()
        {
            UpdateText();
        }

        private void UpdateText()
        {
            text = $"{PrefixValue}: {ContentTextValue}";
        }
    }
}