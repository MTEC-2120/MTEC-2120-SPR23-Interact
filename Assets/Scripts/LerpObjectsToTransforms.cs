using UnityEngine;
using System.Collections.Generic;

public class LerpObjectsToTransforms : MonoBehaviour
{
    public List<Transform> targetTransforms;
    public List<GameObject> objectsToMove;
    public float speed = 2f;

    private int currentTargetIndex = 0;

    void Update()
    {
        // Check if we have reached the current target transform
        if (Vector3.Distance(objectsToMove[currentTargetIndex].transform.position, targetTransforms[currentTargetIndex].position) < 0.1f)
        {
            // If we have, move to the next target
            currentTargetIndex++;
            if (currentTargetIndex >= targetTransforms.Count)
            {
                currentTargetIndex = 0;
            }
        }

        // Lerp towards the current target transform
        objectsToMove[currentTargetIndex].transform.position = Vector3.Lerp(objectsToMove[currentTargetIndex].transform.position, targetTransforms[currentTargetIndex].position, speed * Time.deltaTime);
    }
}

