using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startButton : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    // This method will be called when the button is clicked
    public void OnStartButtonClicked()
    {
        // Load the next scene (replace 0 with your scene index or name)
        SceneManager.LoadScene("main");
    }

}
