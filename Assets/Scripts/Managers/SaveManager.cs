using UnityEngine;

namespace ST.Managers
{
	/// <summary>
	/// The save manager is used to serialize and deserialize save data. Also keeps track of current save.
	/// </summary>
	public class SaveManager : MonoBehaviour
	{
		public Types.SaveData CurrentSave { get; set; }
		
        private GameManager _gameManager;

        private void Start()
		{
            _gameManager = FindObjectOfType<GameManager>();
			CurrentSave = new();
        }

		/// <summary>
		/// Load a save to CurrentSave
		/// </summary>
		public void LoadSave(string saveKey)
		{
            string jsonData = _gameManager.GetPref(saveKey);
            CurrentSave = JsonUtility.FromJson<Types.SaveData>(jsonData);
		}

		/// <summary>
		/// Save CurrentSave
		/// </summary>
		public void SaveGame(string saveKey)
		{
            string jsonData = JsonUtility.ToJson(CurrentSave);
            _gameManager.SetPref(saveKey, jsonData);
		}
	}
} // namespace ST

