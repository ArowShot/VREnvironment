using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WatchTrigger : MonoBehaviour, ITriggerable
{
    private TimeManager tm;
    
    private void Start()
    {
        tm = FindObjectOfType<TimeManager>();
    }
    
    public void Trigger(bool down)
    {
        print(down);
        if (down)
        {
            tm.SetDesiredTimescale(0.01f);
            
            tm.GetComponent<AudioSource>().Play();
        }
        else
        {
            tm.SetDesiredTimescale(1.0f);
        }
    }
}
