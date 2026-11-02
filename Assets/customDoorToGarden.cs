using UnityEngine;
using UnityEngine.SceneManagement;
using static Unity.VisualScripting.Member;

public class customDoorToGarden : MonoBehaviour
{
    private customPlayerRoom1 player;
    private AudioSource doorOpeningError;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
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
            SceneManager.LoadScene("DungeonScene8");
            //gameObject.SetActive(false);
        }
        else
        {
            doorOpeningError.Play();
            Debug.Log("Please enter coorect code first");
        }
    }
}
