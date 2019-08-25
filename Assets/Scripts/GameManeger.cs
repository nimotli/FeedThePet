using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManeger : MonoBehaviour
{

    public static GameManeger instance;
    AudioSource source;
    List<PetBehaviour> petsInLevel ;
    [SerializeField]
    SOSoundEffectCollection sounds;
    [SerializeField]
    List<SOProjectilesInLevel> levelProjectilesData = new List<SOProjectilesInLevel>();


    Dictionary<SOProjectile, int> levelProjectiles = new Dictionary<SOProjectile, int>();
    List<SOProjectile> projectileTypes = new List<SOProjectile>();
    public SOProjectile currentProjectile;
    public int currentIndex = 0;

    Dictionary<string, AudioClip> soundsDic = new Dictionary<string, AudioClip>();

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        initializeProjectileDict();
    }
    void Start()
    {
        source = GetComponent<AudioSource>();
        petsInLevel = new List<PetBehaviour>();
        GameEvents.instance.onSwitchEvent += nextProjectile;
        GameEvents.instance.onRefreshUi += refreshUI;
        GameEvents.instance.onThrowing += thrown;
        GameEvents.instance.onFailed += failed;
        GameEvents.instance.refreshUi();
    }

    void initializeSoundDictionary()
    {
        for (int i = 0; i < sounds.sounds.Count; i++) 
        {
            soundsDic.Add(sounds.sounds[i].seName, sounds.sounds[i].audio);
        }
    }
    void initializeProjectileDict()
    {
        for (int i = 0; i < levelProjectilesData.Count; i++)
        {
            levelProjectiles.Add(levelProjectilesData[i].projectile, levelProjectilesData[i].number);
            projectileTypes.Add(levelProjectilesData[i].projectile);
        }
        currentProjectile = projectileTypes[0];
        currentIndex++;
    }
    public void nextProjectile()
    {
        bool switched = false;
        int iterations = 0;
        while(!switched || iterations> levelProjectilesData.Count)
        {
                
            if (currentIndex >= projectileTypes.Count)
            {
                currentIndex = 0;
            }
            if (levelProjectiles[projectileTypes[currentIndex]] > 0)
            {
                currentProjectile = projectileTypes[currentIndex];
                switched = true;
            }
            currentIndex++;
            iterations++;
            print("iteration " + iterations);
            if (iterations > 100)
                break;
        }
        //PlayerMotor.instance.refreshProjectileData(currentProjectile);
        if (!switched)
            GameEvents.instance.failed();
        PlayerMotor.instance.getCurrentProjectile().GetComponent<ProjectileController>().setProjectileData(currentProjectile);
        UiManager.instance.RefreshUi(currentProjectile, levelProjectiles[currentProjectile]);
    }
    void refreshUI()
    {
        UiManager.instance.RefreshUi(currentProjectile, levelProjectiles[currentProjectile]);
    }

    public void petFed(PetBehaviour behaviour)
    {

    }
    void thrown()
    {
        if (levelProjectiles[currentProjectile] >= 1)
            levelProjectiles[currentProjectile]--;
        else
            GameEvents.instance.switchEvent();
        GameEvents.instance.refreshUi();
    }
    void failed()
    {
        SceneManager.LoadScene(0);
    }
}
