using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserPrefManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetHero() 
    {
        PlayerPrefs.SetString("Hero", gameObject.name);
    }
    public void SetBuilding()
    {
        PlayerPrefs.SetString("Building", gameObject.name);
    }

    public void SetUser()
    {
        PlayerPrefs.SetString("User", gameObject.name);
    }

    public void SetDeveloper()
    {
        PlayerPrefs.SetString("Developer", gameObject.name);
    }
}
