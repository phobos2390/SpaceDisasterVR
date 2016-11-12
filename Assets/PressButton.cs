using UnityEngine;
using System.Collections;

public class PressButton : MonoBehaviour
{
    public void Press()
    {
        GetComponent<Animation>().wrapMode = WrapMode.Once;
        GetComponent<Animation>().Play();
        print("Pressed Button");
    }
}
