using UnityEngine;
using UnityEngine.SceneManagement;

public class customDoorToRoom5 : MonoBehaviour
{

    private customPlayerRoom5 player;
    private AudioSource doorOpeningError;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<customPlayerRoom5>();
        if (player == null)
        {
            Debug.LogError("player variable is empty");
        }
        doorOpeningError = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void TiltInteract()
    {
        if (player.DoesPlayerHaveKey == true)
        {
            SceneManager.LoadScene("DungeonScene4");
            //gameObject.SetActive(false);
        }
        else
        {
            doorOpeningError.Play();
            Debug.Log("Please find and pick the key first");
        }
    }
}
