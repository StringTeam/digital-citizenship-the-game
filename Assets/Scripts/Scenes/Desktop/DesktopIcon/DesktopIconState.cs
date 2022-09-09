using UnityEngine;

namespace ST.Scenes.Desktop.DesktopIcon
{
	public class DesktopIconState : FSM.State
	{
		public DesktopIcon ThisIcon;
		protected DesktopIconData Data;

		protected ST.Managers.InputManager  InputManager;

		protected Vector3 CurrentPosition;

		public DesktopIconState(FSM.FSM fsm, DesktopIcon thisIcon, DesktopIconData data) : base(fsm)
		{
			this.ThisIcon = thisIcon;
			this.Data = data;
		}

		public override void Enter()
		{
			base.Enter();

			InputManager = GameObject.FindObjectOfType<ST.Managers.InputManager>();
		}

		public override void Update()
		{
			base.Update();

			CurrentPosition = ThisIcon.transform.position;
		}

		public override void FixedUpdate()
		{
			base.FixedUpdate();
		}

		public override void OnMouseDown()
		{
			base.OnMouseDown();
		}

		public override void OnMouseUp()
		{
			base.OnMouseUp();
		}

		public override void Exit()
		{
			base.Exit();
		}
	}
}
