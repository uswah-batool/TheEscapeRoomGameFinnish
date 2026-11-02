using UnityEngine;

public class customKeyForAnotherRoom : MonoBehaviour
{
    private customPlayerRoom5 player;
    private AudioSource taskDone;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<customPlayerRoom5>();
        if (player == null)
        {
            Debug.LogError("player variable is empty");
        }
        taskDone = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void TiltInteract()
    {
        AudioSource.PlayClipAtPoint(taskDone.clip, transform.position);
        player.DoesPlayerHaveKey = true;
        gameObject.SetActive(false);
    }

}
