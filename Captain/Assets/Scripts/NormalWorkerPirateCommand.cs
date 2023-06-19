using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Captain.Command;

namespace Captain.Command
{
    public class NormalWorkerPirateCommand : ScriptableObject, IPirateCommand
    {
        private float totalWorkDuration;
        private float totalWorkDone;
        private float currentWork;
        private const float PRODUCTION_TIME = 4.0f;
        private bool exhausted = false;
        
        private NormalWorkerPirateCommand()
        {
            totalWorkDone=0.0f;
            currentWork=0.0f;
        }

        private void OnEnable()
        {
            totalWorkDuration=Random.Range(10, 21);
        }

        public bool Execute(GameObject pirate, Object productPrefab)
        {
            //Debug.Log(totalWorkDuration);
            if (!exhausted)
            {
                if (currentWork < PRODUCTION_TIME)
                {
                    currentWork += Time.deltaTime;
                }
                else
                {
                    currentWork = 0.0f;
                    totalWorkDone += PRODUCTION_TIME;
                    Vector2 dropPosition = (Vector2)pirate.transform.position + new Vector2(Random.Range(-2.0f, 2.1f), 1.0f);
                    Instantiate(productPrefab, dropPosition, Quaternion.identity);
                }
                if (totalWorkDone < totalWorkDuration)
                {
                    return true;
                }
                else
                {
                    exhausted = true;
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}