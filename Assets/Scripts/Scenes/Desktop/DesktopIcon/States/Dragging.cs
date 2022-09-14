using UnityEngine;

namespace ST.Scenes.Desktop.DesktopIcon.State
{
	public class Dragging : DesktopIconState
	{
		private float _dragSpeed = 0.75f;

		public Dragging(FSM.FSM fsm, DesktopIcon thisIcon, DesktopIconData data) : base(fsm, thisIcon, data)
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

			Vector3 mousePos = InputManager.RawMousePositionInput;

			Vector3 newPosition = Vector3.Lerp(CurrentPosition, Camera.main.ScreenToWorldPoint(mousePos), _dragSpeed);

			newPosition.z = -5.0f;
			ThisIcon.transform.position = newPosition;
		}

		public override void OnMouseDown()
		{
			base.OnMouseDown();
		}

		public override void OnMouseUp()
		{
			base.OnMouseUp();

			Data.DragMouseDown = false;
			Data.DragMouseDownFor = 0.0f;

			Vector3 mousePosInWorld = Camera.main.ScreenToWorldPoint(InputManager.RawMousePositionInput);

			ThisIcon.transform.position = new Vector3(SnapToGrid(mousePosInWorld.x), SnapToGrid(mousePosInWorld.y), 0.0f);
			fsm.ChangeState("Idle");
		}

		float SnapToGrid(float pos)
		{
			float gridSize = 1.0f;
			float xDiff = pos % gridSize;
			pos -= xDiff;
			if (xDiff > (gridSize / 2))
			{
				pos += gridSize;
			}
			return pos;
		}

		public override void Exit()
		{
			base.Exit();
		}
	}
}
