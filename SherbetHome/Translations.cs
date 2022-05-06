using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rocket.API.Collections;

namespace SherbetHome
{
    public partial class SherbetHomes
    {
        public override TranslationList DefaultTranslations => new TranslationList()
        {
            { "Home_Fail_NoBed", "[color=red]Your bed is blocked or missing[/color]"},
            { "Home_Fail_AlreadyPending", "[color=red]Already teleporting home[/color]" },
            { "Home_Wait", "[color=yellow]Teleporting home, wait {0} sec...[/color]"},
            { "Home_Failed_Move", "[color=red]Teleport canceled because you moved[/color]" },
            { "Home_Teleported", "[color=green]Telepored to your bed[/color]"},
            { "Home_Failed_Blocked", "[color=red]Teleport failed because your bed was blocked or broken[/color]"},
        };
    }
}
