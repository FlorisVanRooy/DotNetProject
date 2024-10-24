using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WineCode.Models;

namespace WineApp.ViewModels
{
    public interface IDetailsViewModel
    {
        Wine SelectedWine { get; set; }
        Recipe DetectedRecipe { get; set; }
        ICommand ToggleFavoriteCommand { get; set; }
        ICommand NavigateToWineCommand { get; set; }
        ICommand NavigateBackCommand { get; set; }
    }
}
