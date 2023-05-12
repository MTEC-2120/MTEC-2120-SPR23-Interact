using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using ON; 

public class GameManager : MonoBehaviour
{
    public int numAsteroids = 0;
    public int numCubes = 0; 

    private void Awake()
    {
        AstroidScript.OnAsteroidCollected += Collect;
        ON_Trigger_Destroy.OnTriggerDestroy += RegisterDestroy; 
    }


    public void RegisterDestroy(GameObject obj)
    {
        numCubes++;

        if (numCubes >= 5)
        {

            // Load next scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

    }


    public void Collect(GameObject obj)
    {
        numAsteroids++; 

        if(numAsteroids >=5)
        {

            // Load next scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

    }

}
