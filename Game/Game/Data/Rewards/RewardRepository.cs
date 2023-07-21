namespace Game.Data.Rewards;

public interface IRewardRepository
{
    List<Reward> GetRewards();
}
public class RewardRepository : IRewardRepository
{
    public List<Reward> GetRewards()
    {
        throw new NotImplementedException();
    }
}
