using UnityEngine;

namespace ST.Scenes.Desktop.DesktopIcon.State
{
	public class Idle : DesktopIconState
	{
		protected float ClickZone = 0.1f;

		protected Vector3 StartPosition;

		public Idle(FSM.FSM fsm, DesktopIcon thisIcon, DesktopIconData data) : base(fsm, thisIcon, data)
		{

		}

		public override void Enter()
		{
			base.Enter();
		}

		public override void Update()
		{
			base.Update();
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
