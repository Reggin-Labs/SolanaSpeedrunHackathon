using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Solana.Unity.Wallet;
using Solana.Unity.SDK;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;


public class WalletLogin : MonoBehaviour
{

    Web3 web3;
    public TMP_Text addressField;
    public Button loginBtnWalletAdapter;
    public Button goBackFromCardSelect;
    public Button goBackFromMarketPlace;
    public Button cardSelect;
    public Button marketPlace;
    public static Account account;
    public List<string> assets;
    public GameObject MainMenu;
    public GameObject MarketPlace;
    public GameObject CardSelection;
    public GameObject[] mintbutton;
    public GameObject[] selectCards;
    public TMP_Text[] text;
    void Start()
    {
        web3 = GameObject.Find("Solana").GetComponent<Web3>();
        loginBtnWalletAdapter.onClick.AddListener(LoginCheckerWalletAdapter);
        goBackFromCardSelect.onClick.AddListener(GoBack);
        goBackFromMarketPlace.onClick.AddListener(GoBackFromMarketPlace);
        cardSelect.onClick.AddListener(CardSelect);
        marketPlace.onClick.AddListener(GoMarketPlace);
        StartCoroutine(SetButtons_Coroutine());
    }

    // Update is called once per frame
    void Update()
    {

    }

    private async void LoginCheckerWalletAdapter()
    {
        //if (Web3.Instance == null) return;
        account = await web3.LoginWalletAdapter();
        string address = account.ToString();
        if (account != null)
        {
            MainMenu.SetActive(true);
        }
        addressField.text = address;
    }

    private void GoBack()
    {
        CardSelection.SetActive(false);
        MainMenu.SetActive(true);
    }

    private void GoBackFromMarketPlace()
    {
        MarketPlace.SetActive(false);
        MainMenu.SetActive(true);
    }

    private void CardSelect()
    {
        CardSelection.SetActive(true);
        MainMenu.SetActive(false);
    }

    private void GoMarketPlace() 
    {
        MarketPlace.SetActive(true);
        MainMenu.SetActive(false);
    }

    IEnumerator GetNFTData_Coroutine(string address)
    {
        string uri = "https://dotcombackend.me/assets/" + address;

        using (UnityWebRequest request = UnityWebRequest.Get(uri))
        {
            request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
            yield return request.SendWebRequest();
            if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.Log(request.error);
            }
            else
            {
                if (request.downloadHandler.text != "Nothing")
                {
                    NFTData[] nftData = JsonConvert.DeserializeObject<NFTData[]>(request.downloadHandler.text);
                    foreach(NFTData data in nftData)
                    {
                        assets.Add(data.metadata.name);
                        Debug.Log(data.metadata.name);
                    }
                    
                }
            }
        }
    }

    IEnumerator SetButtons_Coroutine()
    {
        yield return StartCoroutine(GetNFTData_Coroutine("3x8Be1JczaNTAeVmWzsqyrnaQHS6PL9v61MQqpaZc66Q"));
       
        foreach (GameObject obj in mintbutton)
        {
            foreach (string name in assets)
            {
                
                if (name == obj.name)
                {
                    obj.GetComponentInChildren<Button>().interactable = false;
                    Button btn = obj.GetComponentInChildren<Button>();
                    text = btn.GetComponentsInChildren<TMP_Text>();
                    Debug.Log(text);
                    foreach (TMP_Text txt in text)
                    {
                        if (txt.name == "Mint")
                            txt.text="Unlocked";
                    }
                }
            }
        }
        foreach (GameObject obj in selectCards)
        {
            foreach(string name in assets)
            {
                if(name!=obj.name)
                {
                    //obj.GetComponentInChildren<Button>().interactable = false;
                    
                   obj.transform.GetChild(0).gameObject.SetActive(false);
                    
                }
            }
        }
    }
}


