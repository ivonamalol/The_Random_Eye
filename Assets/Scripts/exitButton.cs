using UnityEngine;

public class exitButton : MonoBehaviour
{
    // Call this from your UI Button's OnClick event
    public void OnExitButtonClicked()
    {
        Application.Quit();

#if UNITY_EDITOR
        // If running in the Unity Editor, stop play mode
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
