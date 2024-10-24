using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WineCode.Models;

namespace WineApp.ViewModels
{
    public interface IWineViewModel
    {
        public Wine Wine { get; set; }
        public ICommand NavigateBackCommand { get; set; }
    }
}
