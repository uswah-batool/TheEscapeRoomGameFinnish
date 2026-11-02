using UnityEngine;
using UnityEngine.SceneManagement;

public class customDoorToRoom4 : MonoBehaviour
{
    private customPlayerRoom4 player;
    private AudioSource doorOpeningError;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<customPlayerRoom4>();
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
        if (player.IsBallOnTheTargettPosition == true)
        {
            SceneManager.LoadScene("DungeonScene6");
            //gameObject.SetActive(false);
        }
        else
        {
            doorOpeningError.Play();
            //Debug.Log("Please replace the ball to the target location");
        }
    }
}
