using System.Collections;
using System.Text;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Networking;
using Newtonsoft.Json;


public class GetMethod : MonoBehaviour
{
 
 TMP_InputField outputArea;

 void Start()
 {
    outputArea=GameObject.Find("OutputArea").GetComponent<TMP_InputField>();
    GameObject.Find("GetButton").GetComponent<Button>().onClick.AddListener(GetData);
    GameObject.Find("PostButton").GetComponent<Button>().onClick.AddListener(PostData);
 }

 public void GetData() => StartCoroutine(GetData_Coroutine());
 public void PostData() => StartCoroutine(PostData_Coroutine());

 IEnumerator GetData_Coroutine()
 {
    outputArea.text="Loading...";
    string uri="https://api.spherepay.co/v1/customer/customer_b88c1ccc279f45a4b966208f22550c77";

    using(UnityWebRequest request=UnityWebRequest.Get(uri))
    {
        request.SetRequestHeader("authorization","Bearer secret_a572c36ac4e44a55b5ea80bf8cca9fce");
        yield return request.SendWebRequest();
        if(request.result==UnityWebRequest.Result.ConnectionError || request.result==UnityWebRequest.Result.ProtocolError){
            outputArea.text=request.error;
        }
        else
        {
            outputArea.text=request.downloadHandler.text;
        }
    }

 }

 IEnumerator PostData_Coroutine()
 {
    CustomerObject customerObject= new CustomerObject()
    {
        solanaPubKey= "8JFTv1FHAqEgupBxHmkzDwtRGtPojCQ48yxE3HXGVN2i",
        personalInfo=new PersonalInfo()
        {
            id= "personalInfo_c5af4d6f15c944d4a3e625808ecda9d8",
            email= "john.smith@gmail.com",
            firstName= "John",
            lastName= "Smith",
            phoneNumber= "+242-152-1512",
            addressPersonalInfo= new AddressPersonalInfo() 
            {
                id= "address_81a0c5657f1f459fa8d848975ba4350c",
                line1= "1 Hacker Way",
                line2= "Building 32 Suite D",
                city= "Menlo Park",
                postalCode= "94025",
                state= "California",
                country= "US",
                updated= "2021-01-01T00:00:00.000Z",
                created= "2021-01-01T00:00:00.000Z"
            },
            discord= "JohnSmith",
            twitter= "@JohnSmith",
            telegram= "@JohnSmith"
        },
        address=new Address()
        {
            line1= "1 Hacker Way",
            line2= "Building 32 Suite D",
            city= "Menlo Park",
            postalCode= "94025",
            state= "California",
            country= "US"
        }
    };
    var body= JsonConvert.SerializeObject(customerObject);
    var bytes =Encoding.UTF8.GetBytes(body);
    Debug.Log(bytes);

    outputArea.text="Loading to post....";
    string uri="https://api.spherepay.co/v1/customer";

    using(UnityWebRequest request= new UnityWebRequest(uri,"POST"))
    {
        request.uploadHandler = (UploadHandler) new UploadHandlerRaw(bytes);
        request.downloadHandler = (DownloadHandler) new DownloadHandlerBuffer();
        request.SetRequestHeader("authorization","Bearer secret_a572c36ac4e44a55b5ea80bf8cca9fce");
        request.SetRequestHeader("Content-Type", "application/json");
        request.SetRequestHeader("Accept", "application/json");
        yield return request.SendWebRequest();

        if(request.result==UnityWebRequest.Result.ConnectionError || request.result==UnityWebRequest.Result.ProtocolError){
            Debug.Log(request.error);
        }
        else
        {
            var responseObject=JsonConvert.DeserializeObject(request.downloadHandler.text);
            Debug.Log(responseObject);
        }
    }

 }

}
