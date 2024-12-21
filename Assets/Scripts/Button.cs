using UnityEngine;
using UnityEngine.SceneManagement;
using static System.Net.Mime.MediaTypeNames;

public class Button : MonoBehaviour
{
    public void LoadStory()  // Story ������ �̵�
    {
        SceneManager.LoadScene("Story");
    }

    public void Load1stStage()  // 1stStage ������ �̵�
    {
        SceneManager.LoadScene("1stStage");
    }

    public void LoadStageClear()  // StageClear ������ �̵�
    {
        SceneManager.LoadScene("StageClear");
    }

    public void GameExit()
    {
        #if UNITY_EDITOR
        // �����Ϳ��� ������ ������ ��
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        // ���� ������ ������ �� (�̰ɷδ� ����Ƽ���� ���� ���ᰡ �� ��)
        UnityEngine.Application.Quit();
        #endif
    }
}
