using System.Collections;
using UnityEngine;

public class SpinAndBob : MonoBehaviour
{
    public float bobSpeed = 1f; // Speed of the bobbing motion
    public float bobHeight = 0.5f; // Height of the bobbing motion
    public float rotateSpeed = 30f; // Rotation speed

    private Vector3 startPos;

    private void Start()
    {
        startPos = transform.position;
        StartCoroutine(SpinAndBobAnimation());
    }

    private IEnumerator SpinAndBobAnimation()
    {
        while (true)
        {
            // Bobbing motion
            float newY = startPos.y + Mathf.Sin(Time.time * bobSpeed) * bobHeight;
            transform.position = new Vector3(transform.position.x, newY, transform.position.z);

            // Rotation
            transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime);

            yield return null;
        }
    }
}
