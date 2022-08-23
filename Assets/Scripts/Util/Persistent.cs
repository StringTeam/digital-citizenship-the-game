using UnityEngine;

namespace ST.Util
{
	/// <summary>	
	/// Make an object persist between scenes
	/// </summary>
	public class Persistent : MonoBehaviour
	{
		void Start()
		{
			DontDestroyOnLoad(this.gameObject);
		}
	}
} // namespace ST.Util
