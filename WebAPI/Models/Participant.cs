//------------------------------------------------------------------------------
// <auto-generated>
//    O código foi gerado a partir de um modelo.
//
//    Alterações manuais neste arquivo podem provocar comportamento inesperado no aplicativo.
//    Alterações manuais neste arquivo serão substituídas se o código for gerado novamente.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebAPI.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Participant
    {
        public int ParticipantID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public Nullable<int> Score { get; set; }
        public Nullable<int> TimeSpent { get; set; }

        
    }
}
