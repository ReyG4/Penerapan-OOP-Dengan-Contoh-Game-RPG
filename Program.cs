using OOP.Entites;
using OOP.SystemGame;

Player player = new("Excel");
SummonEnemy summonEnemy = new();
DropItems dropItems = new();

Console.WriteLine("===Selamat Data di Purgatory===");
Console.WriteLine("Selesaikan 5 Ruangan untuk keluar dari sini");
player.ShowStatus();
Console.WriteLine("Jangan sampai sanity mu habis dan kamu kelaparan, Ingat Itu!!! ");

Console.Write("Sudah Siap Untuk Menjelajah? (Y) ");
string play = Console.ReadLine() ?? "";

if (play == "Y" || play == "y")
{
    for (int i = 0; i < 5; i++)
    {
        if (player.Hp <= 0)
        {
            Console.WriteLine($"{player.Name} Kamu kehabisan HP, kamu mati dan membusuk disini!!");
            break;
        }
        if (player.Sanity <= 0)
        {
            Console.WriteLine($"{player.Name} Kamu kehilangan sanity mu, Kamu gila dan berakhir menjadi monster disini");
            break;
        }
        if (player.Hunger == 100)
        {
            player.TakeDamage(10);
            Console.WriteLine("Kamu terlalu lapar. HP mu berkurang 10");
        }
        Console.WriteLine("Kamu mamsasuki ruangan");
        Enemy enemy = summonEnemy.SummoningEnemy();
        Console.WriteLine("Sesuatu Muncul!!");
        enemy.InfoEnemy();
        bool round = true;
        while (round)
        {
            if (player.Hp <= 0 || player.Sanity <= 0) break;
            int roundCount = 0;
            if (roundCount == 3 && player.EffectTorch == true)
            {
                player.EffectTorch = false;
                Console.WriteLine("Efek dari torch kamu sudah habis");
            }
            Console.WriteLine("--Action Menu--");
            Console.WriteLine("1. Lihat Status\n2. Lihat Inventory\n3. Serang");

            Console.Write("Pilih: ");
            string choise = Console.ReadLine() ?? "";

            switch (choise)
            {
                case "1":
                    player.ShowStatus();
                    break;
                case "2":
                    player.ShowInventory();
                    if (player.Inventory.Count > 0)
                    {
                        Console.Write("Pilih Item di inventory: (n to back)");
                        int choseItem = int.TryParse(Console.ReadLine(), out int itemChoice) ? itemChoice : -1;
                        choseItem -= 1;
                        ChoosingItem choosingItem = new();
                        choosingItem.ChoseItem(choseItem, player);
                    }
                    break;
                case "3":
                    AttackSystem attackSystem = new();
                    attackSystem.PlayerAttack(player, enemy);
                    if (enemy is Skeleton skeleton)
                    {
                        bool escape = skeleton.SpesialAbility();
                        if (escape)
                        {
                            Console.WriteLine("Siall!!!");
                            round = false;
                            break;
                        }
                    }
                    bool enemyDie = attackSystem.EnemyDead(enemy, dropItems, player);
                    if (enemyDie)
                    {
                        round = false;
                        break;
                    }
                    attackSystem.EnemyAttack(enemy, player);
                    break;
                default:
                    Console.WriteLine("Tidak ada pilihan itu");
                    break;
            }
        }
    }
    if (player.Hp > 0 && player.Sanity > 0)
    {
        Console.WriteLine($"Selamat {player.Name} Kamu berhasil kelur dari purgatory sekarang kamu bebas. Tapi kesengsaraan mengintaimu di depan :D");
    }
}
else
{
    Console.WriteLine("Kamu terlalu lemah bahkan untuk memulai MATI SAJA SANA!!!💀💀");
}

