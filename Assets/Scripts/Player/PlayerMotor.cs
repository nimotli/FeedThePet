using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{

    public GameObject projectile;
    [SerializeField]
    GameObject projectileSpawnPoint;
    [SerializeField]
    float shootCooldown = 2f;
    [SerializeField]
    int throwPower=5,maxDistance=10;
    [SerializeField]
    GameObject arrow;
    GameObject currentProjectile;
    Camera myCam;
    Vector2 originalPosition,targetPosition;
    Animator playerAnim;

    bool canShoot = true;
    // Start is called before the first frame update
    void Start()
    {
        playerAnim = GetComponent<Animator>();
        myCam = Camera.main;
        arrow.SetActive(false);
        currentProjectile = Instantiate(projectile, projectileSpawnPoint.transform);
    }
    private void FixedUpdate()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            originalPosition = myCam.ScreenToWorldPoint(Input.mousePosition);
            arrow.SetActive(true);
        }
        if(Input.GetKey(KeyCode.Mouse0))
        {
            Vector2 tempMousePos= myCam.ScreenToWorldPoint(Input.mousePosition);
            Vector2 direction = tempMousePos - originalPosition;
            //Vector3 newDir = Vector3.RotateTowards(Vector3.forward, direction, 1, 0.0f);
            float angle = Vector2.Angle(Vector2.right, direction);
            arrow.transform.rotation = Quaternion.Euler(0, 0, 180-angle);
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            arrow.SetActive(false);
            targetPosition = myCam.ScreenToWorldPoint(Input.mousePosition);
            throwProjectile();
        }
    }
    public void throwProjectile()
    {
        print("is throwing");
        playerAnim.SetBool("Throwing", true);
        Vector2 direction = originalPosition - targetPosition;
        Vector2 normDirection = normalize(direction);
        float distance = Vector2.Distance(targetPosition, originalPosition);
        if (distance > maxDistance)
            distance = maxDistance;
        Rigidbody2D projectileRig = currentProjectile.GetComponent<Rigidbody2D>();
        //projectileRig.isKinematic = false;
        Vector2 forceVec = normDirection * distance * throwPower*10;
        //projectileRig.AddForce(forceVec);
        Destroy(currentProjectile, 5f);
        canShoot = false;
        Invoke("instantiateNewProjectile",shootCooldown);
        StartCoroutine(throwCR(forceVec, projectileRig));
    }
    IEnumerator throwCR(Vector2 force, Rigidbody2D projectileRig)
    {
        yield return new WaitForSeconds(.55f);
        projectileRig.isKinematic = false;
        projectileRig.gameObject.transform.parent = null;
        projectileRig.AddForce(force);
    }

    void instantiateNewProjectile()
    {
        currentProjectile = Instantiate(projectile, projectileSpawnPoint.transform);
        canShoot = true;
        playerAnim.SetBool("Throwing", false);
    }
    Vector2 normalize(Vector2 vec)
    {
        float sum = Mathf.Pow(vec.x,2) + Mathf.Pow(vec.y, 2);
        float lenght = Mathf.Sqrt(sum);
        return vec / lenght;
    }
}
