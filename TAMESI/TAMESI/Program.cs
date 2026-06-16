// InventoryAPP/Program.cs
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace InventoryApp
{

    // 商品クラス（モデル）
    class Product
    {
        public int Id {  get; set; }
        public  string Name { get; set; }
        public  string Category { get; set; }
        public int Stock {  get; set; }
        public decimal Price { get; set; }

    }

    class Program
    {

        //ダミーデータ（本来はDBから取得するイメージ）
        static List<Product> products = new List<Product>
        {
            new Product { Id = 1, Name = "ノートPC", Category = "電子機器", Stock =10, Price = 98000 },
            new Product { Id = 2, Name = "マウス", Category = "電子機器", Stock =50, Price = 3000 },
            new Product { Id = 3, Name = "キーボード", Category = "電子機器", Stock = 30, Price = 8000 },
            new Product { Id = 4, Name = "デスク", Category = "家具", Stock = 5, Price = 45000 },
            new Product { Id = 5, Name = "チェア",Category = "家具", Stock = 8, Price = 32000 },
            new Product { Id = 6, Name = "コピー用紙",Category = "文具", Stock = 200, Price = 500 },
            new Product { Id = 7, Name = "ボールペン",Category = "文具", Stock = 300, Price = 100 },
        };

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            while (true)
            {
                ShowMenu();
                String input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        ShowAllProducts();
                        break;
                    case "2":
                        SearchByName();
                        break;
                    case "3":
                        SearchByCategory();
                        break;
                    case "4":
                        SearchByStock();
                        break;
                    case "0":
                        Console.WriteLine("終了します。");
                        return;
                    default:
                        Console.WriteLine("無効な入力です。もう一度選択してください。" );
                        break;
                }

                Console.WriteLine("\nEnterキーを押して続ける...");
                Console.ReadLine();

            }
        }





        //メニューを表示
        static void ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("=======================================");
            Console.WriteLine("在庫管理システム");
            Console.WriteLine("=======================================");
            Console.WriteLine("1. 全商品を表示");
            Console.WriteLine("2. 商品名で検索");
            Console.WriteLine("3. カテゴリで検索");
            Console.WriteLine("4. 在庫数で絞り込み（少ない順）");
            Console.WriteLine("0. 終了");
            Console.WriteLine("=======================================");
            Console.WriteLine("選択してください");

        }

        //全商品表示
        static void ShowAllProducts()
        {
            Console.WriteLine("\n--- 全商品一覧　---");
            PrintProducts(products);
        }

        //商品名で検索
        static void SearchByName()
        {
            Console.Write("\n商品名を入力: ");
            string keyword = Console.ReadLine();

            // LINQを使って検索(SQLのWHERE LIKEに近いイメージ)
            var result = products.Where(p => p.Name.Contains(keyword)).ToList();

            Console.WriteLine($"\n--- 「{keyword}」の検索結果　---");
            PrintProducts(result);
        }

        //カテゴリで検索
        static void SearchByCategory()
        {
            //カテゴリ一覧を重複なしで取得(SQLのDISTINCTに近いイメージ)
            var categories = products.Select(p => p.Category ).Distinct().ToList();
            Console.WriteLine("\nカテゴリ一覧: ");
            for (int i = 0; i < categories.Count; i++)
            {
                Console.WriteLine($"{i + 1}.{categories[i]}");
            }

            Console.WriteLine("番号を選択: ");
            if (int.TryParse(Console.ReadLine(), out int index) && index >= 1 && index <= categories.Count )
                { 
                string selectedCategory = categories[index - 1];
                var result = products.Where(p => p.Category == selectedCategory).ToList();

                Console.WriteLine($"\n--- カテゴリ 「{selectedCategory}」の商品　---");
                PrintProducts(result); 
                }

            else { Console.WriteLine("無効な入力です。"); }
         }

        // 在庫数で絞り込み
        static void SearchByStock ()
        {
            Console.Write("\n在庫数の上限を入力(例: 20以下を表示する場合は20): ");
            if (int.TryParse(Console.ReadLine(),out int maxStock))
            {
                // LINQでフィルタ&ソート
                var result = products.Where(p => p.Stock <= maxStock ).OrderBy(p => p.Stock).ToList();

                Console.WriteLine($"\n--- 在庫数{maxStock}以下の商品(少ない順)　---");
                PrintProducts( result );
            }
            else
            {
                Console.WriteLine("数値を入力してください。");
            }
        }

        //商品リストを表示する共通メソット
        static void PrintProducts(List<Product> list)
        {
            if (list.Count == 0)
            {
                Console.WriteLine("該当する商品はありません。");
                return;
            }

            Console.WriteLine($"{"ID",-4}{"商品名",-15}{"カテゴリ",-10}{"在庫数",6}{"価格",10}");
            Console.WriteLine(new string ('-',50));

            foreach (var p in list)
            {
                Console.WriteLine($"{p.Id,-4}{p.Name,-15}{p.Category,-10}{p.Stock,6}{p.Price,10:C}");
            }

            Console.WriteLine($"\n合計: {list.Count}件");
        }


    }


}