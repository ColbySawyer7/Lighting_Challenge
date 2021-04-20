using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChairController : MonoBehaviour
{
    public float riseSpeed = 1.0f;
    public float shakeSpeed = 1.0f;
    public float shakeSize = 1.0f;
    public float maxHeight;
    public float chairDelay;
    public float flashlightDelay;
    public Light overheadLight;
    public Light flashlight;
    public Color scareColor;
    public GameObject toy;
    private float minHeight = -0.34f;
    private float riseTime = 1.0f;
    private bool sceneComplete = false;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("rotateChair",chairDelay, shakeSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < maxHeight && !sceneComplete){
            transform.Translate(Vector3.up * Time.deltaTime * riseSpeed);
            rotateChair();
        }else{
            endScare();
        }

    }

    void rotateChair(){
        gameObject.transform.Rotate(0, shakeSize * Time.deltaTime, 0);
    }

    void endScare(){
        overheadLight.enabled = false;
        flashlight.enabled = false;
        flashlight.color = scareColor;
        toy.SetActive(true);
        gameObject.SetActive(false);
        flashlight.enabled = true;
        sceneComplete = true;

    }

}
