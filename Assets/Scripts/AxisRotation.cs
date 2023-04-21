using UnityEngine;

public class AxisRotation : MonoBehaviour
{
    public bool rotateX = false;
    public bool rotateY = true;
    public bool rotateZ = false;
    public float speed = 10f;

    void Update()
    {
        Vector3 axis = new Vector3(
            rotateX ? 1f : 0f,
            rotateY ? 1f : 0f,
            rotateZ ? 1f : 0f
        );

        //transform.Rotate(axis, speed * Time.deltaTime);
        transform.Rotate(axis, speed * Time.deltaTime, Space.World);
    }
}
