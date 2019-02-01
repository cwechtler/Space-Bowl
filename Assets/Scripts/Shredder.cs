using UnityEngine;

public class Shredder : MonoBehaviour{

    private void OnTriggerExit(Collider collider){
        GameObject objectLeft = collider.gameObject;
        if (objectLeft.GetComponent<Pin>()){
            Destroy(objectLeft);
        }
    }
}
