using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quad : MonoBehaviour
{
    public GameObject spieler;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(spieler.transform.position.x, this.transform.position.y, spieler.transform.position.z);
    }
}
