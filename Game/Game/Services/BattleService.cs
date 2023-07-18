using Game.Data;
using Game.Data.Dinosaurs;
using Game.Data.Dinosaurs.DinosaurMoves;
using Game.Data.Enemies;
using Game.Pages.Components.BattleComponents;
using System;

namespace Game.Services;

public interface IBattleService
{
    void SetEnemyMove(Enemy enemy);
    List<MoveSummary> BattleRound(Player player, List<Enemy> enemies);
    void UseUltimate(Player player, List<Enemy> enemies);
    bool AllEnemiesAreDead(List<Enemy> enemies);
    void ResetMoves(Player player, List<Enemy> enemies);
    bool MoveSelectedForEachDinosaur(Player player);
}
public class BattleService : IBattleService
{
    Random rand = new();
    private readonly ITurnOrderService _turnOrder;
    public List<MoveSummary> TurnSummary { get; private set; }

    public BattleService(ITurnOrderService turnOrder)
    {
        _turnOrder = turnOrder;
    }

    public List<MoveSummary> BattleRound(Player player, List<Enemy> enemies)
    {
        var turnSummaries = new List<MoveSummary>();
        var turnOrder = _turnOrder.GetTurnOrder(player, enemies);

        foreach (var dino in turnOrder)
        {
            var turnSummary = new MoveSummary { Attacker = dino.PetName ?? dino.Name };
            var moveToProcess = GetMoveToProcess(dino.Moves, dino.Hostile);
            turnSummary.MoveType = moveToProcess.MoveType;
            turnSummary.Hit = moveToProcess.Hit;
            turnSummary.MoveName = moveToProcess.Name;

            var dinosToImpact = GetDinosaursToImpact(dino.Hostile, turnOrder);

            if (moveToProcess.MoveType == MoveType.Defensive)
            {
                ProcessDefensiveMove(moveToProcess, dino);
                turnSummary.DefensiveIncrease = dino.Battle.CurrentDefense;
            }

            if (moveToProcess.MoveType == MoveType.Offensive)
            {
                ProcessAttack(moveToProcess, dinosToImpact, dino);
                //turnSummary.Successful = moveToProcess.SuccessfulHits;
                turnSummary.AttackDamage = moveToProcess.DamageDone;
            }

            player.Ultimate.CurrentCharge += moveToProcess.ChargeIncrease;
            turnSummary.UltimateChargeIncrease = moveToProcess.ChargeIncrease;


            if (moveToProcess.Hit == HitScope.One)
            {
                turnSummary.Defender = dinosToImpact.FirstOrDefault(x => !x.Dead).Name.ToString();
            }
            if (moveToProcess.Hit == HitScope.All)
            {
                turnSummary.Defender = " everyone";
            }

            turnSummaries.Add(turnSummary);
        }

        return turnSummaries;
    }

    public void SetEnemyMove(Enemy enemy)
    {
        var moveIndex = rand.Next(0, enemy.Moves.Count);
        enemy.Moves[moveIndex].Selected = true;
    }

    private Move GetMoveToProcess(List<Move> moves, bool hostile)
    {
        if (!hostile)
        {
            return moves.Where(x => x.Selected == true).First();
        }

        var moveIndex = rand.Next(0, moves.Count);
        return moves[moveIndex];
    }

    private void ProcessAttack(Move offensiveMove, List<Dinosaur> dinosToImpact, Dinosaur attackingDinosaur)
    {
        if (offensiveMove.Hit == HitScope.One)
        {
            var enemyBeingHit = dinosToImpact.Where(x => !x.Dead).First();

            var attackSuccess = PassedCurrentDefense(attackingDinosaur, enemyBeingHit);
            offensiveMove.SuccessfulHits.Add(attackSuccess);

            if (attackSuccess)
            {
                GetDamage(offensiveMove);
                enemyBeingHit.CurrentHealth -= offensiveMove.DamageDone;
            }

            if (enemyBeingHit.CurrentHealth <= 0)
            {
                enemyBeingHit.Dead = true;
            }
        }

        if (offensiveMove.Hit == HitScope.All)
        {
            var enemiesBeingHit = dinosToImpact;

            foreach (var enemy in enemiesBeingHit)
            {
                var attackSuccess = PassedCurrentDefense(attackingDinosaur, enemy);
                offensiveMove.SuccessfulHits.Add(attackSuccess);

                if (attackSuccess)
                {
                    GetDamage(offensiveMove);
                    enemy.CurrentHealth -= offensiveMove.DamageDone;
                }

                if (enemy.CurrentHealth <= 0)
                {
                    enemy.Dead = true;
                }
            }
        }
    }

    private static List<Dinosaur> GetDinosaursToImpact(bool hostile, List<Dinosaur> dinosaursInTurnOrder)
    {
        return hostile ?
            dinosaursInTurnOrder.Where(x => !x.Hostile).ToList() :
            dinosaursInTurnOrder.Where(x => x.Hostile).ToList();
    }

    private void ProcessDefensiveMove(Move defensiveMove, Dinosaur defensiveDino)
    {
        for (int i = 0; i < defensiveMove.DiceCount; i++)
        {
            var increase = rand.Next(1, defensiveMove.DiceSize + 1);
            defensiveMove.BaseDefenseIncrease += increase;
        }

        defensiveDino.Battle.CurrentDefense = defensiveMove.BaseDefenseIncrease + defensiveDino.Battle.BaseDefense;
    }

    private void GetDamage(Move attackMove)
    {
        for (int i = 0; i < attackMove.DiceCount; i++)
        {
            var damage = rand.Next(1, attackMove.DiceSize + 1);
            attackMove.DamageDone += damage;
        }
    }

    private bool PassedCurrentDefense(Dinosaur attackingDinosaur, Dinosaur defendingDinosaur)
    {
        var attackRoll = rand.Next(1, 11);
        var attackWithModifier = attackRoll + attackingDinosaur.Battle.AttackModifier;

        return attackWithModifier >= defendingDinosaur.Battle.CurrentDefense;
    }

    public void UseUltimate(Player player, List<Enemy> enemies)
    {
        if (player.Ultimate.MaxCharge <= player.Ultimate.CurrentCharge)
        {
            player.Ultimate.CurrentCharge = 0;
            foreach (var enemy in enemies)
            {
                enemy.CurrentHealth -= player.Ultimate.Damage;

                if (enemy.CurrentHealth <= 0)
                {
                    enemy.Dead = true;
                }
            }
        }

        var continueFighting = enemies.Any(x => !x.Dead);
        if (!continueFighting)
        {
            player.Battle.Won = true;
        }
    }

    public bool AllEnemiesAreDead(List<Enemy> enemies)
    {
        foreach (var enemy in enemies)
        {
            if (!enemy.Dead)
            {
                return false;
            }
        }

        return true;
    }

    public void ResetMoves(Player player, List<Enemy> enemies)
    {
        foreach (var dino in player.Dinosaurs)
        {
            foreach (var moveset in dino.Moves)
            {
                moveset.Selected = false;
            }
        }

        foreach (var dino in enemies)
        {
            foreach (var moveset in dino.Moves)
            {
                moveset.Selected = false;
            }
        }
    }

    public bool MoveSelectedForEachDinosaur(Player player)
    {
        var movesSelected = new List<bool>();

        foreach (var dino in player.Dinosaurs)
        {
            foreach (var move in dino.Moves)
            {
                if (move.Selected)
                {
                    movesSelected.Add(true);
                }
            }
        }

        return movesSelected.Count == player.Dinosaurs.Count;
    }
}
