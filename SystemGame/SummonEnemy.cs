namespace OOP.SystemGame;

using OOP.Entites;

class SummonEnemy()
{
    List<Enemy> drafEnemy =
    [
        new CrowMauler(),
        new DungeonGuard(),
        new HabreCultist(),
        new Skeleton()
    ];

    public Enemy SummoningEnemy()
    {
        Random rnd = new();
        int total = drafEnemy.Count;
        int index = rnd.Next(0, total);

        return drafEnemy[index];
    }

}