using ontap;
using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        var products = new List<Product>
        {
            new Product(1, "Laptop Dell",       15000000, "Dien tu"),
            new Product(2, "Chuot Logitech",      350000, "Phu kien"),
            new Product(3, "Ban phim Keychron",  1200000, "Phu kien"),
            new Product(4, "Tai nghe Sony",       850000, "Am thanh"),
            new Product(5, "Man hinh LG",        4500000, "Dien tu"),
            new Product(6, "USB-C Hub",           450000, "Phu kien"),
        };

        Console.WriteLine("       DANH SACH SAN PHAM BAN DAU");
        foreach (var p in products)
            Console.WriteLine(p);

        Console.WriteLine("\n--- 1. San pham gia > 500,000 VND ---");
        foreach (var p in products.Where(p => p.Price > 500000))
            Console.WriteLine(p);

        Console.WriteLine("\n--- 2. Sap xep theo gia tang dan ---");
        foreach (var p in products.OrderBy(p => p.Price))
            Console.WriteLine(p);

        Console.WriteLine("\n--- 3. Top 3 san pham re nhat ---");
        foreach (var p in products.OrderBy(p => p.Price).Take(3))
            Console.WriteLine(p);

        Console.WriteLine("\n--- 4. Tim kiem san pham theo ten ---");
        Console.Write("Nhap ten can tim: ");
        string keyword = Console.ReadLine() ?? "";
        var result = products.Where(p =>
            p.Name.Contains(keyword, StringComparison.OrdinalIgnoreCase));
        if (!result.Any())
            Console.WriteLine($"Khong tim thay san pham nao.");
        else
            foreach (var p in result)
                Console.WriteLine(p);

        Console.WriteLine("\n               THONG KE");
        Console.WriteLine($"Tong so san pham  : {products.Count}");
        Console.WriteLine($"Tong gia tri      : {products.Sum(p => p.Price):N0} VND");
        Console.WriteLine($"Gia trung binh    : {products.Average(p => p.Price):N0} VND");
        Console.WriteLine($"San pham dat nhat : {products.Max(p => p.Price):N0} VND");
        Console.WriteLine($"San pham re nhat  : {products.Min(p => p.Price):N0} VND");

        Console.WriteLine("\nNhan phim bat ky de thoat...");
        Console.ReadKey();
    }
}