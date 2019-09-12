using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireBallScript : MonoBehaviour
{

    public Transform target;
    public ParticleSystem explosion;
    public float speed;
    public float lifetime = 5;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().velocity = transform.forward * speed;
    }

    // Update is called once per frame
    void Update()
    {
        lifetime -= Time.deltaTime;
        if(lifetime <= 0)
        {
            explode();
        }
        // transform.position += transform.forward /2;  
    }
    public void FindTarget(RaycastHit hit)
    {
        this.target.position = hit.transform.position;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name != "Wand")
        {
            explode();
        }
    }

    public void explode()
    {
        explosion.gameObject.transform.position = transform.position;
        Instantiate<ParticleSystem>(explosion);
        Destroy(gameObject);
    }


}
