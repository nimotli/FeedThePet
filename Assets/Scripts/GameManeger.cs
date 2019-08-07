using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManeger : MonoBehaviour
{

    public static GameManeger instance;

    List<PetBehaviour> petsInLevel ;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        petsInLevel = new List<PetBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void petFed(PetBehaviour behaviour)
    {

    }
}
