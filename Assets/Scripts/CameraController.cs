using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    float refreshRate = .1f,moveSpeed=.1f;
    [SerializeField]
    Vector3 offset;
    Transform target;
    PlayerMotor player;
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerMotor>();
        //Invoke("initializeTarget", 1f);
    }

    void Update()
    {
        
    }

    void initializeTarget()
    {
        target = player.getCurrentProjectile().transform;
        StartCoroutine(moveToTarget());
    }

    IEnumerator moveToTarget()
    {
        while(true)
        {
            if(target != null)
            {
                Vector3 targetPos = target.position + offset;
                transform.position = Vector3.Lerp(transform.position, targetPos, moveSpeed);
                yield return new WaitForSeconds(refreshRate);
            }
            else
            {
                if(player.getCurrentProjectile()!=null)
                {
                    target = player.getCurrentProjectile().transform;
                }
            }
        }
    }
}
