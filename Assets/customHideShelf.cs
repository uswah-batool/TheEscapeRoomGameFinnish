using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class customHideShelf : MonoBehaviour
{
    public RadialProgressBar canvasScript;
    //private MeshRenderer myRenderer;
    private bool gazeChange = false;
    private float myTimer = 0f;
    private AudioSource wayOut;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //myRenderer = GetComponent<MeshRenderer>();
        wayOut = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gazeChange)
        {
            myTimer += Time.deltaTime;
            if (myTimer >= 3f)
            {
                gameObject.SetActive(false);
                PlaySoundAfterHide();
            }
        }
    }
    void PlaySoundAfterHide()
    {
        // Create a temporary GameObject to play the sound after hiding
        GameObject audioPlayer = new GameObject("AudioPlayer");
        AudioSource audioSource = audioPlayer.AddComponent<AudioSource>();
        audioSource.clip = wayOut.clip;
        audioSource.Play();

        // Destroy the audio player object after the sound finishes playing
        Destroy(audioPlayer, audioSource.clip.length);
        SceneManager.LoadScene("DungeonScene2");
    }

    public void OnPointerEnter()
    {
        canvasScript.StartProgress(); // Start showing progress bar
        GazeAt(true);
    }

    public void OnPointerExit()
    {
        canvasScript.StopProgress(); // Hide progress bar
        GazeAt(false);
    }

    public void GazeAt(bool gazing)
    {
        if (gazing)
        {
            gazeChange = true;
        }
        else
        {
            myTimer = 0f;
            gazeChange = false;
        }
    }
}
