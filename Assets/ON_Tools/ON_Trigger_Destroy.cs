using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ON
{
    public class ON_Trigger_Destroy : ON_TriggerEvents
    {
        public float timeToDestroy = 1f; // time to destroy in seconds


        public delegate void TriggerDestroy(GameObject obj);
        public static event TriggerDestroy OnTriggerDestroy;


        void Start()
        {

        }

        public override void Ping()
        {
            Debug.Log("Example Ping");
            base.Ping();
            StartCoroutine(HandlePing());
        }

        public override void Ping(float t)
        {
            Destroy(t);
        }

        public override void Reset()
        {
            base.Reset();

        }


        IEnumerator HandlePing()
        {
            Debug.Log("Destroy: " + timeToDestroy);

            Destroy(this.gameObject, timeToDestroy);
            OnTriggerDestroy?.Invoke(this.gameObject);
            Reset();
            yield return null;
        }

        void Destroy(float t)
        {
            Debug.Log("Destroy: " + t);
            Destroy(this.gameObject, timeToDestroy);


        }
    }
}
