using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ST.UI
{
    public class TopBar : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _name, _message, _score;
        [SerializeField] private Color _defaultColor = new(0, 159, 223, 255);

        public static void Show(Color color, string name = null, string message = null, string score = null)
        {
            GameObject go = (GameObject)Instantiate(Resources.Load("Prefabs/TopBar"));
            TopBar topBar = go.GetComponent<TopBar>();
            topBar.Init(color, name, message, score);
        }

        private void Init(Color color, string name, string message, string score)
        {
            if (color == Color.clear)
                color = _defaultColor;

            GetComponentInChildren<Image>().color = color;
            _name.text = name;
            _message.text = message;
            _score.text = score;
        }
    }
}