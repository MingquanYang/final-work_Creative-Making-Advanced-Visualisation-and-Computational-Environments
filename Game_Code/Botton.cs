using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Uduino;

public class NewBehaviourScript : MonoBehaviour
{
    public Text textZone;

    // Start is called before the first frame update
    void Start()
    {
        UduinoManager.Instance.pinMode(2, PinMode.Input_pullup);
    }

    // Update is called once per frame
    void Update()
    {
        int buttonValue = UduinoManager.Instance.digitalRead(2);
        
        if(buttonValue == 0)
        {
            textZone.text = "Down";
        }else
        {
            textZone.text = "Up";
        }
    }
}
