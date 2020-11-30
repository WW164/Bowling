using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    private Rigidbody myBody;
    private bool thrown = false;

    public float horizontalSpeed;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {

        myBody = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {

        BallMovement();
        
    }

    void BallMovement ()
    {

        if(!thrown)
        {

            float xAxis = Input.GetAxis("Horizontal");
            Vector3 position = transform.position;

            position.x += xAxis * horizontalSpeed;
            transform.position = position;

        }

        if(!thrown && Input.GetKeyDown(KeyCode.Space))
        {

            thrown = true;
            myBody.isKinematic = false;
            myBody.velocity = new Vector3(0, 0, speed);

        }

    }
}
