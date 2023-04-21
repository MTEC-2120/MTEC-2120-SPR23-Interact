using System.Collections.Generic;
using UnityEngine;

public class GameObjectLerper : MonoBehaviour
{
    [SerializeField] private List<GameObject> gameObjects;
    [SerializeField] private List<Transform> startTransforms;
    [SerializeField] private List<Transform> endTransforms;
    [SerializeField] private float maxDistance = 10f;

    private void Update()
    {
        Vector3 playerPosition = transform.position;

        for (int i = 0; i < gameObjects.Count; i++)
        {
            GameObject obj = gameObjects[i];
            Transform startTransform = startTransforms[i];
            Transform endTransform = endTransforms[i];

            float distanceToPlayer = Vector3.Distance(playerPosition, obj.transform.position);

            if (distanceToPlayer < maxDistance)
            {
                float lerpFactor = distanceToPlayer / maxDistance;
                obj.transform.position = Vector3.Lerp(startTransform.position, endTransform.position, lerpFactor);
                obj.transform.rotation = Quaternion.Lerp(startTransform.rotation, endTransform.rotation, lerpFactor);
                obj.transform.localScale = Vector3.Lerp(startTransform.localScale, endTransform.localScale, lerpFactor);
            }
        }
    }
}
