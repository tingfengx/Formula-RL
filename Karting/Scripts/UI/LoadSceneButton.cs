using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;


namespace KartGame.UI
{
    public class LoadSceneButton : MonoBehaviour
    {
        [Tooltip("What is the name of the scene we want to load when clicking the button?")]
        public string SceneName;

        public void LoadTargetScene() 
        {
            string[] paths = ModelFileManager.GetPaths();
            for (int i = 0; i < paths.Length; i++)
            {
                if(String.IsNullOrEmpty(paths[i]))
                {

                    bool decision = EditorUtility.DisplayDialog(
                        "Model not imported", // title
                        "Please select the model from the disk", // description
                        "OK" // OK button
                        // "Cancel" // Cancel button
                    );

                    return; 
                }
            }

            SceneManager.LoadSceneAsync(SceneName);
        }
    }
}
