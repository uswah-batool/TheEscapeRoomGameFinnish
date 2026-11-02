using UnityEngine;

public class TiltInteract : MonoBehaviour
{
    public Transform cam; // to get reference of the camera to be followed, transform contains the information about the position, relation and scale, this creates a Component in Unity where the script is added 
    public Transform OtherCrosshair;
    bool interacted = false;
    bool rollReset = true;
    float startAngle = 0;
    public float twistMultiplier = 2.5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Get a point in front of the camera, to make crosshair follow where ever the player looks at
        Vector3 target = cam.position + cam.forward * 2; // vector3 contains info about x,y,z
        
        // Place the crossfair in that position
        transform.position = target; // crosshair is following whereever camera is rotating but the circle/crosshair is not rotating
        
        // Have the crosshair look at the camera 
        transform.LookAt(cam.position); // currently feels useless
        
        // Place the other crosshair in that same position
        OtherCrosshair.position = target;

        // Have the other crosshair also look at the camera
        OtherCrosshair.LookAt(cam.position);

        // Get the roll angle of the camera
        float rollAngle = cam.rotation.eulerAngles.z;
        if (rollAngle > 180) rollAngle -= 360; // Normalize to [-180, 180]

        // Rotate the crosshair based on the camera roll
        transform.Rotate(0, 0, -rollAngle * 2);

        // Adjust the other crosshair to track both left and right tilts
        if (rollAngle < 0)
            OtherCrosshair.rotation = Quaternion.Euler(OtherCrosshair.eulerAngles.x, OtherCrosshair.eulerAngles.y, -45);
        else
            OtherCrosshair.rotation = Quaternion.Euler(OtherCrosshair.eulerAngles.x, OtherCrosshair.eulerAngles.y, 45);

        // Calculate the effective angle for interaction logic
        float angdiff = (rollAngle - startAngle) * twistMultiplier;
        angdiff = Mathf.Clamp(angdiff, -45f, 45f);

        // Trigger interaction only once when crossing the threshold
        if ((angdiff <= -45f || angdiff >= 45f) && rollReset)
        {
            interacted = true;
            rollReset = false;
            RaycastHit hit;
            if (Physics.Raycast(cam.position, cam.forward, out hit, 10))
            {
                hit.transform.gameObject.SendMessage("TiltInteract");
            }
        }

        // Reset interaction when returning to neutral position
        if (angdiff > -30f && angdiff < 30f)
        {
            rollReset = true;
            interacted = false;
        }
    }
}
