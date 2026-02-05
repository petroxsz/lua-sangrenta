using UnityEngine;

public class BossFinal : MonoBehaviour
{
    public Transform patrolPath;
    public float speed = 2f;

    private int currentPointIndex = 0;
    private bool goingForward = true;

    void Update()
    {
        if (patrolPath == null || patrolPath.childCount == 0)
            return;

        Transform targetPoint = patrolPath.GetChild(currentPointIndex);

        transform.position = Vector2.MoveTowards(
            transform.position,
            targetPoint.position,
            speed * Time.deltaTime
        );

        if (Vector2.Distance(transform.position, targetPoint.position) < 0.05f)
        {
            ChangePoint();
        }
    }

    void ChangePoint()
    {
        if (goingForward)
        {
            currentPointIndex++;
            if (currentPointIndex >= patrolPath.childCount)
            {
                currentPointIndex = patrolPath.childCount - 1;
                goingForward = false;
            }
        }
        else
        {
            currentPointIndex--;
            if (currentPointIndex < 0)
            {
                currentPointIndex = 0;
                goingForward = true;
            }
        }

        // virar sprite
        Vector3 scale = transform.localScale;
        scale.x = Mathf.Abs(scale.x) * (goingForward ? 1 : -1);
        transform.localScale = scale;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealth ph = other.GetComponent<PlayerHealth>();
            if (ph != null)
            {
                ph.TakeDamage(9999); // HITKILL
            }
        }
    }
}
