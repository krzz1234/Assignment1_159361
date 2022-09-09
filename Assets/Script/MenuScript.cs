using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
   public void PlayButton() {
    SceneManager.LoadScene("InGameScene",LoadSceneMode.Single);
   } 

   public void HowToPlayButton() {
      SceneManager.LoadScene("HowToPlayScene",LoadSceneMode.Single);
   }

   public void BackButton() {
      SceneManager.LoadScene("MenuScene",LoadSceneMode.Single);
   }

   public void AddedFeaturesButton(){
      SceneManager.LoadScene("AddedFeaturesScene",LoadSceneMode.Single);
   }
}
