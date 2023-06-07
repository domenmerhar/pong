using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PauseMenu : MonoBehaviour
{
    [Header("Classes")]
    [SerializeField] private KeyCode pauseKey;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private PostProcessProfile postProcessProfile;

    [SerializeField] private Vignette vignette;

    [Header("Values")]
    [SerializeField] private float defaultVignette;
    [SerializeField] private float pauseVignette;

    public static bool isPaused;

    private void Start()
    {
        isPaused = false;
        postProcessProfile.TryGetSettings(out vignette);
        vignette.intensity.value = defaultVignette;
    }

    private void Update()
    {
        if (Input.GetKeyDown(pauseKey))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    private void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
        vignette.intensity.value = pauseVignette;
        isPaused = true;
    }

    private void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        vignette.intensity.value = defaultVignette;
        isPaused = false;
    }
}