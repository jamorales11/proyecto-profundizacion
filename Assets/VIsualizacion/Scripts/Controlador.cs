using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controlador : MonoBehaviour
{
    AnimationCurve anim1;
    AnimationCurve anim2;

    // Start is called before the first frame update
    void Start()
    {
        animacion();
    }

    // Update is called once per frame
    void Update()
    {
        if( this.transform.position.y > 27){
            this.GetComponent<FogEffect>().enabled = false;
            this.GetComponent<UnderwaterEffect>().enabled = false;
            this.GetComponent<Camera>().farClipPlane = 900;
        }
        else{
            this.GetComponent<FogEffect>().enabled = true;
            this.GetComponent<UnderwaterEffect>().enabled = true;
            this.GetComponent<Camera>().farClipPlane = 180;
        }

        this.transform.position = new Vector3(transform.position.x, anim1.Evaluate(Time.time), transform.position.y);
        this.transform.rotation =  Quaternion.Euler(anim2.Evaluate(Time.time), 180f, transform.rotation.z);
    }



    void animacion()
    {
        Keyframe[] bajar = new Keyframe[3];
        bajar[0] = new Keyframe(0f, 60f);
        bajar[1] = new Keyframe(5f, 60f);
        bajar[2] = new Keyframe(10f, 20f);

        Keyframe[] rotar = new Keyframe[4];
        rotar[0] = new Keyframe(0f, 15f);
        rotar[1] = new Keyframe(7.5f, 15f);
        rotar[2] = new Keyframe(10f, 0f);
        rotar[3] = new Keyframe(12f, -15f);
        

        anim1 = new AnimationCurve(bajar);
        anim2 = new AnimationCurve(rotar);

    }
}
