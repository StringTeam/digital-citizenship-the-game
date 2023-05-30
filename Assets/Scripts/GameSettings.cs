using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ST
{
    public class GameSettings : MonoBehaviour
    {
        private readonly Dictionary<EPuzzleCategories, string> _puzzleCatDirectory = new Dictionary<EPuzzleCategories, string>();
        private int _settings;
        private const int SettingsNumber = 2;

        public enum EPairNumber
        {
            NotSet = 0,
            E6Pairs = 6,
            E12Pairs = 12,
        }

        public enum EPuzzleCategories
        {
            NotSet,
            PC
        }

        public struct Settings
        {
            public EPairNumber PairsNumber;
            public EPuzzleCategories PuzzleCategory;
        };

        private Settings _gameSettings;

        public static GameSettings Instance;

        void Awake()
        {
            if (Instance == null)
            {
                DontDestroyOnLoad(target: this);
                Instance = this;
            }
            else
            {
                Destroy(obj: this);
            }
        }


        // Start is called before the first frame update
        void Start()
        {
            SetPuzzleCatDirectory();
            _gameSettings = new Settings();
            ResetGameSettings();
        }

        private void SetPuzzleCatDirectory()
        {
            _puzzleCatDirectory.Add(EPuzzleCategories.PC, "PC");
        }

        public void SetPairNumber(EPairNumber Number)
        {
            if ( _gameSettings.PairsNumber == EPairNumber.NotSet)
                _settings++;

            _gameSettings.PairsNumber = Number;
        }

        public void  SetPuzzleCategories(EPuzzleCategories cat)
        {
            if (_gameSettings.PuzzleCategory == EPuzzleCategories.NotSet)
                _settings++;
            _gameSettings.PuzzleCategory = cat;
        }

        public EPairNumber GetPairNumber()
        {
            return _gameSettings.PairsNumber;
        }

        public EPuzzleCategories GetPuzzleCategory()
        {
            return _gameSettings.PuzzleCategory;
        }

        public void ResetGameSettings()
        {
            _settings = 0;
            _gameSettings.PuzzleCategory = EPuzzleCategories.NotSet;
            _gameSettings.PairsNumber = EPairNumber.NotSet;
        }

        public bool AllSettingsReady()
        {
            return _settings == SettingsNumber;
        }

        public string GetMaterialDirectoryName()
        {
            return "Materials/";
        }

        public string GetPuzzleCategoryTextureDirectoryName()
        {
            if(_puzzleCatDirectory.ContainsKey(_gameSettings.PuzzleCategory))
            {
                return "Graphics/PuzzleCat/" + _puzzleCatDirectory[_gameSettings.PuzzleCategory] + "/";
            }
            else
            {
                Debug.LogError("Error Cannot Get Directory Name");
                return "";
            }
        }
    }
}
