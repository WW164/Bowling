using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{

    private Rigidbody myBody;
    private bool thrown = false;
    private Vector3 ballPos;

    public float horizontalSpeed;
    public float speed;
    public float minX;
    public float maxX;

    // Start is called before the first frame update
    void Start()
    {

        myBody = GetComponent<Rigidbody>();
        ballPos = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z);

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

            ballPos.x = Mathf.Clamp(xAxis, minX, maxX);
            transform.localPosition = ballPos;

        }

        if(!thrown && Input.GetKeyDown(KeyCode.Space))
        {

            thrown = true;
            myBody.isKinematic = false;
            myBody.velocity = new Vector3(0, 0, speed);

        }

    }

    private void FixedUpdate()
    {

        if (thrown && myBody.IsSleeping())
            SceneManager.LoadScene(0);
    }
}
