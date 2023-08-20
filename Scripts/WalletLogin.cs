using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Solana.Unity.Wallet;
using Solana.Unity.SDK;

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
    public GameObject MainMenu;
    public GameObject MarketPlace;
    public GameObject CardSelection;
    void Start()
    {
        web3 = GameObject.Find("Solana").GetComponent<Web3>();
        loginBtnWalletAdapter.onClick.AddListener(LoginCheckerWalletAdapter);
        goBackFromCardSelect.onClick.AddListener(GoBack);
        goBackFromMarketPlace.onClick.AddListener(GoBackFromMarketPlace);
        cardSelect.onClick.AddListener(CardSelect);
        marketPlace.onClick.AddListener(GoMarketPlace);

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
        
}


