using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GlowScript : MonoBehaviour
{

    private Shader notGlow;
    private Shader glow;
    private Renderer rend;
    public GameObject halo;
    // Start is called before the first frame update
    void Start()
    {
        
        rend = GetComponent<Renderer>();
        notGlow = Shader.Find("Diffuse");
        glow = Shader.Find("Self-Illumin/Outlined Diffuse");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseOver()
    {
        rend.material.shader = glow;
        halo.SetActive(true);
    }
    void OnMouseExit()
    {
        rend.material.shader = notGlow;
        halo.SetActive(false);
    }
}
