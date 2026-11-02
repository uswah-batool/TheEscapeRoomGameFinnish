using UnityEngine;

public class CustomInteractableBall : MonoBehaviour
{

    public float bounceForce = 10f;
    public Transform playerCam;  // drag the main camera here in Inspector
    private customPlayerRoom4 player;
    private AudioSource taskDone;
    private Vector3 areaMin, areaMax;

    void Start()
    {
        player = GameObject.Find("Player").GetComponent<customPlayerRoom4>();
        if (player == null)
        {
            Debug.LogError("player variable is empty");
        }
        areaMax = new Vector3(7.78f, 3.31f, -0.05f);
        areaMin = new Vector3(4.35f, 3.31f, -0.05f);
        taskDone = GetComponent<AudioSource>();
    }
    void Update()
    {
        Vector3 currentPos = transform.position;
        float tolerance = 0.05f; // You can increase if needed
        bool isWithinTargetArea =
            currentPos.x >= areaMin.x - tolerance && currentPos.x <= areaMax.x + tolerance &&
            currentPos.y >= areaMin.y - tolerance && currentPos.y <= areaMax.y + tolerance &&
            currentPos.z >= areaMin.z - tolerance && currentPos.z <= areaMax.z + tolerance;

        if (isWithinTargetArea)
        {
            AudioSource.PlayClipAtPoint(taskDone.clip, transform.position);
            //Debug.Log("Ball reached the position: "+ currentPos);
            player.IsBallOnTheTargettPosition = true;
        }
        else
        {
            //Debug.Log("Ball not reached: "+ currentPos);
            //player.IsBallOnTheTargettPosition = false;
        }
    }

    public void TiltInteract()
    {
        Debug.Log("Twister activated on ball!");

        // Get Rigidbody component
        Rigidbody rb = GetComponent<Rigidbody>();

        // Calculate direction to bounce: where player is looking + a bit upward
        // Vector3 bounceDirection = Vector3.up;
        // Direction: Mostly forward, slightly upward
        Vector3 bounceDirection = (playerCam.forward + Vector3.up * 0.5f).normalized;


        // Apply force
        rb.AddForce(bounceDirection * bounceForce, ForceMode.Impulse);
    }
}
