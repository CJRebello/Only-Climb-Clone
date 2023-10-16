using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson.PunDemos;

public class launchPlayer : MonoBehaviour
{
    [SerializeField]
    [Range(1,100)]
    int fowardVelocity;
    [SerializeField]
    [Range(1, 100)]
    int verticalHeight;
    [SerializeField]
    [Range(0, 180)]
    int angleOffset;
    // Start is called before the first frame update
    public int getFowardVelocity()
    {
        return fowardVelocity;
    }
    public int getVerticalHeight()
    {
        return verticalHeight;
    }
    public int getAngleOffset()
    {
        return angleOffset;
    }
}
