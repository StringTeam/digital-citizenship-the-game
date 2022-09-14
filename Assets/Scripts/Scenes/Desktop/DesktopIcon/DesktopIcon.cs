using UnityEngine;

namespace ST.Scenes.Desktop.DesktopIcon
{
	public class DesktopIcon : MonoBehaviour
	{
		[SerializeField] public string SceneToLoad = "";
		[SerializeField] public bool ToMainMenu = false;

		[HideInInspector] public DesktopIconData Data = new DesktopIconData();

		private FSM.FSM _fsm = new FSM.FSM();

		private Managers.LevelManager _levelManager;

		private void Awake()
		{
			_levelManager = FindObjectOfType<Managers.LevelManager>();

			InitStates();
		}

		private void Start()
		{
			ChangeState("Idle");
		}

		private void Update()
		{
			_fsm.Update();
		}

		private void FixedUpdate()
		{
			_fsm.FixedUpdate();
		}

		private void OnMouseDown()
		{
			_fsm.OnMouseDown();
		}

		private void OnMouseUp()
		{
			_fsm.OnMouseUp();
		}

		public void ChangeState(string newState)
		{
			Debug.LogFormat("Changed state to: {0}", newState);
			_fsm.ChangeState(newState);
		}

		private void InitStates()
		{
			_fsm.AddState("Idle", new State.Idle(this._fsm, this, this.Data, _levelManager));
			_fsm.AddState("Dragging", new State.Dragging(this._fsm, this, this.Data));
		}
	}
}
