using UnityEngine;
using UnityEngine.SceneManagement;

public class BootstrapPassageway : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //������-�������� ��� ���������. � ���������, ���� ������ �������� :)
        SceneManager.LoadScene(1);
    }

}
