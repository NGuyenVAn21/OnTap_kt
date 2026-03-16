using System;
using System.Collections.Generic;
using System.Linq;

class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
    public string Category { get; set; }

    public Product(int id, string name, double price, string category)
    {
        Id = id;
        Name = name;
        Price = price;
        Category = category;
    }

    public override string ToString()
    {
        return $"[{Id}] {Name,-20} {Price,8:N0} VNĐ {Category}";
    }
}

class Program
{
    static List<Product> GetProducts()
    {
        return new List<Product>
        {
            new Product(1, "Laptop Dell",       15000000, "Dien tu"),
            new Product(2, "Chuot Logitech",      350000, "Phu kien"),
            new Product(3, "Ban phim Keychron",  1200000, "Phu kien"),
            new Product(4, "Tai nghe Sony",       850000, "Am thanh"),
            new Product(5, "Man hinh LG",        4500000, "Dien tu"),
            new Product(6, "USB-C Hub",           450000, "Phu kien"),
        };
    }


    // 1. Lay san pham gia > 500,000
    static IEnumerable<Product> GetExpensive(List<Product> products)
        => products.Where(p => p.Price > 500000);

    // 2. Sap xep theo Price tang dan
    static IEnumerable<Product> SortByPriceAsc(List<Product> products)
        => products.OrderBy(p => p.Price);

    // 3. Lay 3 san pham re nhat
    static IEnumerable<Product> GetCheapest3(List<Product> products)
        => products.OrderBy(p => p.Price).Take(3);

    // 4. Tim kiem theo ten nhap tu ban phim
    static IEnumerable<Product> SearchByName(List<Product> products, string keyword)
        => products.Where(p => p.Name.Contains(keyword, StringComparison.OrdinalIgnoreCase));



    static void PrintStats(List<Product> products)
    {
        Console.WriteLine("               THONG KE");
        Console.WriteLine($"Tong so san pham  : {products.Count}");
        Console.WriteLine($"Tong gia tri      : {products.Sum(p => p.Price):N0} VND");
        Console.WriteLine($"Gia trung binh    : {products.Average(p => p.Price):N0} VND");
        Console.WriteLine($"San pham dat nhat : {products.Max(p => p.Price):N0} VND");
        Console.WriteLine($"San pham re nhat  : {products.Min(p => p.Price):N0} VND");
    }


    static void Main(string[] args)
    {
        var products = GetProducts();

       
        Console.WriteLine("       DANH SACH SAN PHAM BAN DAU");  
        foreach (var p in products)
            Console.WriteLine(p);

        Console.WriteLine("\n--- 1. San pham gia > 500,000 VND ---");
        foreach (var p in GetExpensive(products))
            Console.WriteLine(p);

        Console.WriteLine("\n--- 2. Sap xep theo gia tang dan ---");
        foreach (var p in SortByPriceAsc(products))
            Console.WriteLine(p);

        Console.WriteLine("\n--- 3. Top 3 san pham re nhat ---");
        foreach (var p in GetCheapest3(products))
            Console.WriteLine(p);

        Console.WriteLine("\n--- 4. Tim kiem san pham theo ten ---");
        Console.Write("Nhap ten can tim: ");
        string keyword = Console.ReadLine() ?? "";
        var result = SearchByName(products, keyword);
        if (!result.Any())
            Console.WriteLine($"Khong tim thay san pham nao co ten chua \"{keyword}\".");
        else
            foreach (var p in result)
                Console.WriteLine(p);

        PrintStats(products);

        Console.WriteLine("\nNhan phim bat ky de thoat...");
        Console.ReadKey();
    }
}