using UnityEngine;

public class FlyingObjects : MonoBehaviour
{
    public GameObject objectPrefab;
    public float radius = 5f;
    public float speed = 2f;
    public int numberOfObjects = 20;

    private GameObject[] objects;
    private Vector3 center;

    void Start()
    {
        center = transform.position;
        objects = new GameObject[numberOfObjects];

        for (int i = 0; i < numberOfObjects; i++)
        {
            Vector3 pos = RandomCircle(center, radius);
            objects[i] = Instantiate(objectPrefab, pos, Quaternion.identity);
        }
    }

    void Update()
    {
        for (int i = 0; i < numberOfObjects; i++)
        {
            Vector3 pos = RandomCircle(center, radius);
            objects[i].transform.position = Vector3.MoveTowards(objects[i].transform.position, pos, speed * Time.deltaTime);
        }
    }

    Vector3 RandomCircle(Vector3 center, float radius)
    {
        float angle = Random.value * Mathf.PI * 2;
        float x = Mathf.Sin(angle) * radius;
        float z = Mathf.Cos(angle) * radius;
        return center + new Vector3(x, 0, z);
    }
}
