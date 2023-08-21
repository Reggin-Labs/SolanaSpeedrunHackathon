using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UserPrefManager : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI[] heroText;
    public TextMeshProUGUI[] buildingText;
    public TextMeshProUGUI[] developerText;
    public TextMeshProUGUI[] userText;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach(TextMeshProUGUI txt in heroText)
        {
            string name = txt.transform.parent.transform.parent.gameObject.name;
            if(name==PlayerPrefs.GetString("Hero","Vitalik Buterin"))
            {
                txt.text="Selected";
            }
            else
            {
                txt.text = "Select";
            }
        }

        foreach(TextMeshProUGUI txt in buildingText)
        {
            string name = txt.transform.parent.transform.parent.gameObject.name;
            if (name == PlayerPrefs.GetString("Building", "Ethereum Building"))
            {
                txt.text = "Selected";
            }
            else
            {
                txt.text = "Select";
            }
        }

        foreach (TextMeshProUGUI txt in developerText)
        {
            string name = txt.transform.parent.transform.parent.gameObject.name;
            if (name == PlayerPrefs.GetString("Developer", "Ethereum Developer"))
            {
                txt.text = "Selected";
            }
            else
            {
                txt.text = "Select";
            }
        }

        foreach (TextMeshProUGUI txt in userText)
        {
            string name = txt.transform.parent.transform.parent.gameObject.name;
            if (name == PlayerPrefs.GetString("User", "Ethereum User"))
            {
                txt.text = "Selected";
            }
            else
            {
                txt.text = "Select";
            }
        }
    }

    public void SetHero(string name) 
    {
        PlayerPrefs.SetString("Hero", name);
    }
    public void SetBuilding(string name)
    {
        PlayerPrefs.SetString("Building", name);
    }

    public void SetUser(string name)
    {
        PlayerPrefs.SetString("User", name);
    }

    public void SetDeveloper(string name)
    {
        PlayerPrefs.SetString("Developer", name);
    }
}
