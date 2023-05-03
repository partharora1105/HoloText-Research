using UnityEngine;
public class BillboardObject : MonoBehaviour
{
    public Transform cameraTransform;
    public float positionalOffset = 0.15f;
    public float rotationalOffset = 10f;
    private Transform initCam;

    void Start()
    {
        initCam = cameraTransform;
    }

    void Update()
    {
        transform.LookAt(cameraTransform);
        // apply positional offset
        Vector3 cameraPosition = cameraTransform.position;
        Vector3 objectPosition = transform.position;
        Vector3 offset = new Vector3(cameraPosition.x - objectPosition.x, cameraPosition.y - objectPosition.y, 0f).normalized * positionalOffset;
        transform.position = cameraPosition - offset;
        //transform.position = new Vector3(transform.position.x, initCam.position.y, transform.position.z);
        // apply rotational offset
        float angle = Quaternion.Angle(transform.rotation, cameraTransform.rotation);
        if (angle > rotationalOffset)
        {
            Quaternion targetRotation = Quaternion.RotateTowards(transform.rotation, cameraTransform.rotation, angle - rotationalOffset);
            transform.rotation = targetRotation;
        }
        gameObject.transform.eulerAngles = new Vector3(0,gameObject.transform.eulerAngles.y,0);
    }
}