//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FurnitureSales.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Sales
    {
        public int idSale { get; set; }
        public string furnitureName { get; set; }
        public string model { get; set; }
        public int numberOfSold { get; set; }
    
        public virtual TypesOfFurnitures TypesOfFurnitures { get; set; }
    }
}
