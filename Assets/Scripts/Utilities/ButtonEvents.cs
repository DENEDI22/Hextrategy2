using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace DefaultNamespace.Utilities
{
    public class ButtonEvents : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        public UnityEvent OnPointerEnterEvent;
        public UnityEvent OnPointerExitEvent;

        public void OnPointerEnter(PointerEventData pointerEventData)
        {
            OnPointerEnterEvent?.Invoke();
            Debug.Log("OnPointerEnter");
        }

        public void OnPointerExit(PointerEventData pointerEventData)
        {
            OnPointerExitEvent?.Invoke();
            Debug.Log("OnPointerExit");
        }
    }
}