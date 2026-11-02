using UnityEngine;
using UnityEngine.SceneManagement;

public class CustomDoorFromRoomDropOut : MonoBehaviour
{

    private CustomPlayerRoomDropStuff player;
    private AudioSource doorOpeningError;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<CustomPlayerRoomDropStuff>();
        if (player == null)
        {
            Debug.LogError("player variable is empty..");
        }
        doorOpeningError = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TiltInteract()
    {
        if (player.IsRoomEmpty == true)
        {
            SceneManager.LoadScene("DungeonScene1");
            //gameObject.SetActive(false);
        }
        else
        {
            doorOpeningError.Play();
            Debug.Log("Please empty the room");
        }
    }
}
