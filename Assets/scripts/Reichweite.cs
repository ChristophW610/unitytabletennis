using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reichweite : MonoBehaviour
{
    public Animator anim;
    public GameObject ball;
    public GameObject target;
    public GameObject ballSchlaegerSound;
    public GameObject spieler;
    public float flightTime = 1.0f;
    public bool schlagbar = false;

    public bool geschlagen = false;
    // Start is called before the first frame update
    void Start()
    {
        anim = anim.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = spieler.transform.position;
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.tag == "Ball" && !geschlagen)
        {
            if (geschlagen == false) {
                schlagbar = true;
            }
            
            //Schlagen mit Leertaste
            if (Input.GetKey(KeyCode.Space))
            {
                Rigidbody rb = ball.GetComponent<Rigidbody>();
                rb.useGravity = true;
                geschlagen = true;
                AudioSource audio = ballSchlaegerSound.GetComponent<AudioSource>();
                audio.Play();
                target.transform.position = new Vector3(Random.Range(-1.0f, 1.0f), target.transform.position.y, target.transform.position.z);
                Vector3 startPos = ball.transform.position;
                Vector3 targetPos = target.transform.position;

                Vector3 displacement = targetPos - startPos;
                Vector3 horizontalDisplacement = new Vector3(displacement.x, 0, displacement.z);
                Vector3 horizontalVelocity = horizontalDisplacement / flightTime;

                float verticalDisplacement = displacement.y;
                float verticalVelocity = (verticalDisplacement + 0.5f * Mathf.Abs(Physics.gravity.y) * flightTime * flightTime) / flightTime;

                Vector3 velocity = horizontalVelocity + Vector3.up * verticalVelocity;
                rb.velocity = velocity;
                //anim.SetBool("geschlagenParameter", geschlagen);





            }
        }
    }

    public void ballschlagen() {
        if (schlagbar) {
            Rigidbody rb = ball.GetComponent<Rigidbody>();
            rb.useGravity = true;
            geschlagen = true;
            AudioSource audio = ballSchlaegerSound.GetComponent<AudioSource>();
            audio.Play();
            target.transform.position = new Vector3(Random.Range(-1.0f, 1.0f), target.transform.position.y, target.transform.position.z);
            Vector3 startPos = ball.transform.position;
            Vector3 targetPos = target.transform.position;

            Vector3 displacement = targetPos - startPos;
            Vector3 horizontalDisplacement = new Vector3(displacement.x, 0, displacement.z);
            Vector3 horizontalVelocity = horizontalDisplacement / flightTime;

            float verticalDisplacement = displacement.y;
            float verticalVelocity = (verticalDisplacement + 0.5f * Mathf.Abs(Physics.gravity.y) * flightTime * flightTime) / flightTime;

            Vector3 velocity = horizontalVelocity + Vector3.up * verticalVelocity;
            rb.velocity = velocity;
            //anim.SetBool("geschlagenParameter", geschlagen);
            anim.SetFloat("SpeedMultiplier", 5f);
            anim.Play("schlägtvh", 0, 0f);
            
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Ball")
        {
            geschlagen = false;
            schlagbar = false;
            //anim.SetBool("geschlagenParameter", geschlagen);
        }
    }

}
