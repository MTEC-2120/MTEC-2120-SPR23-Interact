using UnityEngine;

public class ClickToRepel : MonoBehaviour
{
    public int gridSize = 10;
    public GameObject prefab;
    public float repelForce = 100.0f;

    private GameObject[,] cubes;

    private void Start()
    {
        // Initialize the cubes array
        cubes = new GameObject[gridSize, gridSize];

        // Instantiate the cubes and position them in a grid
        for (int x = 0; x < gridSize; x++)
        {
            for (int y = 0; y < gridSize; y++)
            {
                GameObject cube = Instantiate(prefab, transform);
                cube.transform.position = new Vector3(x, 0.0f, y);
                cubes[x, y] = cube;
            }
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                // Calculate the repulsive force from the clicked object
                Vector3 hitPosition = hit.point;
                for (int x = 0; x < gridSize; x++)
                {
                    for (int y = 0; y < gridSize; y++)
                    {
                        GameObject cube = cubes[x, y];
                        Vector3 direction = cube.transform.position - hitPosition;
                        float distance = direction.magnitude;
                        if (distance < 1.0f)
                        {
                            distance = 1.0f;
                        }
                        float force = repelForce / (distance * distance);
                        cube.GetComponent<Rigidbody>().AddForce(direction.normalized * force);
                    }
                }
            }
        }
    }
}
