using UnityEngine;
using TMPro;

public class PlacaAviso : MonoBehaviour
{
    public GameObject avisoUI;
    public TextMeshProUGUI avisoTexto;

    [TextArea]
    public string mensagem;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            avisoUI.SetActive(true);
            avisoTexto.text = mensagem;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            avisoUI.SetActive(false);
        }
    }
}
