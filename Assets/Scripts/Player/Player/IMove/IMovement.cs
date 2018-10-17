using UnityEngine;

public interface IMovemen {

    void MoveForward(GameObject player, float speed);
    void MoveBack(GameObject player, float speed);
    void MoveRight(GameObject player, float speed);
    void MoveLeft(GameObject player, float speed);

    void SetAnimator(GameObject player, bool start);

    void SetBomb(GameObject player, GameObject bomb);

    void MoveCalculate(GameObject player, float speed);
}
