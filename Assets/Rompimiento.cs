using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class Rompimiento2 : MonoBehaviour
{
    public float time=1f;
    public float max=1f;
    public Slider main;
    // Start is called before the first frame update
    void Start()
    {
        max=4f;
        main= GameObject.Find("Slider").GetComponent<Slider>();
        
    }

    // Update is called once per frame
    void Update()
    {
        time=max-main.value*max;
         GetComponent<Renderer>().sharedMaterial.SetFloat("_TessellationUniform", time);
    
    }

    public void changeTime(float newValue){
        time=max-newValue*max;
        GetComponent<Renderer>().sharedMaterial.SetFloat("_TessellationUniform", time);
        
            }
}
