using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstroidScript : MonoBehaviour
{

    public delegate void AsteroidCollected(GameObject obj);
    public static event AsteroidCollected OnAsteroidCollected; 



    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            if (OnAsteroidCollected != null)
            {
                OnAsteroidCollected.Invoke(this.gameObject);
                Destroy(this.gameObject); 
            }
        }



    }
}
