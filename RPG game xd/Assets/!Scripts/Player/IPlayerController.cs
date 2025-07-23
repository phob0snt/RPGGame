using UnityEngine;

public interface IPlayerController
{
    public void Move(float Multiplier = 1f);
    public void EnableCrouch();
    public void DisableCrouch();
<<<<<<< Updated upstream
    public void Jump();
=======
    public Player GetPlayer();
>>>>>>> Stashed changes
}
