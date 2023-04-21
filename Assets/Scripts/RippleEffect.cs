using UnityEngine;

public class RippleEffect : MonoBehaviour
{
    public int gridSize = 100;
    public GameObject prefab;
    public float rippleSpeed = 10.0f;
    public float rippleScale = 10.0f;

    private float[,] heights;
    private GameObject[,] cubes;

    private void Start()
    {
        // Initialize the heights and cubes arrays
        heights = new float[gridSize, gridSize];
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
        // Calculate the new heights based on a ripple effect
        float time = Time.time * rippleSpeed;
        for (int x = 0; x < gridSize; x++)
        {
            for (int y = 0; y < gridSize; y++)
            {
                float distance = Vector2.Distance(new Vector2(x, y), new Vector2(gridSize / 2, gridSize / 2));
                float wave = rippleScale * Mathf.Sin(distance * 0.1f - time);
                heights[x, y] = wave;
            }
        }

        // Update the cube positions based on the new heights
        for (int x = 0; x < gridSize; x++)
        {
            for (int y = 0; y < gridSize; y++)
            {
                Vector3 position = cubes[x, y].transform.position;
                position.y = heights[x, y];
                cubes[x, y].transform.position = position;
            }
        }
    }
}
