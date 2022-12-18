using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject bullet;

    //Private variables
    public float throttle = 0f;
    public float speed = 0f;
    public float maxSpeed = 60f;
    private float turnSpeed = 70;
    private float horizontalInput;
    private float forwardInput;

    //bullet spawn rate variable
    private float timer;

    public AudioClip fireSound;
    public AudioSource playerAudio;

    // Start is called before the first frame update
    void Start()
    {
        playerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //Collect player input
        horizontalInput = Input.GetAxis("Vertical");
        forwardInput = Input.GetAxis("Horizontal");

        //Steer the plane up/down
        transform.Rotate(Vector3.down, Time.deltaTime * turnSpeed * forwardInput);

        //Rotate the plane on x axis
        transform.Rotate(Vector3.forward, Time.deltaTime * turnSpeed * horizontalInput);

        //Move the plane forward
        transform.Translate(Vector3.down * Time.deltaTime * speed);

        //steer left or right if q or e is pressed
        if (Input.GetKey(KeyCode.Q)){
            transform.Rotate(Vector3.right, Time.deltaTime * turnSpeed);
        }else if(Input.GetKey(KeyCode.E)){
            transform.Rotate(Vector3.left, Time.deltaTime * turnSpeed);
        }
        
        if(throttle <= 0f){
            throttle = 0f;
            speed = 0f;
        }else if(throttle >= 100f){
            throttle = 100f;
            speed = 60f;
        }

        if(Input.GetAxis("Mouse ScrollWheel") > 0f){

            throttle++;
            speed =  maxSpeed / 100f  * throttle;
        }else if (Input.GetAxis("Mouse ScrollWheel") < 0f){

            throttle--;
            speed =  maxSpeed / 100f  * throttle;
        }

        timer -= Time.deltaTime;
        //Check for timer
        if(timer <= 0f){

            //spawn bullet when pressing space
            if(Input.GetMouseButton(0)){
                Instantiate(bullet, transform.position, bullet.transform.rotation);
                playerAudio.PlayOneShot(fireSound, 1.0f);
                timer = 0.5f;
            }
        }
        
        
    }
}
/*



rotate left and right
z and x 
*/