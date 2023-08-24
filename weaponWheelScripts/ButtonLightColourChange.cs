using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonLightColourChange : MonoBehaviour
{
    public GameObject ObjectToChange; //  Drag object on to name
    public Material MaterialToChangeTo;


    public void ToggleLightColour()
    {
        ObjectToChange.GetComponent<Renderer>().material = MaterialToChangeTo;
    }


}
