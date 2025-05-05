using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Scoreanzeigen : MonoBehaviour
{
    public TMP_Text st;
    // Start is called before the first frame update
    void Start()
    {
        st.SetText(Boden.scr.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
