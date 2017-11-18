using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeController : MonoBehaviour {

    private Animator animacion;
    private Transform parent;
    private ShieldController shieldManager;
    //AudioSource sound;

    private float transitionTimer;
    public float changeTimer;
    private float transitionCounter;
    private float changeCounter;

    void Start()
    {
        parent = this.transform.parent;
        animacion = parent.GetChild(2).GetComponent<Animator>();
        shieldManager = parent.GetChild(2).GetComponent<ShieldController>();
        //sound = GetComponent<AudioSource>();

        changeCounter = 0f;
        transitionTimer = 0.3f;
        transitionCounter = 0f;
        
        animacion.SetBool("Green", false);
        animacion.SetBool("Red", true);
        animacion.SetBool("Transition", false);
    }

    void Update()
    {
        changeCounter -= Time.deltaTime;
        transitionCounter -= Time.deltaTime;

        if (enabledChange())
        {
            if (Input.GetKey(KeyCode.Alpha1) && animacion.GetBool("Red") && !animacion.GetBool("Transition"))
            {
                animacion.SetBool("Transition", true);
                changeCounter = changeTimer;
                transitionCounter = transitionTimer;
                
                //sound.Play();
            }

            if (Input.GetKey(KeyCode.Alpha1) && animacion.GetBool("Green") && !animacion.GetBool("Transition"))
            {
                animacion.SetBool("Transition", true);
                changeCounter = changeTimer;
                transitionCounter = transitionTimer;

                //sound.Play();
            }

            if (animacion.GetBool("Red")  && !animacion.GetBool("Green") && animacion.GetBool("Transition") && transitionCounter <= 0)
            {
                shieldManager.ChangeMode();

                animacion.SetBool("Transition", false);
                animacion.SetBool("Red", false);
                animacion.SetBool("Green", true);
                transitionCounter = 0f;
            }

            if (!animacion.GetBool("Red") && animacion.GetBool("Green") && animacion.GetBool("Transition") && transitionCounter <= 0)
            {
                shieldManager.ChangeMode();

                animacion.SetBool("Transition", false);
                animacion.SetBool("Red", true);
                animacion.SetBool("Green", false);
                transitionCounter = 0f;
            }

            //parent.GetComponent<RedShoot>().enabled = animacion.GetBool("redMode");
            //parent.GetComponent<GreenShoot>().enabled = animacion.GetBool("greenMode");
        }
    }

    bool enabledChange()
    {
        return changeCounter <= 0f;
    }
}
