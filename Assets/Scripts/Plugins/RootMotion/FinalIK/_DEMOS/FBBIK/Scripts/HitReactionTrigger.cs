using UnityEngine;
using System.Collections;
using RootMotion.FinalIK;

namespace RootMotion.Demos {

	/// <summary>
	/// Triggering Hit Reactions on mouse button.
	/// </summary>
	public class HitReactionTrigger: MonoBehaviour {

		[SerializeField] HitReaction hitReaction;
		[SerializeField] float hitForce = 1f;

		private string colliderName;

		void Update()
		{
			// On left mouse button...
			//	Ray ray = new Ray(GameObject.Find("PointRH").transform,Vector3.forward);

				// Raycast to find a ragdoll collider
				RaycastHit hit = new RaycastHit();
			if (Physics.CheckSphere(GameObject.Find("PointRH").transform.position, 0))
				//if (Physics.Raycast(ray, out hit, 100f)) 
			{

					// Use the HitReaction
					hitReaction.Hit(hit.collider, GameObject.Find("PointRH").transform.forward * hitForce, hit.point);

			}

		}
	}
}
