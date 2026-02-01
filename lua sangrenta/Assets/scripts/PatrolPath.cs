using UnityEngine;

public class PatrolPath : MonoBehaviour
{
    public Color pathColor = Color.yellow;

    private void OnDrawGizmos()
    {
        Gizmos.color = pathColor;

        for (int i = 0; i < transform.childCount - 1; i++)
        {
            Transform a = transform.GetChild(i);
            Transform b = transform.GetChild(i + 1);

            Gizmos.DrawLine(a.position, b.position);
        }
    }
}
