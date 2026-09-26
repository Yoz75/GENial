using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

namespace Genial
{
    public class ButtonBinder : MonoBehaviour
    {
        [SerializeField] private PanelRenderer Panel;
        [SerializeField] private string ButtonName;
        [SerializeField] private UnityEvent OnClick;

        private Button Button;
        private int Version;

        private void OnEnable()
        {
            Panel.RegisterUIReloadCallback(OnUIReload);
        }

        private void OnDisable()
        {
            Panel.UnregisterUIReloadCallback(OnUIReload);
        }

        private void Invoke() => OnClick?.Invoke();

        public void Bind(UnityAction action)
        {
            OnClick.AddListener(action);
        }

        public void Unbind(UnityAction action)
        {
            OnClick.RemoveListener(action);
        }

        void OnUIReload(PanelRenderer panelRenderer, VisualElement rootElement, int version)
        {
            if(version == Version) return; 
            Version = version;

            var button = rootElement.Q<Button>(ButtonName);
            if(button is null)
            {
                Debug.LogError($"Button Binder {name} Could not find button named {ButtonName}.");
            }

            Button = button;
            Button.clicked += Invoke;
        }
    }
}