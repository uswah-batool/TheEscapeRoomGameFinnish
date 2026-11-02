using UnityEngine;

public class customTeleportation : MonoBehaviour
{
    [SerializeField] private GameObject playerCameraGameObject;

    public void TiltInteract()
    {
        Vector3 TeleportPos = new Vector3(transform.position.x, playerCameraGameObject.transform.position.y, transform.position.z);
        playerCameraGameObject.transform.position = TeleportPos;
    }

}
