using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Gamescenemanager : MonoBehaviour
{
    public void Reloadlevel()
    {
        StartCoroutine(NewLevelroutine());
    }
    IEnumerator NewLevelroutine()
    {
        yield return new WaitForSeconds(1f);
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

}
