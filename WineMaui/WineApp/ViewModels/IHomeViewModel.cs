using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WineCode.Models;

namespace WineApp.ViewModels
{
    public interface IHomeViewModel
    {
        bool PictureChosen { get; set; }
        string ErrorMessage { get; set; }
        ImageSource Photo { get; set; }
        Recipe DetectedRecipe { get; set; }
        ICommand TakePictureCommand { get; set; }
        ICommand PickPictureCommand { get; set; }
        ICommand AnalyzePictureCommand { get; set; }
    }
}
