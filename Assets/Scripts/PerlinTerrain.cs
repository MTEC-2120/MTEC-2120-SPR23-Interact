using UnityEngine;

public class PerlinTerrain : MonoBehaviour
{
    public int gridSize = 100;
    public GameObject prefab;
    public float noiseScale = 10.0f;
    public float heightScale = 10.0f;

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
        // Calculate the heights based on Perlin noise
        for (int x = 0; x < gridSize; x++)
        {
            for (int y = 0; y < gridSize; y++)
            {
                float noise = Mathf.PerlinNoise(x * noiseScale, y * noiseScale);
                float height = noise * heightScale;
                Vector3 position = cubes[x, y].transform.position;
                position.y = height;
                cubes[x, y].transform.position = position;
            }
        }
    }
}
