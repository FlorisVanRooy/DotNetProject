using CommunityToolkit.Mvvm.Messaging.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WineCode.Models;

namespace WineApp.Messages
{
    public class DetectedRecipeMessage(Recipe recipe) : ValueChangedMessage<Recipe>(recipe)
    {
    }
}
