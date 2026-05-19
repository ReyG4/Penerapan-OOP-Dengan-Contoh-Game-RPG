using OOP.Entites;
using OOP.Items;
using OOP.SystemGame;
using OOP.Weapons;

Player player = new("Excel");
SummonEnemy summonEnemy = new();
DropItems dropItems = new();
Torch torch1 = new();
BandageRoll rusty = new();
player.UseWeapon(torch1);
player.Inventory.Add(rusty);

Console.WriteLine("===Selamat Data di Prgatory===");
Console.WriteLine("Selesaikan 10 Ruangan untuk keluar dari sini");
player.ShowStatus();
Console.WriteLine("Jangan sampai sanity mu habis dan kamu kelaparan, Ingat Itu!!! ");

Console.Write("Sudah Siap Untuk Menjelajah? (Y) ");
string play = Console.ReadLine() ?? "";

if (play == "Y")
{
    for (int i = 0; i < 10; i++)
    {
        Console.WriteLine("Kamu mamsasuki ruangan");
        Enemy enemy = summonEnemy.SummoningEnemy();
        Console.WriteLine("Sesuatu Muncul!!");
        enemy.InfoEnemy();
        bool round = true;
        while (round)
        {
            if (player.Hp <= 0 || player.Sanity <= 0) break;
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
                        if (choseItem >= 0 && choseItem < player.Inventory.Count)
                        {
                            Console.WriteLine($"Kamu memilih {player.Inventory[choseItem].Name}");
                            if (player.Inventory[choseItem] is Torch torch)
                            {
                                torch.ShowInfo();
                                Console.WriteLine("1. Gunakan Item\n2. Gunakan Sebagai Senjata\n3. Buang item");
                                Console.Write("Pilih: ");
                                string discard = Console.ReadLine() ?? "";
                                if (discard == "1")
                                {
                                    Console.Write("Gunakan Item Ini? (y/n) ");
                                    string useChoise = Console.ReadLine() ?? "";
                                    if (useChoise == "y")
                                    {
                                        player.UseItem(choseItem + 1);
                                        player.ShowStatus();
                                    }
                                    else if (useChoise == "n")
                                    {
                                        Console.WriteLine("Kembali Ke menu...");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Input Tidak sesuai");
                                    }
                                }
                                else if (discard == "2")
                                {
                                    if (player.EquippedWeapon is null)
                                    {
                                        Console.Write("Gunakan Sebagi Senjata? (y/n) ");
                                    }
                                    else
                                    {
                                        Console.Write($"Mau mengganti {player.EquippedWeapon.Name} dengan {torch.Name}? (y/n)");
                                    }
                                    string useChoise = Console.ReadLine() ?? "";
                                    if (useChoise == "y")
                                    {
                                        player.UseWeapon(torch);
                                        player.ShowStatus();
                                    }
                                    else if (useChoise == "n")
                                    {
                                        Console.WriteLine("Kembali Ke menu...");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Input Tidak sesuai");
                                    }
                                }
                                else if (discard == "3")
                                {
                                    player.DiscardItem(choseItem);
                                }
                                else
                                {
                                    Console.WriteLine("Input Tidak sesuai");
                                }
                            }
                            else if (player.Inventory[choseItem] is Weapon weapon)
                            {
                                weapon.ShowInfo();
                                Console.WriteLine("1. Gunakan senjata\n2. Buang Senjata");
                                Console.Write("Pilih: ");
                                string discard = Console.ReadLine() ?? "";
                                if (discard == "1")
                                {
                                    if (player.EquippedWeapon is null)
                                    {
                                        Console.WriteLine("Gunakan Sebagi Senjata? (y/n) ");
                                    }
                                    else
                                    {
                                        Console.Write($"Mau mengganti {player.EquippedWeapon.Name} dengan {weapon.Name}? (y/n)");
                                    }
                                    string useChoise = Console.ReadLine() ?? "";
                                    if (useChoise == "y")
                                    {
                                        player.UseWeapon(weapon);
                                        player.ShowStatus();
                                    }
                                    else if (useChoise == "n")
                                    {
                                        Console.WriteLine("Kembali Ke menu...");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Input Tidak sesuai");
                                    }
                                }
                                else if (discard == "2")
                                {
                                    player.DiscardItem(choseItem);
                                }
                                else
                                {
                                    Console.WriteLine("Input Tidak sesuai");
                                }
                            }
                            else if (player.Inventory[choseItem] is Item item)
                            {
                                item.ShowInfo();
                                Console.WriteLine("1. Gunakan Item\n2. Buang Item");
                                Console.Write("Pilih: ");
                                string discard = Console.ReadLine() ?? "";
                                if (discard == "1")
                                {
                                    Console.Write("Gunakan Item Ini? (y/n) ");
                                    string useChoise = Console.ReadLine() ?? "";
                                    if (useChoise == "y")
                                    {
                                        player.UseItem(choseItem + 1);
                                        player.ShowStatus();
                                    }
                                    else if (useChoise == "n")
                                    {
                                        Console.WriteLine("Kembali Ke menu...");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Input Tidak sesuai");
                                    }
                                }
                                else if (discard == "2")
                                {
                                    player.DiscardItem(choseItem);
                                }
                                else
                                {
                                    Console.WriteLine("Input Tidak sesuai");
                                }
                            }
                        }
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
}
else
{
    Console.WriteLine("Kamu terlalu lemah bahkan untuk memulai MATI SAJA SANA!!!💀💀");
}

