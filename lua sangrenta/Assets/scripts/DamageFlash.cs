using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DamageFlash : MonoBehaviour
{
    public Image flashImage;
    public float flashDuration = 0.15f;
    public float maxAlpha = 0.35f;

    public void Flash()
    {
        StartCoroutine(FlashRoutine());
    }

    IEnumerator FlashRoutine()
    {
        // Aparece
        flashImage.color = new Color(1, 0, 0, maxAlpha);
        yield return new WaitForSeconds(flashDuration);

        // Some
        flashImage.color = new Color(1, 0, 0, 0);
    }
}
