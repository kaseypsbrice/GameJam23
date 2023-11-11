using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class bophint : MonoBehaviour
{
    public KeySwitching switching;
    public TMP_Text hint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(hint.text != switching.randomKey)
        {
            hint.SetText(switching.randomKey);
        }
    }
}
