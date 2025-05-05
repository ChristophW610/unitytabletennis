using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gegner : MonoBehaviour
{
    public GameObject ballSchlaegerSound;
    public GameObject gegnertarget;
    public float gegnerFlightTime = 0.5f;
    public GameObject platte;
    private int lastScoreChecked = -1;
    public GameObject reichweite;
    public GameObject spieler;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int currentScore = platte.GetComponent<PlatteSound>().score;

        if (currentScore % 1 == 0 && currentScore != 0 && currentScore != lastScoreChecked) {
            gegnerFlightTime -= 0.0025f;
            reichweite.GetComponent<Reichweite>().flightTime -= 0.0025f;
            spieler.GetComponent<Spieler>().speed += 0.05f;
            lastScoreChecked = currentScore;
        }else if (currentScore == 0)
        {
            gegnerFlightTime = 0.5f;
            reichweite.GetComponent<Reichweite>().flightTime = 0.5f;
            spieler.GetComponent<Spieler>().speed = 2.5f;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Ball")
        {
            AudioSource audio = ballSchlaegerSound.GetComponent<AudioSource>();
            audio.Play();
            Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();
            
            gegnertarget.transform.position = new Vector3(Random.Range(-1.0f, 1.0f), gegnertarget.transform.position.y, gegnertarget.transform.position.z);
            Vector3 startPos = other.transform.position;
            Vector3 targetPos = gegnertarget.transform.position;

            Vector3 displacement = targetPos - startPos;
            Vector3 horizontalDisplacement = new Vector3(displacement.x, 0, displacement.z);
            Vector3 horizontalVelocity = horizontalDisplacement / gegnerFlightTime;

            float verticalDisplacement = displacement.y;
            float verticalVelocity = (verticalDisplacement + 0.5f * Mathf.Abs(Physics.gravity.y) * gegnerFlightTime * gegnerFlightTime) / gegnerFlightTime;

            Vector3 velocity = horizontalVelocity + Vector3.up * verticalVelocity;
            rb.velocity = velocity;

            /*Debug.Log("StartPos: " + startPos);
            Debug.Log("TargetPos: " + targetPos);
            Debug.Log("Displacement: " + displacement);
            Debug.Log("gegnerFlightTime: " + gegnerFlightTime);*/

            //gegnertarget.transform.position = new Vector3(0.5f, gegnertarget.transform.position.y, gegnertarget.transform.position.z);
            /*var dir = gegnertarget.transform.position - this.transform.position;
            dir = dir.normalized;
            rb.AddForce(dir * 5, ForceMode.Impulse);*/
        }
    }
}
