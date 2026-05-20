using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class FinishZone : MonoBehaviour
{
    [SerializeField] private GameObject victoryCanvas;
    [SerializeField] private CanvasGroup victoryCanvasGroup;

    void Start()
    {
        if (victoryCanvas != null) victoryCanvas.SetActive(false);
        if (victoryCanvasGroup != null) victoryCanvasGroup.alpha = 0f;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Time.timeScale = 0f;
            victoryCanvas.SetActive(true);

            if (victoryCanvasGroup != null)
            {
                victoryCanvasGroup.DOFade(1f, 1.5f).SetUpdate(true);
            }
        }
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
