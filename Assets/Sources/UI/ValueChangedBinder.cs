using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

namespace Genial
{
    public class ValueChangedBinder<T, U> : MonoBehaviour where T : VisualElement
    {
        [SerializeField] private PanelRenderer Panel;
        [SerializeField] private string FieldName;
        [SerializeField] private UnityEvent<U> ValueChanged;

        private T Element;
        private int Version;

        private void OnEnable()
        {
            Panel.RegisterUIReloadCallback(OnUIReload);
        }

        private void OnDisable()
        {
            Panel.UnregisterUIReloadCallback(OnUIReload);
        }

        private void Invoke(U value) => ValueChanged?.Invoke(value);

        public void Bind(UnityAction<U> action)
        {
            ValueChanged.AddListener(action);
        }

        public void Unbind(UnityAction<U> action)
        {
            ValueChanged.RemoveListener(action);
        }

        void OnUIReload(PanelRenderer panelRenderer, VisualElement rootElement, int version)
        {
            if(version == Version) return;
            Version = version;

            var element = rootElement.Q<T>(FieldName);
            if(element is null)
            {
                Debug.LogError($"Value Changed Binder {name} Could not find element named {FieldName}.");
            }

            Element = element;
            Element.RegisterCallback<ChangeEvent<U>>((@event) =>
            {
                Invoke(@event.newValue);
            });
        }
    }
}