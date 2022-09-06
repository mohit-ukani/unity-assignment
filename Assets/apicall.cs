using System.Collections;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class apicall : MonoBehaviour
{

    public Text placeHolder;
    public AudioSource audioPlayer;
    public Root bodyData;
    public AudioClip audioClip;
    public Dictionary<string,AudioClip> audioClips = new Dictionary<string, AudioClip>();
    public Root1 apiData;


    //api call with the different customre_state param 
    public void callApiWithParam(string customer_state)
    {
        placeHolder.text = "Loading...";
        StartCoroutine(apiCall(customer_state));
    }







    IEnumerator apiCall(string customer_state)
    {
        UnityWebRequest www = UnityWebRequest.Post("https://test.iamdave.ai/conversation/exhibit_aldo/74710c52-42a5-3e65-b1f0-2dc39ebe42c2","");
        www.SetRequestHeader("Content-Type", "application/json");
        www.SetRequestHeader("X-I2CE-USER-ID", "74710c52-42a5-3e65-b1f0-2dc39ebe42c2");
        www.SetRequestHeader("X-I2CE-API-KEY", "NzQ3MTBjNTItNDJhNS0zZTY1LWIxZjAtMmRjMzllYmU0MmMyMTYwNzIyMDY2NiAzNw__");
        www.SetRequestHeader("X-I2CE-ENTERPRISE-ID", "dave_expo");

        bodyData = new Root();
        bodyData.system_response = "sr_init";
        bodyData.engagement_id = "NzQ3MTBjNTItNDJhNS0zZTY1LWIxZjAtMmRjMzllYmU0MmMyZXhoaWJpdF9hbGRv";
        bodyData.customer_state = customer_state;


        byte[] bodyRaw = Encoding.UTF8.GetBytes(JsonUtility.ToJson(bodyData).ToString());
        www.uploadHandler = (UploadHandler)new UploadHandlerRaw(bodyRaw);
        www.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();

        yield return www.SendWebRequest();
        Debug.Log("Status Code: " + www.responseCode + "   " + www.result.ToString());
        apiData = JsonConvert.DeserializeObject<Root1>(www.downloadHandler.text);
        placeHolder.text = apiData.placeholder;
        //avoids fetching audio on every request if it is already fetched
        if (audioClips.ContainsKey(apiData.response_channels.voice))
        {
            audioPlayer.clip = audioClips.GetValueOrDefault(apiData.response_channels.voice);
            audioPlayer.Play();
        }
        else {

            StartCoroutine(GetAudioClip(apiData.response_channels.voice));
        }

    }




    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Root
    {
        public string system_response;
        public string engagement_id;
        public string customer_state;
    }

    //fetch the audio from server and load it to dictionary to cashe
    IEnumerator GetAudioClip(string url)
    {
        UnityWebRequest www = UnityWebRequestMultimedia.GetAudioClip(url, AudioType.WAV);
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.ConnectionError)
            {
                Debug.Log(www.error);
            }
            else
            {
                audioClip = DownloadHandlerAudioClip.GetContent(www);
                if(!audioClips.ContainsKey(url))
                    audioClips.Add(url,audioClip);
                audioPlayer.clip = audioClips.GetValueOrDefault(url);
                audioPlayer.Play();
            }
        }

    }
}