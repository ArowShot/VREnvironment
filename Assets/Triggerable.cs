using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triggerable : MonoBehaviour
{
    public GameObject HideNormally;
    
    public void Trigger()
    {
        HideNormally.SetActive(!HideNormally.active);
    }
}
