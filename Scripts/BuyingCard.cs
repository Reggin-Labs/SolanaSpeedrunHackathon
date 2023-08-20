using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Networking;
using Newtonsoft.Json;

public class BuyingCard : MonoBehaviour
{
    // Start is called before the first frame update
    private string paymentLink;
    private string character;
    public GameObject WhitePanel;
    public TMP_Text timer;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreatePaymentTimeout(int index)
    {
        WhitePanel.SetActive(true);
        
        switch(index)
        {
            case 1:
                paymentLink = "https://spherepay.co/pay/paymentLink_93b7d2a5bfff43dcbba3d1779a66e185";
                character = "sandeep";
                break;
            case 2:
                paymentLink = "https://spherepay.co/pay/paymentLink_431d5f5da54f41cebea5fa46931b8293";
                character = "anatoly";
                break;
            case 3:
                paymentLink = "https://spherepay.co/pay/paymentLink_1727d613ebc24ae8b1fa117ef6cafd5d ";
                character = "mertz";
                break;
            case 4:
                paymentLink = "https://spherepay.co/pay/paymentLink_0e36dd44fd584eceaba6777b65a48a5c";
                character = "cl207";
                break;
        }
        StartCoroutine(GetDataWebHook_Coroutine(character));
    }

    IEnumerator GetDataWebHook_Coroutine(string character)
    {

        var counter = 30;
        var secondsToDecrement = 1;
        var dataFetched = false;
        string uri = "https://dotcombackend.me/";

        while (counter >= 0 && !dataFetched)
        {
            timer.text = counter.ToString();
            using (UnityWebRequest request = UnityWebRequest.Get(uri))
            {
                yield return request.SendWebRequest();
                if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
                {
                    Debug.Log(request.error);
                }
                else
                {
                    if (request.downloadHandler.text != "Nothing")
                    {
                        dataFetched = true;
                        StartCoroutine(PostDataMint_Coroutine(character, "5PELFU1W8MRCzAQaMU6ySXCN8F6wy3iXKQMZCJV7QSBe"));
                        WhitePanel.SetActive(false);
                    }
                }
            }

            yield return new WaitForSeconds(secondsToDecrement);
            counter -= secondsToDecrement;
        }
    }

    IEnumerator PostDataMint_Coroutine(string character,string address)
    {
        string uri = "https://dotcombackend.me/mint/"+character+"/"+address;
        Debug.Log(uri);
        using (UnityWebRequest request = new UnityWebRequest(uri, "POST"))
        {
            request.downloadHandler = (DownloadHandler) new DownloadHandlerBuffer();
            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.Log(request.error);
            }
            else
            {
                var responseObject = JsonConvert.DeserializeObject(request.downloadHandler.text);
                Debug.Log(responseObject);
            }
        }
    }

    //IEnumerator 
}
