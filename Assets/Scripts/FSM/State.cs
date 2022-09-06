namespace ST.FSM
{
	public class State
	{
		protected readonly FSM fsm; // A state should not be transferred
									// to another FSM on the fly.

		public State(FSM fsm)
		{
			this.fsm = fsm;
		}

		public virtual void Enter() { }

		public virtual void Update() { }

		public virtual void FixedUpdate() { }

		public virtual void OnMouseDown() { }

		public virtual void OnMouseUp() { }

		public virtual void Exit() { }
	}
} // namespace ST.FSM
