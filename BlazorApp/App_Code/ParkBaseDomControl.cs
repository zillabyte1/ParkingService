using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Globalization;

using System.Text;

namespace BlazorApp {

  public abstract class ParkBaseDomControl : ParkBaseControl {

    [Parameter]
    public string Id { get; set; } = IdGeneratorHelper.Generate("dfPark_id_");

    [Parameter(CaptureUnmatchedValues = true)]
    public Dictionary<string, object> Attributes { get; set; }


    private ElementReference _ref;

    /// <summary>
    /// Returned ElementRef reference for DOM element.
    /// </summary>
    public virtual ElementReference Ref {
      get => _ref;
      set {
        _ref = value;
        RefBack?.Set(value);
      }
    }

    [CascadingParameter]
    public ParkTheme Theme { get; set; }

    protected ClassMapper ClassMapper { get; } = new ClassMapper();

    protected ParkBaseDomControl() {
      ClassMapper
          .Get(() => this.Class)
          .Get(() => this.Theme?.GetClass());
    }

    /// <summary>
    /// Specifies one or more classnames for an DOM element.
    /// </summary>
    [Parameter]
    public string Class {
      get => _class;
      set { _class = value; }
    }


    /// <summary>
    /// Specifies an inline style for an DOM element.
    /// </summary>
    [Parameter]
    public string Style {
      get => _style;
      set {
        _style = value;
        this.StateHasChanged();
      }
    }

    /// <summary>
    /// Specifies timestamp for data element.
    /// </summary>
    [Parameter]
    public string DataTimeStamp {
      get => _datatimestamp;
      set {
        _datatimestamp = value;
        this.StateHasChanged();
      }
    }

    protected virtual string GenerateStyle() {
      return Style;
    }

    private string _class;
    private string _style;
    private string _datatimestamp;

    public ParkControlType m_ControlType = ParkControlType.NA;

    //~~~~~~~~~~~~~~~~~~~~~~~~~'
    public ParkControlType ControlType {
      get { return m_ControlType; }
      set { m_ControlType = value; }
    }

    //~~~~~~~~~~~~~~~~~~~~~~~~~'
    // CONTROL EVENTS
    //~~~~~~~~~~~~~~~~~~~~~~~~~'
    public delegate void UserControlSubmitEventHandler(object s, ParkControlType e, string Action);
    public event UserControlSubmitEventHandler UserControlSubmit;

    //~~~~~~~~~~~~~~~~~~~~~~~~~'
    public void OnUserControlSubmit(string Action) {
      this.DataTimeStamp = DateTime.Now.ToString();       
    }


  } //-- END CLASS
} //-- END NAMESPACE
