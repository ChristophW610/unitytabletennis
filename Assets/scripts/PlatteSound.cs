using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlatteSound : MonoBehaviour
{
    public GameObject ballTischSound;
    public int score = 0;
    
    public TMP_Text st;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            AudioSource audio = ballTischSound.GetComponent<AudioSource>();
            audio.Play();
            
            if (collision.transform.position.z > 0) {
                score++;
                //Debug.Log(score);
                st.SetText(score.ToString());
            }
        }
    }
}
