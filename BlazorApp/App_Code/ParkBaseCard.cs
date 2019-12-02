using Microsoft.AspNetCore.Components;

namespace BlazorApp {

  public class ParkBaseCard : ParkBaseDomControl {
    public ParkBaseCard() {
    }

    [Parameter]
    public RenderFragment ChildContent { get; set; }

  } //-- END CLASS
} //-- END NAMESPACE

