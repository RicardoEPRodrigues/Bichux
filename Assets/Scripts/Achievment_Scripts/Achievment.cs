
public class Achievment {

    protected bool isAchieved = false;
    protected bool hasShowed = false;
    public bool HasAchievment() { return isAchieved; }
    public bool HasShowedAchievment() { return hasShowed; }

    public void ShowAchievment() { hasShowed= true; }
    public virtual void CheckAchievment(){}

}
