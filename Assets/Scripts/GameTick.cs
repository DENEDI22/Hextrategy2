using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    public class GameTick : MonoBehaviour
    {
        [SerializeField] private float tickTime;
        private bool runTicks = true;
        private List<Recourses> allRecourses = new List<Recourses>();
        
        private void Start()
        {
            allRecourses.AddRange(FindObjectsByType<Recourses>(FindObjectsSortMode.None));
            StartCoroutine(sendEveryTickCalls());
        }

        private IEnumerator sendEveryTickCalls()
        {
            while (runTicks)
            {
                foreach (Recourses recourses in allRecourses)
                {
                    recourses.HandleTick();
                }
                yield return new WaitForSeconds(tickTime);
            }
        }
    }
}