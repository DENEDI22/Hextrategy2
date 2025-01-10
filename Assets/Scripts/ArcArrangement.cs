using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class ArcArrangement : MonoBehaviour
    {
        [SerializeField] private GameObject buttonPrefab;
        [SerializeField] private Canvas canvas;
        [SerializeField] private float radius;
        [SerializeField] private Vector3 offset;

        private void ArrangeButtons()
        {
            Button[] allButtons = GetComponentsInChildren<Button>();
            float angleStep = 180 / (allButtons.Length - 1);
            Vector3 centerPosition = transform.position + offset;
            for (int i = 0; i < allButtons.Length; i++)
            {
                float angle = angleStep * i;
                float angleInRadians = angle * Mathf.Deg2Rad;
                Vector3 buttonPosition = new Vector3(centerPosition.x + radius * Mathf.Cos(angleInRadians),
                    centerPosition.y + radius * Mathf.Sin(angleInRadians), centerPosition.z);
                allButtons[i].transform.localPosition = buttonPosition;
            }
        }

        public void AddButton()
        {
            GameObject button = Instantiate(buttonPrefab, transform);
            button.GetComponentInChildren<TextMeshProUGUI>().text = "Generated";
            ArrangeButtons();
        }

        public void ClearButtons()
        {
            Button[] allButtons = GetComponentsInChildren<Button>();
            for (int i = 0; i < allButtons.Length; i++)
            {
                Destroy(allButtons[i].gameObject);
            }
        }
    }
}