using UnityEngine;
using UnityEngine.SceneManagement;

public static class Loader
{
   
   public enum Scene
   {
      MainMenu,
      Levels,
      LoadinScene,
      CharacterSelection
   }
   private static Scene targetScene;

   public static void Load(Scene targetScene)
   {
      Loader.targetScene = targetScene;
      SceneManager.LoadScene(Scene.LoadinScene.ToString());
      
      
      
   }

   public static void LoaderCallback()
   {
      SceneManager.LoadScene(targetScene.ToString());
   }
}
