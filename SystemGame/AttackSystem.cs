using OOP.Entities;
using OOP.Items;

namespace OOP.SystemGame;

class AttackSystem
{
    public void PlayerAttack(Player player, Enemy enemy)
    {
        player.Attack();
        if (player.EquippedWeapon != null)
        {
            enemy.TakeDamage(player.EquippedWeapon.Damage);
        }
        else
        {
            enemy.TakeDamage(player.Damage);
        }
    }

    public bool EnemyDead(Enemy enemy, DropItems dropItems, Player player)
    {
        if (enemy.Hp <= 0)
        {
            Console.WriteLine($"{enemy.Name} Berhasil dikalahkan");
            Random rnd = new();
            int drop = rnd.Next(0, 2);
            if (drop == 1)
            {
                Item itemDrop = dropItems.RandomDropItem();
                player.FoundItem(itemDrop);
                Console.Write("Ambil tidak?(y/n) ");
                string take = Console.ReadLine() ?? "";
                if (take == "y")
                {
                    player.AddToInventory(itemDrop);
                }
                else
                {
                    Console.WriteLine("Kamu membiarkan nya");
                }
            }
            Console.WriteLine($"Kamu memasuki ruangan berikutnya, kamu mendapatkan sedikit heal, tapi kamu menjadi lapar");
            player.Heal(20);
            player.IncreaseHunger(10);
            return true;
        }
        return false;
    }

    public void EnemyAttack(Enemy enemy, Player player)
    {
        Console.WriteLine("<><><>");
        Console.WriteLine($"{enemy.Name} menyerang");
        if (enemy is HabreCultist habreCultist)
        {
            habreCultist.SpesialAbility(player);
        }
        else if (enemy is CrowMauler crowMauler2)
        {
            int crowMaulerDamage = crowMauler2.Attack(player);
            player.TakeDamage(crowMaulerDamage);
            player.TakeDamage(crowMaulerDamage);
        }
        else
        {
            enemy.Attack();
            player.TakeDamage(enemy.Damage);
        }
    }
}