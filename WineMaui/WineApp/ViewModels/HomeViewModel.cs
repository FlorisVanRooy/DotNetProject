using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using System.Windows.Input;
using WineApp.Messages;
using WineApp.Services;
using WineCode.Models;

namespace WineApp.ViewModels
{
    public class HomeViewModel : ObservableObject, IHomeViewModel
    {
        private string errorMessage;
        public string ErrorMessage
        {
            get => errorMessage;
            set => SetProperty(ref errorMessage, value);
        }

        private Recipe detectedRecipe;
        public Recipe DetectedRecipe
        {
            get => detectedRecipe;
            set => SetProperty(ref detectedRecipe, value);
        }
        private ImageSource photo;
        private bool pictureChosen;

        public bool PictureChosen
        {
            get => pictureChosen;
            set => SetProperty(ref pictureChosen, value);
        }
        public ImageSource Photo
        {
            get => photo;
            set => SetProperty(ref photo, value);
        }
        public ICommand AnalyzePictureCommand { get; set; }
        public ICommand TakePictureCommand { get; set; }
        public ICommand PickPictureCommand { get; set; }

        private INavigationService _navigationService;
        public HomeViewModel(INavigationService navigationService) {
            BindCommands();
            _navigationService = navigationService;
        }
        private void BindCommands()
        {
            AnalyzePictureCommand = new AsyncRelayCommand(GoToDetailsShow);
            TakePictureCommand = new AsyncRelayCommand(TakePhoto);
            PickPictureCommand = new AsyncRelayCommand(PickPhoto);
        }

        private async Task GoToDetailsShow()
        {
            await _navigationService.NavigateToDetailsAsync();
            WeakReferenceMessenger.Default.Send(new DetectedRecipeMessage(DetectedRecipe));
        }

        private async Task PickPhoto()
        {
            var photo = await MediaPicker.Default.PickPhotoAsync();
            await ShowPicture(photo);
        }

        private async Task TakePhoto()
        {
            var photo = await MediaPicker.Default.CapturePhotoAsync();
            await ShowPicture(photo);
        }

        private async Task ShowPicture(FileResult photo)
        {
            AnalyzePhoto(photo);
            var resizedPhoto = await PhotoImageService.ResizePhotoStreamAsync(photo);
            Photo = ImageSource.FromStream(() => new MemoryStream(resizedPhoto));
        }

        private async void AnalyzePhoto(FileResult photo)
        {
            DetectedRecipe = new Recipe();
            var resizedPhoto = await PhotoImageService.ResizePhotoStreamAsync(photo);
            Photo = ImageSource.FromStream(() => new MemoryStream(resizedPhoto));
            // Custom Vision API call
            var result = await CustomVisionService.ClassifyImageAsync(new MemoryStream(resizedPhoto));

            if (result.TagName != null) { 
                if (result.TagName.Equals("Negative"))
                {
                    ErrorMessage = "This is not a recognized recipe.";
                    PictureChosen = false;
                }
                else
                {
                    DetectedRecipe = await ApiService<Recipe>.GetAsync($"recipes/{result.TagName}");
                    PictureChosen = true;
                    ErrorMessage = "";
                };
            }
            else
            {
                ErrorMessage = "Please upload a picture.";
                PictureChosen = false;
            }
        }
    }
}
