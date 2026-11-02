using UnityEngine;
using UnityEngine.SceneManagement;
using static Unity.VisualScripting.Member;

public class customDoorToRoom2 : MonoBehaviour
{
    private customPlayerRoom1 player;
    private AudioSource doorOpeningError;
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<customPlayerRoom1>();
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
        if (player.DoesPlayerEnteredCorrectKey == true)
        {
            SceneManager.LoadScene("DungeonScene2");
            //gameObject.SetActive(false);
        }
        else
        {
            doorOpeningError.Play();
            Debug.Log("Please enter coorect code first");
        }
    }
}
