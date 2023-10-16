using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class canClimb : MonoBehaviour
{
    public bool touching = false;
    
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "unclimbable") return;
        if (gameObject.name.Contains("above"))
            Debug.Log("Touching");
        touching = true;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "unclimbable") return;
        if (gameObject.name.Contains("above"))
            Debug.Log("NotTouching");
        touching = false;
    }
}
