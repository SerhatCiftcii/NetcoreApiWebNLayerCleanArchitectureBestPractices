using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Services.Products;


    //record nedir açıkla ?
    //record class ile aynı işlevi görür ama record class immutable'dır yani değiştirilemez.
    //karşılaştırma yaparken referans yerine değer bazlı karşılaştırma yapar.

    public record ProductDto(int Id, string Name, decimal Price, int Stock); //yeni yazım şekli
    



    //public record ProductDto
    //{
    //    public int Id { get; init; }
    //    public string Name { get; init; } 
    //    public decimal Price { get; init; }
    //    public int Stock { get; init; }


    //}

