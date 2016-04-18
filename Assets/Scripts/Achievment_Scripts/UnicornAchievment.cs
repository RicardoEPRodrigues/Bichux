
public class UnicornAchievment : Achievment {

    public UnicornAchievment()
    {
        isAchieved = false;
        hasShowed = false;
    }
    override public void CheckAchievment( ) 
    {
        if (GameManager.GetInstance().highscore.GetCurrentScore() > 20000)
        {
            isAchieved = true;
        }
    }
}
