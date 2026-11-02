using UnityEngine;

public class TiltPickupObject : MonoBehaviour
{
    public static TiltPickupObject currentlyHeld = null;

    private Rigidbody rb;
    private Transform originalParent;
    private bool isHeld = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        originalParent = transform.parent;
    }

    public void TiltInteract()
    {
        if (!isHeld && currentlyHeld == null)
        {
            // Pick up
            isHeld = true;
            currentlyHeld = this;
            rb.isKinematic = true;
            transform.SetParent(Camera.main.transform);
            transform.localPosition = new Vector3(0, 0, 1.5f); // hold in front of camera
        }
        else if (isHeld)
        {
            // Drop
            isHeld = false;
            currentlyHeld = null;
            transform.SetParent(originalParent);
            rb.isKinematic = false;
        }
    }
}