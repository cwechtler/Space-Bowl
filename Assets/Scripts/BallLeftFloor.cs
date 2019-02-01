using UnityEngine;

public class BallLeftFloor : MonoBehaviour {

    private Ball ball;
    private Animator animator;

    private void Start(){
        ball = GameObject.FindObjectOfType<Ball>();
        animator = ball.GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider collider){
        GameObject objectLeft = collider.gameObject;
        if (objectLeft.GetComponent<Ball>()){
            animator.SetTrigger("LeftFloorTrigger");
        }
    }
}
