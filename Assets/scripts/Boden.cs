using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Boden : MonoBehaviour
{
    public static int scr;
    public GameObject ball;
    public GameObject spieler;
    public GameObject tischplatte;
    public TMP_Text st;
    public GameObject scoreText;
    public GameObject joystick;
    public GameObject knopf;
    public GameObject cammera;

    // Start is called before the first frame update
    void Start()
    {
        RectTransform rt = scoreText.GetComponent<RectTransform>();
        rt.anchoredPosition = new Vector2(0, -150f);
        RectTransform rtt = joystick.GetComponent<RectTransform>();
        rtt.anchoredPosition = new Vector2(250, 400);
    }

    // Update is called once per frame
    void Update()
    {
        RectTransform rt = scoreText.GetComponent<RectTransform>();
        rt.anchoredPosition = new Vector2(0, -150f);
        RectTransform rtt = joystick.GetComponent<RectTransform>();
        rtt.anchoredPosition = new Vector2(250, 250);
        RectTransform rttt = knopf.GetComponent<RectTransform>();
        rttt.anchoredPosition = new Vector2(-60, 60);

    }


    public void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Ball")
        {
            Rigidbody rb = ball.GetComponent<Rigidbody>();
            rb.useGravity = false;
            rb.velocity = Vector3.zero;
            ball.transform.position = new Vector3(0, 1.6f, -2.32f);
            spieler.transform.position = new Vector3(0, -0.5f, -4.05f);
            scr = tischplatte.GetComponent<PlatteSound>().score;
            tischplatte.GetComponent<PlatteSound>().score = 0;
            st.SetText(tischplatte.GetComponent<PlatteSound>().score.ToString());
            cammera.GetComponent<sm>().startResult();
        }
    }
}
