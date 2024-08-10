using UnityEditor;
using UnityEngine;

public class HighScoreResetter
{
    [MenuItem("Window/Reset High Score")]
    public static void ResetHighScore()
    {
        PlayerPrefs.DeleteKey("HighScore");
        Debug.Log("High Score has been reset to 0.");
    }
}
