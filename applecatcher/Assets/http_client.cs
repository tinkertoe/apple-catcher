using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using Bolt;

public class http_client : MonoBehaviour {
    void Start() {
        StartCoroutine(GetVersion());
    }

    IEnumerator GetVersion() {
        UnityWebRequest www = UnityWebRequest.Get("http://files.tinkertoe.net/applecatcher/version.txt");
        yield return www.SendWebRequest();

        if(www.isNetworkError || www.isHttpError) {
            Debug.Log("http error(http://files.tinkertoe.net/applecatcher/version.txt)");
        }
        else {
            // Show results as text
            Variables.Application.Set("latest_version", www.downloadHandler.text);

            // Or retrieve results as binary data
        }
    }
}
