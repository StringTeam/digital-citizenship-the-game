using System.Collections.Generic;

namespace ST.FSM
{
	public class FSM
	{
		private Dictionary<string, State> _states = new Dictionary<string, State>();
		private State _currentState;

		public State GetCurrentState()
		{
			return _currentState;
		}

		public State GetState(string stateKey)
		{
			return _states[stateKey];
		}

		public void AddState(string stateKey, State state)
		{
			// 'state' should already be initialized with this FSM instance passed into it.
			_states.Add(stateKey, state);
		}

		public void ChangeState(string stateKey)
		{
			if (_currentState != null)
			{
				_currentState.Exit();
			}

			_currentState = _states[stateKey];

			if (_currentState != null)
			{
				_currentState.Enter();
			}
		}

		public void Update()
		{
			if (_currentState != null)
			{
				_currentState.Update();
			}
		}

		public void FixedUpdate()
		{
			if (_currentState != null)
			{
				_currentState.FixedUpdate();
			}
		}

		public void OnMouseDown()
		{
			if (_currentState != null)
			{
				_currentState.OnMouseDown();
			}
		}

		public void OnMouseUp()
		{
			if (_currentState != null)
			{
				_currentState.OnMouseUp();
			}
		}
	}
}

