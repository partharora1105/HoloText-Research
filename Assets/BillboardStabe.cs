using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillboardStabe : MonoBehaviour
{
    public Transform cam;
    private Transform initCam;
    // Start is called before the first frame update
    void Start()
    {
        initCam = cam;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, initCam.position.y, gameObject.transform.position.z);
    }
}
