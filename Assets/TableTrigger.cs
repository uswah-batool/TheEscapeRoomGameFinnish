using UnityEngine;

public class TableTrigger : MonoBehaviour
{
    private CustomPlayerRoomWithCards player;
    private AudioSource taskDone;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<CustomPlayerRoomWithCards>();
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
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Card_SpadeQueen")
        {
            AudioSource.PlayClipAtPoint(taskDone.clip, transform.position);
            player.IsQueenOnTable = true;
            Debug.LogError("Card Placed");
        }
    }
}
