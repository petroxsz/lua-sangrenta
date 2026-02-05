using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public float smoothSpeed = 10f;

    [Header("Shake")]
    public float shakeStrength = 0.25f;
    public float shakeDuration = 0.15f;

    private float shakeTime;
    private Vector3 basePosition;

    void LateUpdate()
    {
        if (target == null) return;

        // posição base (seguir o player)
        Vector3 desiredPosition = target.position + offset;
        basePosition = Vector3.Lerp(
            transform.position,
            desiredPosition,
            smoothSpeed * Time.deltaTime
        );

        // aplica shake por cima
        if (shakeTime > 0)
        {
            Vector2 random = Random.insideUnitCircle * shakeStrength;
            transform.position = basePosition + new Vector3(random.x, random.y, 0);
            shakeTime -= Time.deltaTime;
        }
        else
        {
            transform.position = basePosition;
        }
    }

    public void Shake()
    {
        shakeTime = shakeDuration;
    }
}
