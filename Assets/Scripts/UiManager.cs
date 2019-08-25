using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public static UiManager instance;
    [SerializeField]
    Text projectileText;
    [SerializeField]
    Image projectileImage;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void RefreshUi(SOProjectile projectile,int number)
    {
        projectileText.text = $"{number} {projectile.projectileName} left";
        projectileImage.sprite = projectile.projectileArt;
    }
}
