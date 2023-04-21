using UnityEngine;

public class LocalXRotation : MonoBehaviour
{
    public float rotationSpeed;

    void Start()
    {
        rotationSpeed = Random.Range(-10f, 10f);
    }

    void Update()
    {
        transform.eulerAngles = new Vector3(transform.eulerAngles.x + rotationSpeed * Time.deltaTime, transform.eulerAngles.y, transform.eulerAngles.z) ;
    }
}
