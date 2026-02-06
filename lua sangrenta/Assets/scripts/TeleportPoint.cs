using UnityEngine;
using UnityEngine.SceneManagement; // para carregar cena

public class TeleportToNextLevel : MonoBehaviour
{
    public string sceneToLoad; // nome da fase final
    public Transform spawnPoint; // posição do player na nova cena

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Teleporta Player na mesma cena
            if (spawnPoint != null)
            {
                other.transform.position = spawnPoint.position;
            }

            // OU, para mudar de cena
            if (!string.IsNullOrEmpty(sceneToLoad))
            {
                SceneManager.LoadScene(sceneToLoad);
            }
        }
    }
}
