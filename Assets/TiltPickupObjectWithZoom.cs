using UnityEngine;

public class TiltPickupObjectWithZoom : MonoBehaviour
{
    public static TiltPickupObjectWithZoom currentlyHeld = null;

    private Rigidbody rb;
    private Transform originalParent;
    private bool isHeld = false;

    private Vector3 originalScale; // Store original scale
    public float zoomScaleMultiplier = 1.5f; // Adjust as needed

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        originalParent = transform.parent;
        originalScale = transform.localScale; // Save original size
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
            transform.localPosition = new Vector3(0, 0, 1.0f); // slightly closer
            transform.localScale = originalScale * zoomScaleMultiplier; // Zoom in
        }
        else if (isHeld)
        {
            // Drop
            isHeld = false;
            currentlyHeld = null;
            transform.SetParent(originalParent);
            rb.isKinematic = false;

            transform.localScale = originalScale; // Reset scale
        }
    }
}
