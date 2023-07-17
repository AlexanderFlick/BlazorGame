using Game.Data.Dinosaurs;
using Game.Data.Dinosaurs.DinosaurMoves;
using Game.Data.Enemies;

namespace Game.Services;

public interface IEnemyService
{
    Enemy CreateEnemy();
}
public class EnemyService : IEnemyService
{
    Random rand = new();
    private readonly IDinosaurMoveRepository _dinosaurMoves;
    public EnemyService(IDinosaurMoveRepository dinosaurMoves)
    {
        _dinosaurMoves= dinosaurMoves;
    }
    public Enemy CreateEnemy()
    {
        var health = GetEnemyHealth();
        var enemy = new Enemy
        {
            Hostile = true,            
            Name = "Rogue Dinosaur",
            CurrentHealth = health,
            TotalHealth= health,
            Battle = new BattleStat
            {
                AttackModifier = 3,
                BaseDefense = 13,
                Selected = true,
                Speed = GetEnemySpeed()
            },
            Moves = _dinosaurMoves.GetEnemyMoves(),
            Description = GetEnemyDescription()
        };

        return enemy;
    }

    public int GetEnemyHealth()
    {
        return rand.Next(90, 101);
    }

    public int GetEnemySpeed()
    {
        return rand.Next(50, 76);
    }

    public string GetEnemyDescription()
    {
        return "A snarling dinosaur stands in front of you. His eyes narrow, his nostrils flare. He lets out a bone-shattering scream, the smell of blood fills the air around it.";
    }
}
