using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChapterSelect : MonoBehaviour
{
   
   public void OpenLevel(string levelName)
   {
        SceneManager.LoadScene(levelName);
   }
}
