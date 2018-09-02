using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Name
{
	public class OnVisibilityChanged : MonoBehaviour
	{
		// https://www.reddit.com/r/Unity3D/comments/2viipi/isvisible_and_onbecamevisible_issue/
		// https://answers.unity.com/questions/54997/on-can-i-have-onbecamevisibleinvisible-ignore-the.html

		[SerializeField] Camera cam;
		[SerializeField] Renderer renderer;

		public System.Action onBecameVisible;
		public System.Action onBecameInvisible;


		void Start()
		{
			cam = Camera.main;
			renderer = GetComponent<Renderer>();
		}

		void OnBecameInvisible ()
		{
#if UNITY_EDITOR
			if ( cam != null )
			{
				if ( renderer.IsVisibleFrom(cam) == false )
				{
					return;
				}
			}
#endif

			if (onBecameInvisible != null)
			{
				onBecameInvisible.Invoke ();
			}
		}

		void OnBecameVisible ()
		{
#if UNITY_EDITOR
			if ( cam != null )
			{
				if ( renderer.IsVisibleFrom(cam) == false )
				{
					return;
				}
			}
#endif

			if (onBecameVisible != null)
			{
				onBecameVisible.Invoke ();
			}
		}
	}
}