using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Solana.Unity.Wallet;
using Solana.Unity.SDK;

public class WalletLogin : MonoBehaviour
{

    Web3 web3;
    public TMP_InputField addressField;
    public Button loginBtnWalletAdapter;
    void Start()
    {
        web3 = GameObject.Find("Solana").GetComponent<Web3>();
        loginBtnWalletAdapter.onClick.AddListener(LoginCheckerWalletAdapter);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private async void LoginCheckerWalletAdapter()
    {
        Debug.Log("Hello");
        //if (Web3.Instance == null) return;
        Debug.Log("Here");
        var account = await web3.LoginWalletAdapter();
        string address = account.ToString();
        addressField.text = address;
    }
}


