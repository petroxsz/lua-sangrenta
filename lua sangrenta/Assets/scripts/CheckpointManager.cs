using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    public static CheckpointManager Instance;

    public Vector3 lastCheckpointPosition;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        lastCheckpointPosition = Vector3.zero;
    }

    public void SetCheckpoint(Vector3 position)
    {
        lastCheckpointPosition = position;
        Debug.Log("Checkpoint salvo em: " + position);
    }

    public Vector3 GetCheckpoint()
    {
        return lastCheckpointPosition;
    }
}
