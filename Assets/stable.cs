using System;
using System.Collections.Generic;
using UnityEngine;

public class stable : MonoBehaviour
{
    public GameObject mainCam;
    public GameObject pseudoCam;
    // private float pseudoY;

    public float offset;
    public float angleOffset;
    //public float  zOffset;
    // Start is called before the first frame update
    void Start()
    {


        pseudoCam.transform.position = mainCam.transform.position;   
        pseudoCam.transform.rotation  = mainCam.transform.rotation;
   

    }

    // Update is called once per frame
    void Update()
    {
        bool c1 = Math.Abs(mainCam.transform.localPosition.y - pseudoCam.transform.localPosition.y) > offset;
        bool c2 = Math.Abs(mainCam.transform.localPosition.x - pseudoCam.transform.localPosition.x) > offset;
        bool c3 = Math.Abs(mainCam.transform.rotation.eulerAngles.y - pseudoCam.transform.eulerAngles.y) > angleOffset;
        if ( c1 || c2) {
            pseudoCam.transform.localPosition = mainCam.transform.localPosition;
            Debug.Log("Changing Pos => " + pseudoCam ) ;
        }
        if (c3) {
            pseudoCam.transform.rotation =  Quaternion.Euler(0f, mainCam.transform.localRotation.eulerAngles.y, 0f);
            Debug.Log("Changing Angle => " + pseudoCam.transform.eulerAngles) ;
        }
        transform.localPosition = new Vector3(pseudoCam.transform.localPosition.x, pseudoCam.transform.localPosition.y, mainCam.transform.localPosition.z);
        transform.rotation = pseudoCam.transform.rotation;
    
    }

    
}
