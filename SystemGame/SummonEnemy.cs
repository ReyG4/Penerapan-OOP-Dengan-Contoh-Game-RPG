namespace OOP.SystemGame;

using OOP.Entities;

class SummonEnemy()
{
    Random rnd = new();
    List<Func<Enemy>> drafEnemy =
    [
        () => new CrowMauler(),
        () => new DungeonGuard(),
        () => new HabreCultist(),
        () => new Skeleton()
    ];

    public Enemy SummoningEnemy()
    {
        int total = drafEnemy.Count;
        int index = rnd.Next(0, total);

        return drafEnemy[index]();
    }

}