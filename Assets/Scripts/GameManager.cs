using UnityEngine;
using System.IO;
using UnityEditor.Analytics;

public class GameManager : MonoBehaviour
{
    [SerializeField] static public GameObject body;
    public static int[] unlockedColors = {0,0,0,0,0,0,0};
    public static Vector3 curPos = Vector3.zero;
    public static Quaternion curRot = Quaternion.identity;
    public static string[] selectedColors;

    public void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    #region Save and Load
    public static void Save(ref PlayerSaveData data)
    {

        data.position = curPos;
        data.rotation = curRot;
        data.curScene = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
        data.unlockedColors = unlockedColors;
        data.selectedColors = PlayerMovement.selectedColors;
        Debug.Log(data.selectedColors[1]);
    }

    public static void Load(PlayerSaveData data)
    {
        unlockedColors = data.unlockedColors;
        selectedColors = data.selectedColors;
        curPos = data.position;
        curRot = data.rotation;
        UnityEngine.SceneManagement.SceneManager.LoadScene(data.curScene);
        Menu.justLoaded = true;
    }
    #endregion

    [System.Serializable]
    public struct PlayerSaveData
    {
        public Vector3 position;
        public Quaternion rotation;
        public int[] unlockedColors;
        public string curScene;
        public string[] selectedColors;
    }


    #region Save System
    private static SaveData _saveData = new SaveData();

    [System.Serializable]
    public struct SaveData
    {
        public PlayerSaveData playerData;
    }

    public static string SaveFileName()
    {
        string saveFile = Application.persistentDataPath + "/save" + ".save";
        return saveFile;
    }

    public static void Save()
    {
        HandleSaveData();

        File.WriteAllText(SaveFileName(), JsonUtility.ToJson(_saveData, true));
        Debug.Log("File Saved");
    }

    private static void HandleSaveData()
    {
        Save(ref _saveData.playerData);
    }

    public static void Load()
    {
        if (File.Exists(SaveFileName()))
        {
            string saveJson = File.ReadAllText(SaveFileName());
            _saveData = JsonUtility.FromJson<SaveData>(saveJson);
            HandleLoadData();
        }
        else
        {
            Debug.Log("No save file found");
        }
    }

    private static void HandleLoadData()
    {
        Load(_saveData.playerData);
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    #endregion
}
