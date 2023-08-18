using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Solana.Unity.Wallet;
using Solana.Unity.SDK;

public class WalletLogin : MonoBehaviour
{

    [SerializeField]
    private Button loginBtnWalletAdapter;

    // Start is called before the first frame update
    [SerializeField]
    private TMP_Text addressField;
    void Start()
    {
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
        var account = await Web3.Instance.LoginWalletAdapter();
        string address = account.ToString();
        addressField.text = address;
    }
}


