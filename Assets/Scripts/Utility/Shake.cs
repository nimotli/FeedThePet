using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake : MonoBehaviour
{
    [SerializeField]
    float maxRotation = 5f;
    [SerializeField]
    float rotationStep = .2f;
    [SerializeField]
    float shakeCD = .1f;
    public bool adding = true;
    RectTransform rect;
    // Start is called before the first frame update
    void Start()
    {
        rect = gameObject.GetComponent<RectTransform>();
        StartCoroutine(shake());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator shake()
    {
        while(true)
        {
            if(adding)
            {
                if (rect.eulerAngles.z < maxRotation || rect.eulerAngles.z>300) 
                {
                    rect.Rotate(new Vector3(0, 0, rotationStep));
                }
                else
                {
                    adding = false;
                }
            }
            else
            {
                if (rect.eulerAngles.z < 360-maxRotation)
                {
                    rect.Rotate(new Vector3(0, 0, -rotationStep));
                }
                else
                {
                    adding = true;
                }
            }
            yield return new WaitForSeconds(shakeCD);
        }
    }
}
