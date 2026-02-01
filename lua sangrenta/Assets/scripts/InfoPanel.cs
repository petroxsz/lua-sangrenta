using UnityEngine;

public class InfoPanel : MonoBehaviour
{
    public GameObject panel;

    public void Open()
    {
        panel.SetActive(true);
    }

    public void Close()
    {
        panel.SetActive(false);
    }
}
