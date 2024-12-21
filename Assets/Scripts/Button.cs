using UnityEngine;
using UnityEngine.SceneManagement;
using static System.Net.Mime.MediaTypeNames;

public class Button : MonoBehaviour
{
    public void LoadStory()  // Story 씬으로 이동
    {
        SceneManager.LoadScene("Story");
    }

    public void Load1stStage()  // 1stStage 씬으로 이동
    {
        SceneManager.LoadScene("1stStage");
    }

    public void LoadStageClear()  // StageClear 씬으로 이동
    {
        SceneManager.LoadScene("StageClear");
    }

    public void GameExit()
    {
        #if UNITY_EDITOR
        // 에디터에서 게임을 종료할 때
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        // 실제 게임을 종료할 때 (이걸로는 유니티에서 게임 종료가 안 됨)
        UnityEngine.Application.Quit();
        #endif
    }
}
