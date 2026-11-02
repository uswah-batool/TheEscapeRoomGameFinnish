using UnityEngine;

public class TriggerZone : MonoBehaviour
{
    private CustomPlayerRoomDropStuff player;
    private AudioSource taskDone;
    public int totalObjectsToDetect = 7;
    private int currentCount = 0;

    void Start()
    {
        player = GameObject.Find("Player").GetComponent<CustomPlayerRoomDropStuff>();
        if (player == null)
        {
            Debug.LogError("player variable is empty...");
        }
        taskDone = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        currentCount++;
        Debug.Log($"Object {currentCount}/{totalObjectsToDetect} exited.");

        if (currentCount >= totalObjectsToDetect)
        {
            AudioSource.PlayClipAtPoint(taskDone.clip, transform.position);
            player.IsRoomEmpty = true;
            Debug.Log("Task Completed! All objects have been thrown out.");
        }
    }
}
