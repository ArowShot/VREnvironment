﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triggerable : MonoBehaviour, ITriggerable
{
    public GameObject HideNormally;
    
    public Transform tip;
    public GameObject fireBall;
    public int magic;

    public FireBallController fbc;
    public void Trigger(bool down)
    {
        if (!down)
            return;
        
        HideNormally.SetActive(!HideNormally.active);

       
       /* Debug.Log("hit" +hit.point.ToString());
        Debug.Log("tip " +tip.position.ToString());
        Debug.Log("this " + transform.position.ToString());*/
        switch (magic)
        {
            
            case 1:
                
               
                Shoot(fireBall);
                
                break;
            default:
                HideNormally.SetActive(true);
                break;
        }


    }

    public void Shoot(GameObject projectile)
    {
        //  projectile.transform.position = tip.transform.position;
        //  projectile.transform.rotation = tip.transform.rotation;
        GameObject fireBall = FireBallController.SharedInstance.GetPooledObject();
            if(fireBall != null)
            {
                fireBall.transform.position = tip.transform.position;
                fireBall.transform.rotation = tip.transform.rotation;
                fireBall.SetActive(true);
            }
        

        Instantiate<GameObject>(projectile);


    }


}
