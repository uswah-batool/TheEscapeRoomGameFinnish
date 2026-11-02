using UnityEngine;
using UnityEngine.UI;

public class RadialProgressBar : MonoBehaviour
{
    public Image progressBar;
    public float duration = 3f; // Time to fill completely
    private float elapsedTime = 0f;
    private bool isGazing = false;
    private bool hasCompleted = false; // Track if progress completed

    void Start()
    {
        progressBar.fillAmount = 0f;
        progressBar.enabled = false; // Start hidden
    }

    void Update()
    {
        if (isGazing && !hasCompleted) // Only fill if not completed
        {
            elapsedTime += Time.deltaTime;
            progressBar.fillAmount = Mathf.Clamp01(elapsedTime / duration);

            if (elapsedTime >= duration)
            {
                hasCompleted = true; // Mark as completed
                progressBar.enabled = false; // Hide progress bar
                Debug.Log("Progress Completed and Hidden!");
            }
        }
    }

    public void StartProgress()
    {
        if (hasCompleted) return; // Prevent restarting after completion

        isGazing = true;
        progressBar.enabled = true;
        elapsedTime = 0f;
    }

    public void StopProgress()
    {
        isGazing = false;
        progressBar.enabled = false;

        if (!hasCompleted) // Only reset if progress hasn't completed
        {
            progressBar.fillAmount = 0f;
            elapsedTime = 0f;
        }
    }
    public void ResetProgress()
    {
        hasCompleted = false;
        progressBar.fillAmount = 0f;
        elapsedTime = 0f;
        progressBar.enabled = false;
    }
}
