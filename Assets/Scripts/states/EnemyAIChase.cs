using UnityEngine;
using System.Collections;
using Prime31.StateKit;

public class EnemyAIChase : SKState<EnemyAIController> {
	
	public override void begin () {
		Debug.Log("Starting to Chase!");
	}
	
	public override void reason () {
		// can we see player? if yes, we start chasing
		RaycastHit hit;
		bool canSeePlayer = false;

		if(Physics.Raycast(_context.transform.position, _context.playerTransform.position - _context.transform.position, out hit)) {
			if(hit.collider.tag == "Player") {
				canSeePlayer = true;
			}
		}

		if(!canSeePlayer) {
			_machine.changeState<EnemyAIPatrol>();
		}
	}
	
	public override void update (float deltaTime) {
		_context.agent.SetDestination(_context.playerTransform.position);
	}

}
