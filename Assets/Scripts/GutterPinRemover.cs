using UnityEngine;

public class GutterPinRemover : MonoBehaviour {

    private void OnCollisionEnter(Collision collision){
        GameObject objectHit = collision.collider.gameObject;
        if (objectHit.GetComponent<Pin>()){
            Destroy(objectHit);
        }
    }
}

