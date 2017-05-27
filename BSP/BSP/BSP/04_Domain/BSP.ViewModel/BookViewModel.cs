using BSP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BSP.ViewModel
{
    public class BookViewModel
    {
        public Book Book { get; set; }
        public SelectList Publishers { get; set; }
        public SelectList Categories { get; set; }
    }
}
