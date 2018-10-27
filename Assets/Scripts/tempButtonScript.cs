using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tempButtonScript : MonoBehaviour {

	public void nextLevel()
    {
        Managers.GameManager.Instance.getSceneManager().loadNextLevel();
        Managers.GameManager.Instance.getSceneManager().unloadLastLevel();
    }
    public void endGame()
    {
        Managers.GameManager.Instance.getSceneManager().loadWinScreen();
    }
    public void shop()
    {
        Managers.GameManager.Instance.getSceneManager().loadShop();
    }
    public void unshop()
    {
        Managers.GameManager.Instance.getSceneManager().unloadShop();
    }
}
