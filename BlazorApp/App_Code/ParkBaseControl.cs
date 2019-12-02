using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace BlazorApp {

  public enum ParkControlType : int {
    ParkLot = 1,
    ParkLog = 2,
    NA = 99
  }

  public abstract class ParkBaseControl : ComponentBase, IParkBaseControl, IDisposable {
    
    [Parameter]
    public ForwardRef RefBack { get; set; }

    private Queue<Func<Task>> afterRenderCallQuene = new Queue<Func<Task>>();

    protected void CallAfterRender(Func<Task> action) {
      afterRenderCallQuene.Enqueue(action);
    }

    protected async override Task OnAfterRenderAsync(bool firstRender) {
      await base.OnAfterRenderAsync(firstRender);
      if (firstRender) {
        await OnFirstAfterRenderAsync();
      }

      if (afterRenderCallQuene.Count > 0) {
        var actions = afterRenderCallQuene.ToArray();
        afterRenderCallQuene.Clear();

        foreach (var action in actions) {
          if (Disposed) {
            return;
          }
          await action();
        }
      }
    }

    protected virtual Task OnFirstAfterRenderAsync() {
      return Task.CompletedTask;
    }

    protected ParkBaseControl() {
    }

    public virtual void Dispose() {
      Disposed = true;
    }

    protected bool Disposed { get; private set; }

    protected void InvokeStateHasChanged() {
      InvokeAsync(() =>
      {
        if (!Disposed)
        {
          StateHasChanged();
        }
      });
    }

    [Inject]
    protected IJSRuntime Js { get; set; }

    protected async Task<T> JsInvokeAsync<T>(string code, params object[] args) {
      
    try {
        return await Js.InvokeAsync<T>(code, args);
      } catch (Exception e) {
        Console.WriteLine(e);
        //throw;
      }

      return default(T);
    }

  } //-- END CLASS
} //-- END NAMESPACE
