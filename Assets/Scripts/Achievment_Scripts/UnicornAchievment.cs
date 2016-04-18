
public class UnicornAchievment : Achievment {

    
    override public void CheckAchievment( ) 
    {
        if (GameManager.GetInstance().highscore.GetHighScore() > 2000)
        {
            isAchieved = true;
        }

    }
}
