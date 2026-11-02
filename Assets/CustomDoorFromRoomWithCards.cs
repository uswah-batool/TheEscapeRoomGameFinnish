using UnityEngine;
using UnityEngine.SceneManagement;

public class CustomDoorFromRoomWithCards : MonoBehaviour
{
    private CustomPlayerRoomWithCards player;
    private AudioSource doorOpeningError;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<CustomPlayerRoomWithCards>();
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
        if (player.IsQueenOnTable == true)
        {
            SceneManager.LoadScene("GardenScene");
            //gameObject.SetActive(false);
        }
        else
        {
            doorOpeningError.Play();
            Debug.Log("Please place the queen of spades on the table");
        }
    }
}
