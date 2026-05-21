using OOP.Entites;
using OOP.Items;
using OOP.SystemGame;
using OOP.Weapons;

Player player = new("Excel");
SummonEnemy summonEnemy = new();
DropItems dropItems = new();
Torch torch = new();
player.AddToInventory(torch);

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
                    player.Attack();
                    enemy.TakeDamage(enemy.Hp - 1);
                    if (player.EquippedWeapon != null)
                    {
                        enemy.TakeDamage(player.EquippedWeapon.Damage);
                    }
                    else
                    {
                        enemy.TakeDamage(player.Damage);
                    }

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
                        round = false;
                        break;
                    }

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

