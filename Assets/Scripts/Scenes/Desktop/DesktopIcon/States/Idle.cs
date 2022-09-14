using UnityEngine;

namespace ST.Scenes.Desktop.DesktopIcon.State
{
	public class Idle : DesktopIconState
	{
		protected float ClickZone = 0.1f;

		private float _doubleClickZone = 0.35f;
		private bool _click = false;
		private float _clickTime;

		protected Vector3 StartPosition;

		private Managers.LevelManager _levelManager;

		public Idle(FSM.FSM fsm, DesktopIcon thisIcon, DesktopIconData data, Managers.LevelManager lm) : base(fsm, thisIcon, data)
		{
			_levelManager = lm;
		}

		public override void Enter()
		{
			base.Enter();
		}

		public override void Update()
		{
			base.Update();

			if (_click && Time.time > (_clickTime + _doubleClickZone)) {
				// SINGLE CLICK
				Debug.Log("Single Click");
				_click = false;
			}
		}

		public override void FixedUpdate()
		{
			base.FixedUpdate();

			if (Data.DragMouseDown)
			{
				Data.DragMouseDownFor += Time.fixedDeltaTime;
				if (Data.DragMouseDownFor > ClickZone)
				{
					fsm.ChangeState("Dragging");
				}
			}
		}

		public override void OnMouseDown()
		{
			base.OnMouseDown();

			if (_click && Time.time <= (_clickTime + _doubleClickZone)) {
				// DOUBLE CLICK
				Debug.Log("Double Click");

				if (ThisIcon.ToMainMenu) {
					_levelManager.LoadMainMenu();
				} else {
					_levelManager.LoadLevel(ThisIcon.SceneToLoad);
				}

				_click = false;
			} else {
				_click = true;
				_clickTime = Time.time;
			}

			Data.DragMouseDown = true;
			Data.DragMouseDownFor = 0.0f;

			Data.DragStartPosition = CurrentPosition;
		}

		public override void OnMouseUp()
		{
			base.OnMouseUp();

			Data.DragMouseDown = false;
			Data.DragMouseDownFor = 0.0f;
		}

		public override void Exit()
		{
			base.Exit();
		}
	}
}
