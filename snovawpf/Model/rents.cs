//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace snovawpf.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class rents
    {
        public int id { get; set; }
        public int userid { get; set; }
        public int bookid { get; set; }
        public System.DateTime datastart { get; set; }
        public System.DateTime datafinish { get; set; }
    
        public virtual books books { get; set; }
        public virtual users users { get; set; }
    }
}