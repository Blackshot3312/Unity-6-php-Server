using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.Networking;

public class Game : MonoBehaviour
{
    public TMP_Text playerDisplay;
    public TMP_Text scoreDisplay;

    private void Awake()
    {
        if (DBManager.username == null)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }

        playerDisplay.text = $"Player: {DBManager.username}";
        scoreDisplay.text = $"Score: {DBManager.score}";
    }

    public void CallSaveData()
    {
        StartCoroutine(SavePlayerGame());
    }

    IEnumerator SavePlayerGame()
    {
        WWWForm form = new WWWForm();
        form.AddField("name", DBManager.username);
        form.AddField("score", DBManager.score);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/sqlconnect/savedata.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log($"Failed to save game, error: {www.error}");
            }
            else
            {
                if (www.downloadHandler.text == "0")
                {
                    Debug.Log("Game successfully saved to the cloud");
                }
                else
                {
                    Debug.Log($"Failed to save game, error: {www.downloadHandler.text}");
                }
            }
        }

        DBManager.LogOut();
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

    public void IncreaseScore() // Corrected method name
    {
        DBManager.score++;
        scoreDisplay.text = $"Score: {DBManager.score}";
    }
}
