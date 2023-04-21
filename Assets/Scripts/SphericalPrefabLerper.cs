using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphericalPrefabLerper : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private int numPrefabs = 10;
    [SerializeField] private float radius = 5f;
    [SerializeField] private float duration = 1f;

    private List<GameObject> prefabs = new List<GameObject>();

    private void Start()
    {
        // Spawn the prefabs in a spherical distribution
        for (int i = 0; i < numPrefabs; i++)
        {
            float phi = Random.Range(0f, Mathf.PI);
            float theta = Random.Range(0f, 2f * Mathf.PI);

            Vector3 position = new Vector3(
                radius * Mathf.Sin(phi) * Mathf.Cos(theta),
                radius * Mathf.Sin(phi) * Mathf.Sin(theta),
                radius * Mathf.Cos(phi)
            );

            GameObject obj = Instantiate(prefab, position, Quaternion.identity);
            prefabs.Add(obj);
        }

        StartCoroutine(LerpTowardsCenter());
    }

    private IEnumerator LerpTowardsCenter()
    {
        Vector3 center = transform.position;

        while (true)
        {
            foreach (GameObject obj in prefabs)
            {
                float t = 0f;
                Vector3 start = obj.transform.position;
                Vector3 end = center;

                while (t < duration)
                {
                    obj.transform.position = Vector3.Lerp(start, end, t / duration);
                    t += Time.deltaTime;
                    yield return null;
                }
            }

            yield return StartCoroutine(LerpAwayFromCenter());
        }
    }

    private IEnumerator LerpAwayFromCenter()
    {
        Vector3 center = transform.position;

        while (true)
        {
            foreach (GameObject obj in prefabs)
            {
                float t = 0f;
                Vector3 start = obj.transform.position;
                Vector3 end = center + (obj.transform.position - center).normalized * radius;

                while (t < duration)
                {
                    obj.transform.position = Vector3.Lerp(start, end, t / duration);
                    t += Time.deltaTime;
                    yield return null;
                }
            }

            yield return StartCoroutine(LerpTowardsCenter());
        }
    }
}
