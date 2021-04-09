using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// Class for handling the main menu scene buttons
/// </summary>
public class MainMenu : MonoBehaviour
{
  /// <summary>
  /// Method that loads the next scene in the build. The main menu scene has the index of 0 and the game demo has the 1, this is why buildIndex +1
  /// </summary>
  public void StartGame()
  {
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
  }

  /// <summary>
  /// Quit game method, to exit the application after the game is built
  /// </summary>
  public void QuitGame()
  {
    Application.Quit();
  }
}
