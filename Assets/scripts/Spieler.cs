using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spieler : MonoBehaviour
{
    public Animator anim;
    public float speed = 1.5f;
    private Rigidbody rb;
    public Joystick joystick;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //WASD
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(1f * (-speed) * Time.deltaTime, 0f, 0f);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(1f * speed * Time.deltaTime, 0f, 0f);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(0f, 0f, 1f * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(0f, 0f, 1f * (-speed) * Time.deltaTime);
        }
        bool GehtVariable = false;
        Vector3 direction = new Vector3(joystick.Horizontal, 0f, joystick.Vertical);
        if (direction.magnitude > 0.1f)
        {
            GehtVariable = true;
            //if (transform.position.z < -2.35f || (transform.position.z < 0 && (transform.position.x > 1.45f || transform.position.x < -1.45f))) {
            Vector3 move = direction.normalized * speed * Time.deltaTime;
            Vector3 newPosition = transform.position + move;
            float minX = -1.45f;
            float maxX = 1.45f;
            float minZ = -2.35f;
            float maxZ = 0f;
            bool inForbiddenZone =
                newPosition.x >= minX && newPosition.x <= maxX &&
                newPosition.z >= minZ && newPosition.z <= maxZ;

            if (!inForbiddenZone && newPosition.z<0) {
                transform.position = newPosition;
            }
            

            // Bewegen
            //transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);

            //}
            
        }
        anim.SetBool("GehtParameter", GehtVariable);

    }

    
}
