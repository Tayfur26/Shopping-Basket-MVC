using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StajMvc.ViewModels
{
    public class SepetViewModels :List<SepetViewItem>
    {
        public List<SepetViewItem> SepetViewItems { get; set; }
    }
}