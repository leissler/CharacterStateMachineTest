using UnityEngine;
using System.Collections;
using Prime31.StateKit;

public class EnemyAIPatrol : SKState<EnemyAIController> {

	private int _currentWayPoint = 0;
	
	public override void begin ()
	{
		Debug.Log("Starting to Patrol");
	}

	public override void reason ()
	{
		// can we see player? if yes, we start chasing
		RaycastHit hit;

		if(Physics.Raycast(_context.transform.position, _context.playerTransform.position - _context.transform.position, out hit)) {
			if(hit.collider.tag == "Player") {
				_machine.changeState<EnemyAIChase>();
			}
		}
	}

	public override void update(float deltaTime) {
		if(_context.agent.remainingDistance <= _context.agent.stoppingDistance) {
			_currentWayPoint++;
			if(_currentWayPoint >= _context.wayPoints.Count) {
				_currentWayPoint = 0;
			}

			_context.agent.SetDestination(_context.wayPoints[_currentWayPoint].position);
		
		}

		_context.character.Move(_context.agent.desiredVelocity, false,false);

	}


}
