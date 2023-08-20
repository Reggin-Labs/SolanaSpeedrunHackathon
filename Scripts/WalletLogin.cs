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
    public Button goBack;
    public Button cardSelect;
    public static Account account;
    public GameObject AfterConnected;
    public GameObject CardSelection;
    void Start()
    {
        web3 = GameObject.Find("Solana").GetComponent<Web3>();
        loginBtnWalletAdapter.onClick.AddListener(LoginCheckerWalletAdapter);
        goBack.onClick.AddListener(GoBack);
        cardSelect.onClick.AddListener(CardSelect);
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
            AfterConnected.SetActive(true);
        }
        addressField.text = address;
    }

    private void GoBack()
    {
        CardSelection.SetActive(false);
        AfterConnected.SetActive(true);
    }

    private void CardSelect()
    {
        CardSelection.SetActive(true);
        AfterConnected.SetActive(false);
    }
        
}


