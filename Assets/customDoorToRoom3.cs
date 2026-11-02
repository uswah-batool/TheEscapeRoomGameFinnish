using UnityEngine;
using UnityEngine.SceneManagement;

public class customDoorToRoom3 : MonoBehaviour
{

    private customPlayerRoom2 player;
    private AudioSource doorOpeningError;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<customPlayerRoom2>();
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
            SceneManager.LoadScene("DungeonScene5");
            //gameObject.SetActive(false);
        }
        else
        {
            doorOpeningError.Play();
            Debug.Log("Please find and pick the key first");
        }
    }
}
