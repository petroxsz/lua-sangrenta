using UnityEngine;
using UnityEngine.SceneManagement;

public class TimeManager : MonoBehaviour
{
    public float levelTime = 120f; // tempo inicial da fase
    public bool isRunning = true;

    void Update()
    {
        if (!isRunning) return;

        levelTime -= Time.deltaTime;

        if (levelTime <= 0)
        {
            levelTime = 0;
            TimeOver();
        }
    }

    public void AddTime(float amount)
    {
        levelTime += amount;
    }

    void TimeOver()
    {
        isRunning = false;

        // aqui depois a gente pode colocar fade também
        SceneManager.LoadScene("GameOver");
    }
}
