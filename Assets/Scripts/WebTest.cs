using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class WebTest : MonoBehaviour
{
    IEnumerator Start()
    {
        using (UnityWebRequest request = UnityWebRequest.Get("http://localhost/sqlconnect/webtest.php"))
        {
            yield return request.SendWebRequest();

            if (request.result != UnityWebRequest.Result.Success)
            {
                Debug.Log($"Request failed, error: {request.error}");
            }
            else
            {
                Debug.Log(request.downloadHandler.text);
            }
        }
    }
}

