using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private GameObject feather;
    private Vector3 lastPos;
    private Transform player;
    [SerializeField] private float featherTime = 4f;
    private bool isRunning;
    // Start is called before the first frame update
    void Awake()
   {
        player = gameObject.GetComponent<Transform>();
   }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);
        movementDirection.Normalize();

        transform.Translate(movementDirection * speed * Time.deltaTime, Space.World);

        if (movementDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
            // Rotate player towards where they are currently going
        }

        if (featherTime > 0)
        {
            featherTime -= Time.deltaTime;
        }
     

       if (player.transform.position != lastPos && featherTime < 0)
       {
            Instantiate(feather, transform.position, transform.rotation);
            // If player has moved spawn feather

            if(isRunning ==true)
            {
                featherTime = 1f;
            }
            else
            {
                featherTime = 4f;
            }
           

       }


        lastPos = player.transform.position;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            speed = 50f;
            isRunning = true;
        }
       else if (Input.GetKeyUp(KeyCode.Space))
       {
            speed = 10f;
            isRunning = false;
       }

    }


}
