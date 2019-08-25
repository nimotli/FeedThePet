using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    public static PlayerMotor instance;
    GameManeger gameManager;
    [SerializeField]
    AudioClip throwAudio, tightenAudio;
    [SerializeField]
    GameObject projectileSpawnPoint;
    [SerializeField]
    float shootCooldown = 3f;
    [SerializeField]
    int throwPower=5,maxDistance=10;
    [SerializeField]
    GameObject arrow;
    [SerializeField]
    GameObject projectile;
    [SerializeField]
    Cinemachine.CinemachineVirtualCamera dynamicVcam;
    AudioSource source;

    Camera myCam;
    Vector2 originalPosition,targetPosition;
    Animator playerAnim;
    LineRenderer line;
    bool canShoot = true;

    GameObject currentProjectile;

    public GameObject getCurrentProjectile()
    {
        return currentProjectile;
    }

    public void setCurrentProjectile(GameObject projectile)
    {
        currentProjectile = projectile;
    }
    private void Awake()
    {
        if(instance==null)
        {
            instance = this;
        }
        gameManager = GameManeger.instance;
    }
    void Start()
    {
        line = GetComponent<LineRenderer>();
        playerAnim = GetComponent<Animator>();
        source = GetComponent<AudioSource>();
        myCam = Camera.main;
        arrow.SetActive(false);
        line.enabled = false;
        instantiateNewProjectile();
        dynamicVcam.Follow = currentProjectile.transform;
        GameEvents.instance.onChangeProjectile+=destroyCurrentProjectile;
        GameEvents.instance.onThrowing += throwProjectile;
        GameEvents.instance.onThrowing += cantThrow;
        GameEvents.instance.onThrowFinished += canThrow;
        //setCurrentProjectile(Instantiate(projectile, projectileSpawnPoint.transform));
    }
    private void FixedUpdate()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0) && canShoot)
        {
            source.clip = tightenAudio;
            source.loop = true;
            source.Play();
            line.enabled = true;
            originalPosition = myCam.ScreenToWorldPoint(Input.mousePosition);
            arrow.SetActive(true);
            line.SetPosition(0, originalPosition);
        }
        if(Input.GetKey(KeyCode.Mouse0) && canShoot)
        {
            
            Vector2 tempMousePos= myCam.ScreenToWorldPoint(Input.mousePosition);
            Vector2 direction = tempMousePos - originalPosition;
            //Vector3 newDir = Vector3.RotateTowards(Vector3.forward, direction, 1, 0.0f);
            float angle = Vector2.Angle(Vector2.right, direction);
            arrow.transform.rotation = Quaternion.Euler(0, 0, 180-angle);
            line.SetPosition(1, tempMousePos);
        }
        if (Input.GetKeyUp(KeyCode.Mouse0) && canShoot)
        {
            source.loop = false;
            source.Stop();
            line.SetPosition(0, Vector3.zero);
            line.SetPosition(0, Vector3.zero);
            arrow.SetActive(false);
            targetPosition = myCam.ScreenToWorldPoint(Input.mousePosition);
            GameEvents.instance.throwing();
            line.enabled = false;
        }
    }
    public void throwProjectile()
    {
        print("is throwing");
        Vector2 direction = originalPosition - targetPosition;
        Vector2 normDirection = normalize(direction);
        float distance = Vector2.Distance(targetPosition, originalPosition);
        if (distance > maxDistance)
            distance = maxDistance;
        Rigidbody2D projectileRig = getCurrentProjectile().GetComponent<Rigidbody2D>();
        //projectileRig.isKinematic = false;
        Vector2 forceVec = normDirection * distance * throwPower*10;
        //projectileRig.AddForce(forceVec);
        canShoot = false;
        if (float.IsNaN(forceVec.x) || float.IsNaN(forceVec.y))
            return;
        playerAnim.SetBool("Throwing", true);
        StartCoroutine(changeProjectile());
        Invoke("instantiateNewProjectile",shootCooldown);
        StartCoroutine(throwCR(forceVec, projectileRig));
    }
    void destroyCurrentProjectile()
    {

        
    }
    IEnumerator throwCR(Vector2 force, Rigidbody2D projectileRig)
    {
        yield return new WaitForSeconds(.55f);
        projectileRig.isKinematic = false;
        projectileRig.gameObject.transform.parent = null;
        
        print(force);
        projectileRig.AddForce(force);
        source.clip = throwAudio;
        source.Play();
    }

    public void refreshProjectileData(SOProjectile projectile)
    {
        getCurrentProjectile().GetComponent<ProjectileController>().setProjectileData(projectile);
    }
    void instantiateNewProjectile()
    {
        projectile.GetComponent<ProjectileController>().setProjectileData(gameManager.currentProjectile);
        setCurrentProjectile(Instantiate(projectile, projectileSpawnPoint.transform));
        playerAnim.SetBool("Throwing", false);
    }
    Vector2 normalize(Vector2 vec)
    {
        float sum = Mathf.Pow(vec.x,2) + Mathf.Pow(vec.y, 2);
        float lenght = Mathf.Sqrt(sum);
        return vec / lenght;
    }
    IEnumerator changeProjectile()
    {
        Destroy(getCurrentProjectile(),5);
        yield return new WaitForSeconds(4f);
        dynamicVcam.Follow = currentProjectile.transform;
        GameEvents.instance.throwFinish();
    }
    void canThrow()
    {
        canShoot = true;
    }
    void cantThrow()
    {
        canShoot = false;
    }
}
