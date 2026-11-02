using UnityEngine;
using UnityEngine.SceneManagement;

public class customKeypad : MonoBehaviour
{
    [SerializeField] private string value;
    private string mycode = "107";

    private customPlayerRoom1 player;
    private AudioSource keyPressed;
    private AudioSource rightCodeEntered;

    void Start()
    {
        player = GameObject.Find("Player").GetComponent<customPlayerRoom1>();
        if (player == null)
        {
            Debug.LogError("player variable is empty");
        }
        keyPressed = GetComponent<AudioSource>();
        rightCodeEntered= transform.parent.GetComponent<AudioSource>();

    }
    public void TiltInteract()
    {
        keyPressed.Play();
        //Debug.Log(value);
        if (value == "reset")
        {
            player.enteredCode = "";
        }
        else
        {
            if (player.enteredCode.Length == 3)
            {
                player.enteredCode = value;
            }
            else
            {
                player.enteredCode += value;
            }
            if (player.enteredCode.Length == 3)
            {
                if (player.enteredCode == mycode)
                {
                    player.DoesPlayerEnteredCorrectKey = true;
                    Invoke("PlaySuccessSound", 1.5f);
                }
            }
        }
        Debug.Log(player.enteredCode);
    }

    void PlaySuccessSound()
    {
        rightCodeEntered.Play();
    }


}
