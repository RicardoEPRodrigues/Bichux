
public class UnicornAchievment : Achievment {

    
    override public void CheckAchievment( ) 
    {
        if (GameManager.GetInstance().highscore.GetCurrentScore() > 2000)
        {
            isAchieved = true;
        }
    }
}
