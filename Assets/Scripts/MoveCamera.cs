using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{

    private float speedHor = 2.0f;
    private float speedVer = 2.0f;

    public float xCoord = 90.0f;
    public float yCoord = 15.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        xCoord += speedHor * Input.GetAxis("Mouse X");
        yCoord += speedVer * -Input.GetAxis("Mouse Y");

        transform.eulerAngles = new Vector3(yCoord, xCoord, 0);


    }
}
