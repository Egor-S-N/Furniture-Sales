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
    
    public partial class Workers
    {
        public int idWorker { get; set; }
        public string surname { get; set; }
        public string name { get; set; }
        public string patronymic { get; set; }
        public string post { get; set; }
        public int codeAccount { get; set; }
    
        public virtual Accounts Accounts { get; set; }
    }
}
