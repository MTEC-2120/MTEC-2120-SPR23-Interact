using UnityEngine;

public class TransformLerp : MonoBehaviour
{
    public Transform[] startTransforms;
    public Transform[] endTransforms;
    public float duration = 1.0f;

    private float t = 0.0f;

    private void Update()
    {
        // Calculate the interpolation factor
        t += Time.deltaTime / duration;
        t = Mathf.Clamp01(t);

        // Lerp the transforms
        for (int i = 0; i < startTransforms.Length; i++)
        {
            startTransforms[i].position = Vector3.Lerp(startTransforms[i].position, endTransforms[i].position, t);
            startTransforms[i].rotation = Quaternion.Slerp(startTransforms[i].rotation, endTransforms[i].rotation, t);
            startTransforms[i].localScale = Vector3.Lerp(startTransforms[i].localScale, endTransforms[i].localScale, t);
        }

        // Reset the interpolation factor if necessary
        if (t >= 1.0f)
        {
            t = 0.0f;
        }
    }
}
