using UnityEngine;

public class HunterPathPatrol : MonoBehaviour
{
    public PatrolPath patrolPath;
    public float speed = 2f;

    private int currentPointIndex = 0;
    private bool goingForward = true;

    void Update()
{
    if (patrolPath == null || patrolPath.transform.childCount == 0)
        return;

    Transform targetPoint = patrolPath.transform.GetChild(currentPointIndex);

    
    Vector2 previousPosition = transform.position;

    transform.position = Vector2.MoveTowards(
        transform.position,
        targetPoint.position,
        speed * Time.deltaTime
    );

    
    float movementDirection = transform.position.x - previousPosition.x;

    if (movementDirection != 0)
    {
        Vector3 scale = transform.localScale;
        scale.x = Mathf.Abs(scale.x) * Mathf.Sign(movementDirection);
        transform.localScale = scale;
    }

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
            if (currentPointIndex >= patrolPath.transform.childCount)
            {
                currentPointIndex = patrolPath.transform.childCount - 1;
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
}
