using Kvant;
using UnityEngine;

public class WarpSpeedDetector : MonoBehaviour
{

    public Warp warp; // Reference to the Warp component
    public float velocityThreshold = 10f; // The minimum velocity required to trigger warp speed
    [SerializeField] float velocityMagnitude = 0f;

    private Rigidbody rb; 


    private Vector3 previousPosition;


    private void Start()
    {
        previousPosition = transform.position;
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // Compute velocity as change in position per second
        //Vector3 velocity = (transform.position - previousPosition) / Time.deltaTime;
        //velocityMagnitude = velocity.magnitude; 

        velocityMagnitude = rb.velocity.magnitude;

        // Check if velocity is greater than threshold
        if (velocityMagnitude > velocityThreshold)
        {
            // Call WarpSpeed function
            WarpSpeed();
        }
        else
        {
            warp.throttle = 0f; 

        }

        // Store current position as previous position for next frame
        previousPosition = transform.position;
    }

    private void WarpSpeed()
    {
        // TODO: Implement WarpSpeed function
        Debug.Log("Warp speed engaged!");
        warp.throttle = velocityMagnitude;
        warp.UpdateMeshRenderer();
        warp.UpdateMeshFilter(); 
    }
}
