// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace BlazorMatchGame.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "/Users/cuiwenyue/Projects/BlazorMatchGame/BlazorMatchGame/_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/Users/cuiwenyue/Projects/BlazorMatchGame/BlazorMatchGame/_Imports.razor"
using System.Net.Http.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "/Users/cuiwenyue/Projects/BlazorMatchGame/BlazorMatchGame/_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "/Users/cuiwenyue/Projects/BlazorMatchGame/BlazorMatchGame/_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "/Users/cuiwenyue/Projects/BlazorMatchGame/BlazorMatchGame/_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "/Users/cuiwenyue/Projects/BlazorMatchGame/BlazorMatchGame/_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "/Users/cuiwenyue/Projects/BlazorMatchGame/BlazorMatchGame/_Imports.razor"
using Microsoft.AspNetCore.Components.WebAssembly.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "/Users/cuiwenyue/Projects/BlazorMatchGame/BlazorMatchGame/_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "/Users/cuiwenyue/Projects/BlazorMatchGame/BlazorMatchGame/_Imports.razor"
using BlazorMatchGame;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "/Users/cuiwenyue/Projects/BlazorMatchGame/BlazorMatchGame/_Imports.razor"
using BlazorMatchGame.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/Users/cuiwenyue/Projects/BlazorMatchGame/BlazorMatchGame/Pages/Index.razor"
using System.Timers;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/")]
    public partial class Index : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 78 "/Users/cuiwenyue/Projects/BlazorMatchGame/BlazorMatchGame/Pages/Index.razor"
       
    List<string> animalEmoji = new List<string>()
{
        "????", "????",
        "????", "????",
        "????", "????",
        "????", "????",
        "????", "????",
        "????", "????",
        "????", "????",
        "????", "????",


    };

    // Add different Level to the game

    

#line default
#line hidden
#nullable disable
#nullable restore
#line 107 "/Users/cuiwenyue/Projects/BlazorMatchGame/BlazorMatchGame/Pages/Index.razor"
            

    List<string> emptyEmoji = new List<string>()
    {
                "","",
                "","",
                "","",
                "","",
                "","",
                "","",
                "","",
                "","",
            };

    List<string> shuffledAnimals = new List<string>();
    int matchesFound = 0;
    // count mistakes
    int mistakes = 0;
    Timer timer;
    int tenthsOfSecondsElapsed = 0;
    string timeDisplay;
    string bestTimeToDisplay;
    int bestTime = 0;
    bool playButtonShow = false;
    bool animalIconShow = false;
    int playLevelListLength = 16;

    protected override void OnInitialized()
    {
        timer = new Timer(100);
        timer.Elapsed += Timer_Tick;

        // Load Game
        //SetUpGame();
    }

    private void SetUpGame()
    {
        

#line default
#line hidden
#nullable disable
#nullable restore
#line 155 "/Users/cuiwenyue/Projects/BlazorMatchGame/BlazorMatchGame/Pages/Index.razor"
                
        animalIconShow = true;
        // Reload new animal list
        Random random = new Random();
        shuffledAnimals = animalEmoji;
        

#line default
#line hidden
#nullable disable
#nullable restore
#line 177 "/Users/cuiwenyue/Projects/BlazorMatchGame/BlazorMatchGame/Pages/Index.razor"
               

    shuffledAnimals = shuffledAnimals
        .OrderBy(item => random.Next())
        .ToList();


    // Reset the matches
    matchesFound = 0;

    // Reset the mistakes
    mistakes = 0;

    // Reset the timer
    tenthsOfSecondsElapsed = 0;

    //DRAFT: Try to let the animal icons show 3 secs then disappear
    //FAIL: It stop the whole game from loading, the game will show up with empty grids.
    //System.Threading.Thread.Sleep(3000);
    //animalIconShow = false;

}

string lastAnimalFound = string.Empty;
string lastDescription = string.Empty;
int lastNumber = 100;

private void ButtonClick(string animal, string animalDescription, int number)
{

    if (lastAnimalFound == string.Empty)
    {
        // First selection of the pair. Remember it.
        lastAnimalFound = animal;
        lastDescription = animalDescription;
        lastNumber = number;

        emptyEmoji[number] = animal;

        // timer start when click the first button
        timer.Start();

    }
    else if ((lastAnimalFound == animal) && (animalDescription != lastDescription))
    {

        // Match found! Reset for next pair
        lastAnimalFound = string.Empty;

        // Replace found animals with empty string to hide them
        shuffledAnimals = shuffledAnimals
            .Select(a => a.Replace(animal, string.Empty))
            .ToList();

        emptyEmoji[number] = animal;

        // Add number of matches that have been found
        matchesFound++;

        // Reload Game if every matches found
        if (matchesFound == (shuffledAnimals.Count) / 2)
        {

            if ((bestTime == 0) || (tenthsOfSecondsElapsed <= bestTime))
            {
                bestTime = tenthsOfSecondsElapsed;
                bestTimeToDisplay = (bestTime / 10F).ToString("0.0s");
            }


            // Stop the timer
            timer.Stop();
            playButtonShow = true;
        }
    }
    else if ((lastAnimalFound == animal) && (animalDescription == lastDescription))
    {


        // Click on the same button
        lastAnimalFound = animal;
        lastDescription = animalDescription;
        lastNumber = number;
        emptyEmoji[number] = animal;
    }
    else
    {
        emptyEmoji[number] = animal;
        Task.Delay(1000).ContinueWith(e => EmptyIcon(number, lastNumber));


        // pair don't match, reset selection.


        mistakes++;
    }
}

private void EmptyIcon(int number, int lastNumber)
{
    emptyEmoji[number] = string.Empty;
    emptyEmoji[lastNumber] = string.Empty;
    lastAnimalFound = string.Empty;
    lastNumber = 100;
}

private void Timer_Tick(Object source, ElapsedEventArgs e)
{
    InvokeAsync(() =>
    {

        tenthsOfSecondsElapsed++;
        timeDisplay = (tenthsOfSecondsElapsed / 10F)
        .ToString("0.0s");
        StateHasChanged();
    });
}

private void PlayButtonClick()
{
    SetUpGame();
    playButtonShow = false;
    for (int i=0; i<emptyEmoji.Count;i++)
    {
        emptyEmoji[i] = string.Empty;
    }
}


    

#line default
#line hidden
#nullable disable
#nullable restore
#line 320 "/Users/cuiwenyue/Projects/BlazorMatchGame/BlazorMatchGame/Pages/Index.razor"
           

    
    //1. Add Play Again Button (Done)
    //2. Fix the bug of clicking same button and count as wrong (Done)
    //3. Add mistakes counter (Done)
    //4. Add Best Time Record (Done)
    //5. Add different levels to this game: easy normal hard
    //    1) Add choose level button list (done)
    //    2) Add changing level function
    //    3) Add new list to hold lists with different level (higher level has more list element)
    //    4)

#line default
#line hidden
#nullable disable
    }
}
#pragma warning restore 1591
